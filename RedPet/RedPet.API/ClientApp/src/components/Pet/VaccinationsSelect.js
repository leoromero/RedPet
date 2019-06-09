import React from 'react';
import { Grid,Typography, IconButton, Fab } from '@material-ui/core';
import FormikDatePicker from '../FormikDatePicker';
import { Delete, Add } from '@material-ui/icons';
import { vaccinationModel } from '../../models/pet/pet';
import VaccineSelect from '../VaccineSelect';
import { Field } from 'formik';
import styles from '../../styles/styles';

const VaccinationsSelect = (props) => {
  const {
     push, remove, form
  } = props;

  const classes = styles();
  return (
    <Grid container justify='center'>
      <Grid item xs={6}>
        <Grid container justify='center'>
          <Grid item xs={6}>
            <Grid container justify='flex-start' alignItems='center'>
              <Typography variant='h6'>Vacunas</Typography>
            </Grid>
          </Grid>
          <Grid item xs={6} >
            <Grid container justify='flex-end' alignItems='center'>
            <Fab onClick={() => push({ vaccinationModel })} color="primary" aria-label="Add" className={classes.fab}>
                <Add />
              </Fab>
            </Grid>
          </Grid>
        </Grid>
      </Grid >
      {
        form.values.vaccinations.map((vaccination, index) => (
          <Grid container justify='center'>
            <Grid item xs={4}>
              <VaccineSelect onChange={form.handleChange} name={`vaccinations.${index}.vaccineId`} value={vaccination.vaccineId}></VaccineSelect>
            </Grid>
            <Grid item xs={4} className={classes.formControl}>
              <Field component={FormikDatePicker} name={`vaccinations.${index}.vaccinationDate`} label='Fecha de vacunación'></Field>
            </Grid>
            <Grid item xs={1} className={classes.formControl}>
              <IconButton color='primary' onClick={() => remove(index)}>
                <Delete></Delete>
              </IconButton>
            </Grid>
          </Grid>
        ))
      }
    </Grid >
  );
};

export default VaccinationsSelect;