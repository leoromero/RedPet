import React, { useEffect, useState, useContext } from 'react';
import { Card, CardContent, CardHeader, CardActions, Button, Grid } from '@material-ui/core';
import styles from '../../styles/styles';
import { withRouter } from 'react-router-dom';
import ServiceForm from './ServiceForm';
import { ServiceModel } from '../../models/service/service';
import serviceValidation from '../../validations/service/serviceValidation';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { Formik } from 'formik';
import { MessageContext } from '../../contexts/MessageContext';
import { AuthContext } from '../../contexts/AuthContext';

const ServicePage = (props) => {
  const classes = styles();
  const [service, setService] = useState(undefined);
  const showMessage = useContext(MessageContext);
  const {user} = useContext(AuthContext);
  const isEdit = service != undefined;

  useEffect(() => {
    const serviceId = props.match.params.id;
    if (serviceId) {
      const serviceApiCall = async () => {
        const apiResponse = await useApi(Api.services.getById(serviceId), showMessage);

        if (apiResponse.ok) {
          setService(apiResponse.result);
        }
      };

      serviceApiCall();
    }
  }, []);

  const submitForm = async service => {

    let apiResponse;
    if(isEdit) 
      apiResponse = await useApi(Api.services.update(service))
    else
        apiResponse = await useApi(Api.services.create(service, user.id), showMessage);

    if (apiResponse.ok) {
      showMessage("Servicio guardado con exito", "success");
    }
  }

  return (
    <Grid container justify='center' alignItems='center' className={classes.page} >
      <Grid item xs={12} md={10} lg={8}>
        <Card >
          <CardHeader
            titleTypographyProps={{ align: "center" }}
            title={isEdit? 'Editar servicio':'Nuevo servicio'}
            titleTypographyProps={{color:"secondary", align:"center"}}
          />
          <CardContent>
            <Formik
              enableReinitialize
              initialValues={service ? service : ServiceModel}
              validationSchema={serviceValidation}
              onSubmit={submitForm}
              component={ServiceForm}
            />
          </CardContent>
          <CardActions>
        <Grid container>
          <Grid container justify='space-evenly' className={classes.row}>
            <Grid item>
              <Button color='default' variant='contained'>Cancelar</Button>
            </Grid>
            <Grid item>
              <Button type='submit' form="serviceForm" color='secondary' variant='contained'>{isEdit? 'Editar' : 'Crear Servicio'}</Button>
            </Grid>
          </Grid>
        </Grid>
      </CardActions>
        </Card>
      </Grid>
    </Grid >
  );
};

export default withRouter(ServicePage);