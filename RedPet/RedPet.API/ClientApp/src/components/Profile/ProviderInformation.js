import React, { useContext, useEffect, useState } from 'react';
import { Grid, Button } from '@material-ui/core';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { ProviderModel, NationalityModel, IdTypeModel } from '../../models/provider/provider';
import ProviderForm from './ProviderForm';
import providerValidation from '../../validations/providerValidation';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { Formik } from 'formik';
import { MessageContext } from '../../contexts/MessageContext';

const ProviderInformation = (props) => {
    const showMessage = useContext(MessageContext);
    const { user } = useContext(AuthContext);
    const [provider, setProvider] = useState(undefined);

    useEffect(() => {
        const apiCall = async () => {
            const apiResponse = await useApi(Api.providers.getByUsername(user.username), showMessage);

            if (apiResponse.ok) {
                apiResponse.result.nationality = apiResponse.result.nationality ? apiResponse.result.nationality : NationalityModel;
                apiResponse.result.identificationType = apiResponse.result.identificationType ? apiResponse.result.identificationType : IdTypeModel;
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
                    initialValues={provider ? provider : ProviderModel}
                    validationSchema={providerValidation}
                    onSubmit={submitForm}
                    render={props => <ProviderForm {...props} />}
                />
            </Grid>
            <Grid container>
                <Grid container justify='space-evenly' className={classes.row}>
                    <Grid item>
                        <Button type='submit' form="providerForm" color='secondary' variant='contained'>Guardar</Button>
                    </Grid>
                </Grid>
            </Grid>
        </Grid>
    );
}
export default ProviderInformation;