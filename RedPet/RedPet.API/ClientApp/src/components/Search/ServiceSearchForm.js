import React, { useContext, useState, useEffect } from 'react';
import { Paper, Grid, TextField } from '@material-ui/core';
import ServiceTypesRadioButtons from '../Common/ServiceTypesRadioButtons';
import WeekDaysCheckboxes from '../Common/WeekDaysCheckboxes';
import FrecuencyRadioButtons from '../Common/FrecuencyRadioButtons';
import Api from '../../helpers/Api';
import useApi from '../../Hooks/useApi';
import { withRouter } from 'react-router-dom';
import { AuthContext } from '../../contexts/AuthContext';
import { MessageContext } from '../../contexts/MessageContext';
import styles from '../../styles/styles';
import { ServiceTypeModel, WeekDaysModel } from '../../models/service/service';
import { Field } from 'formik';
import FormikDatePicker from '../FormikDatePicker';
import PetSelect from '../PetSelect';
import { ServiceSearchModel } from '../../models/serviceSearch/serviceSearch';

const ServiceSearchForm = (props) => {
  const {
    values,
    errors,
    touched,
    handleSubmit,
    handleChange,
    isValid,
    setFieldTouched,
    setFieldValue,
  } = props;

  const classes = styles();
  const { user } = useContext(AuthContext);
  const showMessage = useContext(MessageContext);
  const [frecuencies, setFrecuencies] = useState(undefined);
  const [services, setServices] = useState(undefined);
  const [serviceTypes, setServiceTypes] = useState(undefined);
  const [tabValue, setTabValue] = React.useState(1);
  const oneTimeFrecuencyId = frecuencies && frecuencies.find(x=>x.name == 'Unica vez').id;

  useEffect(() => {
    const servicesApiCall = async () => {

      const apiResponse = await useApi(Api.services.read(), showMessage);

      if (apiResponse.ok) {
        setServices(apiResponse.result);
      }
    };
    const serviceTypesApiCall = async () => {

      const apiResponse = await useApi(Api.parameters.serviceTypes(), showMessage);

      if (apiResponse.ok) {
        setServiceTypes(apiResponse.result);
      }
    };
    const frecuenciesApiCall = async () => {

      const apiResponse = await useApi(Api.parameters.frecuencies(), showMessage);

      if (apiResponse.ok) {
        setFrecuencies(apiResponse.result);
      }
    };

    frecuenciesApiCall();
    servicesApiCall();
    serviceTypesApiCall();
  }, []);

  const change = name => e => {
    e.persist();
    handleChange(e);
    setFieldTouched(name);
  }

  return (
    <form onSubmit={handleSubmit} id='searchForm'>
      <Grid container direction='column'>
        <Grid item xs={12} container justify='center' className={classes.row}>
          <ServiceTypesRadioButtons
            title='¿Que necesitas?'
            value={values.serviceTypeId ? values.serviceTypeId : 0 }
            onChange={change('serviceTypeId')}
            name='serviceTypeId'
            id='serviceTypeId'
            error={Boolean(touched.serviceTypeId && errors.serviceTypeId )}
            helperText={touched.serviceTypeId && errors.serviceTypeId } />
        </Grid>
        <Grid container direction='row'>
          <Grid container item xs={12} md={6} lg={6} alignItems='center' justify='center'>
            <TextField
              id="address"
              label="Dirección"
              margin="normal"
            />
          </Grid>
          <Grid container item xs={12} md={6} lg={6} alignItems='center' justify='center'>
            <FrecuencyRadioButtons
              title='¿Con que frecuencia quieres el servicio?'
              value={values.frecuencyId ? values.frecuencyId : 0}
              onChange={change('frecuencyId')}
              name='frecuencyId'
              id='frecuencyId'
              error={Boolean(touched.frecuencyId && errors.frecuencyId )}
              helperText={touched.frecuencyId && errors.frecuencyId } />
          </Grid>
        </Grid>
        <Grid container direction='row'>
          {values.frecuencyId != oneTimeFrecuencyId &&
          <Grid container item xs={12} md={6} alignItems='center' justify='center'>
            <WeekDaysCheckboxes
              title="¿Que días de la semana?"
              values={values.weekDays ? values.weekDays : WeekDaysModel}
              onChange={change('weekDays')}
              error={Boolean(touched.weekDays && errors.weekDays)}
              helperText={touched.weekDays && errors.weekDays} />
          </Grid>}
          <Grid container item xs={12} md={6} alignItems='center' justify='center'>
            <Field component={FormikDatePicker} disableFuture={false} label='Desde'  name='dateFrom'></Field>
          </Grid>
          {values.frecuencyId == oneTimeFrecuencyId &&
          <Grid container item xs={12} md={6} alignItems='center' justify='center'>
            <Field component={FormikDatePicker} disableFuture={false} label='Hasta' name='dateTo'></Field>
          </Grid>}
        </Grid>
        <Grid container direction='row'>
          <Grid container item xs={12} md={6} alignItems='center' justify='center'>
            <PetSelect />
          </Grid>
        </Grid>
      </Grid>
    </form>
  );
};

export default withRouter(ServiceSearchForm);