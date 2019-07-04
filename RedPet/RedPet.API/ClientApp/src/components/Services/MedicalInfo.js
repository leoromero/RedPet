import React, { useState, useEffect } from 'react';
import {  Grid, FormControlLabel, Checkbox, Divider, Typography, TextField } from '@material-ui/core';
import { FieldArray } from 'formik';
import VaccinationsSelect from './VaccinationsSelect';
import styles from '../../styles/styles';

const MedicalInfo = (props) => {
  const {
    values,
    errors,
    touched,
    handleSubmit,
    handleChange,
    isValid,
    setFieldTouched
  } = props;
  const [vaccinesList, setVaccinesList] = useState([]);

  // useEffect(() => {
  //   const apiCall = async () => {
  //     const vaccines = [
  //       {
  //         id: '1',
  //         name: 'vacuna1',
  //         applied: true,
  //         vaccinationDate: null
  //       },
  //       {
  //         id: '2',
  //         name: 'vacundasdsadsada2',
  //         applied: false,
  //         vaccinationDate: null
  //       }
  //     ];
  //     values.vaccinations.map((vaccination) => {
  //       const index = vaccines.indexOf(x => x.id == vaccination.vaccineId);
  //       const currentVaccines = vaccines.slice();

  //       if (index >= 0) {
  //         currentVaccines.splice(index, 1);
  //         currentVaccines.push({ id: vaccination.id, name: vaccination.name, vaccinationDate: vaccination.vaccinationDate })
  //         currentVaccines.sort(x => x.id);
  //       }
  //     });

  //     setVaccinesList(vaccines);
  //   };

  //   apiCall();
  // }, []);
  
  const classes = styles();
  const change = name => e => {
    e.persist();
    handleChange(e);
    setFieldTouched(name);
  }

  return (
    <form onSubmit={handleSubmit} id='step-2-form'>
      <Grid container justify='center' direction='column'>
        <Grid item xs={12}>
          <Grid container justify='center' direction='column'>
            <Grid item xs={6}>
              <FormControlLabel
                control={
                  <Checkbox
                    checked={values.sterilized}
                    onChange={change('sterilized')}
                    value={values.sterilized}
                    name='sterilized'
                  />
                }
                label="Esterilizado"
              />
            </Grid>
            <Grid item xs={6}>
              <FormControlLabel
                control={
                  <Checkbox
                    checked={values.vaccinesUpToDate}
                    onChange={change('vaccinesUpToDate')}
                    value={values.vaccinesUpToDate}
                    name='vaccinesUpToDate'
                  />
                }
                label="Vacunas al día"
              />
            </Grid>
          </Grid>
        </Grid>
        <Divider></Divider>
        <Grid item xs={12}>
          <Grid container justify='center'>
          <Typography>Veterinario</Typography>
          <Grid item>
              <TextField
                name='vet.name'
                label='Nombre'
                value={values.vet.name}
                onChange={change('vet.name')}
                InputLabelProps={{ FormLabelClasses: { focused: classes.textField } }}
                className={classes.formControl}
                helperText={touched.name ? errors.name : ''}
                error={Boolean(touched.name && errors.name)}
              />
            </Grid>
            <Grid item>
              <TextField
                name='vet.address'
                label='Dirección'
                value={values.vet.address}
                onChange={change('vet.address')}
                InputLabelProps={{ FormLabelClasses: { focused: classes.textField } }}
                className={classes.formControl}
                helperText={touched.name ? errors.name : ''}
                error={Boolean(touched.name && errors.name)}
              />
            </Grid>            
            <Grid item>
              <TextField
                name='vet.phone'
                label='Telefono'
                value={values.vet.phone}
                onChange={change('vet.phone')}
                InputLabelProps={{ FormLabelClasses: { focused: classes.textField } }}
                className={classes.formControl}
                helperText={touched.name ? errors.name : ''}
                error={Boolean(touched.name && errors.name)}
              />
            </Grid>
          </Grid>
        </Grid>
      </Grid >
    </form >
  );
};

export default MedicalInfo;