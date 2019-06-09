import React from 'react';
import { Grid, TextField, withStyles, FormControl, FormLabel, RadioGroup, Radio, FormControlLabel, FormHelperText } from '@material-ui/core';
import SizeSelect from '../SizeSelect';
import HairTypeSelect from '../HairTypeSelect';
import styles from '../../styles/styles';
import { Field } from 'formik';
import FormikDatePicker from '../FormikDatePicker';
import WeightRangeSelect from '../WeightRangeSelect';
import BreedSelect from '../BreedSelect';

const BookingForm = (props) => {
  const {
    values,
    errors,
    touched,
    handleSubmit,
    handleChange,
    isValid,
    setFieldTouched
  } = props;

  const classes = styles();
  const change = name => e => {
    e.persist();
    handleChange(e);
    setFieldTouched(name);
  }
  return (
    <form onSubmit={handleSubmit} id='step-0-form'>
      <Grid container justify='center' >
        <Grid item>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <TextField
                name='name'
                label='Nombre'
                value={values.name}
                onChange={change('name')}
                InputLabelProps={{ FormLabelClasses: { focused: classes.textField } }}
                className={classes.formControl}
                helperText={touched.name ? errors.name : ''}
                error={Boolean(touched.name && errors.name)}
              />
            </Grid>
          </Grid>
          <Grid container justify='center' className={classes.row}>
            <Grid item className={classes.formControl}>
              <Field component={FormikDatePicker} label='Fecha de nacimiento' name='birthDate'></Field>
            </Grid>
          </Grid>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <FormControl
                component="fieldset"
                className={classes.formControl}
                error={Boolean(touched.gender && errors.gender)}
              >
                <FormLabel component="legend">Sexo</FormLabel>
                <RadioGroup
                  aria-label="Sexo"
                  name="gender"
                  value={values.gender}
                  className={classes.row}
                  onChange={change('gender')}
                >
                  <FormControlLabel value="f" control={<Radio />} label="Hembra" />
                  <FormControlLabel value="m" control={<Radio />} label="Macho" />
                </RadioGroup>
                <FormHelperText >{touched.gender && errors.gender}</FormHelperText>
              </FormControl>
            </Grid>
          </Grid>
        </Grid>
        <Grid item>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
            <BreedSelect
                formControlClasses={classes.formControl}
                value={values.breed.id}
                onChange={change('breed')}
                error={Boolean(touched.breed && errors.breed && errors.breed.id)}
                helperText={touched.breed && errors.breed && errors.breed.id}
              ></BreedSelect>
            </Grid>
          </Grid>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <SizeSelect
                formControlClasses={classes.formControl}
                value={values.petSize.id}
                onChange={change('petSize')}
                error={Boolean(touched.petSize && errors.petSize && errors.petSize.id)}
                helperText={touched.petSize && errors.petSize && errors.petSize.id}
              ></SizeSelect>
            </Grid>
          </Grid>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <WeightRangeSelect
                formControlClasses={classes.formControl}
                value={values.weightRange.id}
                onChange={change('weightRange')}
                error={Boolean(touched.weightRange && errors.weightRange && errors.weightRange.id)}
                helperText={touched.weightRange && errors.weightRange && errors.weigthRange.id}
              ></WeightRangeSelect>
            </Grid>
          </Grid>         
        </Grid>
      </Grid>
    </form >
  );
};

export default BookingForm;