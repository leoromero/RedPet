import React, { useContext, useState, useEffect } from 'react';
import { Grid, Button } from '@material-ui/core';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import UserForm from '../RegisterUser/UserForm';
import editUserValidation from '../../validations/editUserValidation';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { MessageContext } from '../../contexts/MessageContext';
import { Formik } from 'formik';
import { userModel } from '../../models/user/user';

const UserInformation = (props) => {
    const { user } = useContext(AuthContext);
    const { showMessage } = useContext(MessageContext);
    const [userToEdit, setUserToEdit] = useState(undefined);

    useEffect(() => {
        const apiCall = async () => {
            const role = user.role;

            let apiResponse = '';
            if (role === "Customer")
                apiResponse = await useApi(Api.customers.getByUsername(user.username), showMessage);
            else if (role === "Provider")
                apiResponse = await useApi(Api.providers.getByUsername(user.username), showMessage);

            if (apiResponse.ok) {
                setUserToEdit(apiResponse.result);
            }
        };
        apiCall();
    }, []);

    const submitForm = async user => {
        const role = user.role;

        let apiResponse = '';
        if (role === "Customer")
            apiResponse = await useApi(Api.customers.update(user), showMessage);
        else if (role === "Provider")
            apiResponse = await useApi(Api.providers.update(user), showMessage);

        if (apiResponse.ok) {
            showMessage("Usuario actualizado con exito", "success");
        }
    }
    const classes = styles();
    return (
        <Grid container item xs={12}>
            <Grid container justify='center' alignItems='center' className={classes.page}>
                <Formik enableReinitialize
                    initialValues={userToEdit ? userToEdit : userModel}
                    validationSchema={editUserValidation}
                    onSubmit={submitForm}
                    render={props => <UserForm {...props} isNew={false} />}
                />
            </Grid>
            <Grid container>
                <Grid container justify='space-evenly' className={classes.row}>
                    <Grid item>
                        <Button type='submit' form="user" color='secondary' variant='contained'>Guardar</Button>
                    </Grid>
                </Grid>
            </Grid>
        </Grid>
    );
}
export default UserInformation;