import React, { useContext, useState } from 'react';
import { MessageContext } from '../../contexts/MessageContext';
import { Grid, TextField, Typography, } from '@material-ui/core';
import styles from '../../styles/styles';
import { FieldArray } from 'formik';
import { WeekDaysModel, WorkableTimesModel, ServiceTypeModel } from '../../models/service/service';
import WeekDaysCheckboxes from '../Common/WeekDaysCheckboxes';
import ServiceTypeSelect from '../Selects/ServiceTypeSelect';
import PetSizesFormikArrayCheckboxes from '../Common/PetSizesFormikArrayCheckboxes';
import FrecuencyRadioButtons from '../Common/FrecuencyRadioButtons';
import PricesInputs from '../Common/PricesInputs';
import FrecuenciesFormikArrayCheckboxes from '../Common/FrecuenciesFormikArrayCheckboxes';

const ServiceForm = (props) => {
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

  const showMessage = useContext(MessageContext);
  const classes = styles();

  const change = name => e => {
    e.persist();
    handleChange(e);
    setFieldTouched(name);
  }

  const changePrice = price => {
    setFieldValue('dailyPrice', price);
  }

  const pricesSection =
    <>
      <Grid item xs={12} container direction="column" alignItems='center' className={classes.row}>
        <Typography variant="h5" >Vamos a configurar los precios.</Typography>
        <Typography variant="body2" align="center" >Puedes configurar muchos precios diferentes por días y tamaños de mascotas. Si el servicio es de guarderia se recomienda tener un precio para un plan mensual</Typography>
      </Grid>
      <Grid item xs={12} container justify='center' className={classes.row}>
        <WeekDaysCheckboxes
          title="¿Que días esta disponible?"
          values={values.weekDays ? values.weekDays : WeekDaysModel}
          onChange={change('weekDays')}
          error={Boolean(touched.weekDays && errors.weekDays)}
          helperText={touched.weekDays && errors.weekDays} />
      </Grid>
      <Grid item xs={12} container justify='center' className={classes.row}>
        <FieldArray
          name="petSizes"
          render={(props) => <PetSizesFormikArrayCheckboxes {...props}
            title="¿Con que tamaños de mascotas quiere trabajar?"
            row={true}
            labelPlacement="bottom" />}
        />
      </Grid>
      <Grid item xs={12} container justify='center' className={classes.row}>
        <FieldArray
          name="frecuencies"
          render={(props) => <FrecuenciesFormikArrayCheckboxes {...props}
            title="¿A servicios de que frecuencia aplica el precio?"
            row={true}
            labelPlacement="bottom" />}
        />
        <FrecuencyRadioButtons
          name="frecuency.id"
          title="¿A servicios de que frecuencia aplica el precio?"
          value={values.frecuency.id}
          onChange={change('frecuency')}
          row={true}
          labelPlacement="bottom" />
      </Grid>
      <Grid item xs={12} container justify='center' className={classes.row}>
        <PricesInputs
          onChange={changePrice}
          value={values.dailyPrice}
          name="dailyPrice"
          title="¿Que precio tiene el servicio?"
          row={true}
          labelPlacement="bottom" />
      </Grid>
    </>
  return (
    <form onSubmit={handleSubmit} id='serviceForm'>
      <Grid container>
        <Grid item xs={12} container justify='center' direction="column" alignItems="center" className={classes.row}>
          <Typography variant="h5" >Empecemos con el serivicio que quieres agregar.</Typography>
          <Typography variant="body2" align="center">Puedes tener todos los servicios que quieras!</Typography>
        </Grid>
        <Grid item xs={12} container justify='center' className={classes.row}>
          <ServiceTypeSelect
            value={values.serviceType ? values.serviceType.id : ServiceTypeModel.id}
            onChange={change('serviceType')}
            name='serviceType.id'
            id='serviceType.id'
            error={Boolean(touched.serviceType && errors.serviceType && errors.serviceType.id)}
            helperText={touched.serviceType && errors.serviceType && errors.serviceType.id} />
        </Grid>
        {values.serviceType && values.serviceType.id && pricesSection}
      </Grid>
    </form>
  );
};

export default ServiceForm;