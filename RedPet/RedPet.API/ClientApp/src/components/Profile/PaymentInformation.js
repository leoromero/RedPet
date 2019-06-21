import React, { useContext, useEffect, useState } from 'react';
import { Grid, Button } from '@material-ui/core';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import UserForm from '../RegisterUser/UserForm';
import providerValidation from '../../validations/providerValidation';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { MessageContext } from '../../contexts/MessageContext';
import { Formik } from 'formik';

const PaymentInformation = (props) => {
    const { user } = useContext(AuthContext);
    const [provider, setProvider] = useState(undefined);
    const { showMessage } = useContext(MessageContext);
    
    useEffect(() => {
          const apiCall = async () => {
            const apiResponse = await useApi(Api.providers.getById(user.userId), showMessage);
    
            if (apiResponse.ok) {
              setProvider(apiResponse.result);
            }
          };

          apiCall();        
      }, []);

    const submitForm = async provider => {

        const apiResponse = await useApi(Api.providers.update(provider), showMessage);

        if (apiResponse.ok) {
            showMessage("Usuario actualizado con exito", "success");
        }
    }

    const classes = styles();
    return (
        <Grid container item xs={12}>
            <Grid container justify='center' alignItems='center' className={classes.page}>
                <Formik enableReinitialize
                    initialValues={provider}
                    validationSchema={providerValidation}
                    onSubmit={submitForm}
                    render={props => <UserForm {...props} />}
                />
            </Grid>
            <Grid container>
                <Grid container justify='space-evenly' className={classes.row}>
                    <Grid item>
                        <Button type='submit' form="user" color='secondary' variant='contained'>Grabar</Button>
                    </Grid>
                </Grid>
            </Grid>
        </Grid>
    );
}
export default PaymentInformation;