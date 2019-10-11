import React, { useEffect, useState, useContext } from 'react';
import { Card, CardContent, CardHeader, CardActions, Button, Grid } from '@material-ui/core';
import styles from '../../styles/styles';
import { withRouter } from 'react-router-dom';
import serviceValidation from '../../validations/service/serviceValidation';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { Formik } from 'formik';
import { MessageContext } from '../../contexts/MessageContext';
import { AuthContext } from '../../contexts/AuthContext';
import ServiceSearchForm from './ServiceSearchForm';
import { ServiceSearchModel } from '../../models/serviceSearch/serviceSearch';

const ServiceSearchPaper = (props) => {
  const classes = styles();
  const showMessage = useContext(MessageContext);
  const { user } = useContext(AuthContext);

  const submitForm = async service => {

    let apiResponse;
    
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
            title='Buscar servicios'
            titleTypographyProps={{ color: "secondary", align: "center" }}
          />
          <CardContent>
            <Formik
              enableReinitialize
              initialValues={ServiceSearchModel}
              validationSchema={serviceValidation}
              onSubmit={submitForm}
              component={ServiceSearchForm}
            />
          </CardContent>
          <CardActions>
            <Grid container>
              <Grid container justify='space-evenly' className={classes.row}>
                <Grid item>
                  <Button type='submit' form="serviceForm" color='secondary' variant='contained'>Buscar</Button>
                </Grid>
              </Grid>
            </Grid>
          </CardActions>
        </Card>
      </Grid>
    </Grid >
  );
};

export default withRouter(ServiceSearchPaper);