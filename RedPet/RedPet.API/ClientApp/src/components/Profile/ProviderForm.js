import React, { useState, useContext } from 'react';
import { Grid, TextField, FormControl, FormLabel, RadioGroup, FormControlLabel, FormHelperText, Radio } from '@material-ui/core';
import styles from '../../styles/styles';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { MessageContext } from '../../contexts/MessageContext';

const ProviderForm = (props) => {
  const {
    values,
    errors,
    touched,
    handleSubmit,
    handleChange,
    isValid,
    setFieldTouched,
    isNew,
    twoColumns
  } = props;

  const showMessage = useContext(MessageContext);
  const [userExists, setUserExists] = useState(false);

  const classes = styles();

  const change = name => e => {
    e.persist();
    handleChange(e);
    setFieldTouched(name);
  }

  return (
    <form onSubmit={handleSubmit} id='user'>
      <Grid container>
        <Grid item container xs={12} sm={twoColumns ? 6 : 12}>
          <Grid item xs={12} container justify='center' className={classes.row}>
            <TextField
              name='address'
              label='Dirección'
              value={values.address}
              onChange={change('address')}
              helperText={touched.address ? errors.address : ''}
              error={Boolean(touched.address && errors.address)}
            />
          </Grid>
          <Grid item container justify='center' className={classes.row}>
            <TextField
              type='password'
              name='password'
              label='Contraseña'
              value={values.password}
              onChange={change('password')}
              helperText={touched.password ? errors.password : ''}
              error={Boolean(touched.password && errors.password)}
            />
          </Grid>
          <Grid item container justify='center' className={classes.row}>
            <TextField
              type='password'
              name='password2'
              label='Repetir Contraseña'
              value={values.password2}
              onChange={change('password2')}
              helperText={touched.password2 ? errors.password2 : ''}
              error={Boolean(touched.password2 && errors.password2)}
            />
          </Grid>
        </Grid>
        <Grid item container xs={12} sm={twoColumns ? 6 : 12}>
          <Grid item item xs={12} container justify='center' className={classes.row}>
            <TextField
              name='name'
              label='Nombre'
              value={values.name}
              onChange={change('name')}
              helperText={touched.name ? errors.name : ''}
              error={Boolean(touched.name && errors.name)}
            />
          </Grid>
          <Grid item container justify='center' className={classes.row}>
            <TextField
              name='lastName'
              label='Apellido'
              value={values.lastName}
              onChange={change('lastName')}
              helperText={touched.lastName ? errors.lastName : ''}
              error={Boolean(touched.lastName && errors.lastName)}
            />
          </Grid>

          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <FormControl
                component="fieldset"
                className={classes.formControl}
              >
                <FormLabel component="legend">Sexo</FormLabel>
                <RadioGroup
                  aria-label="Sexo"
                  name="gender"
                  value={values.gender}
                  className={classes.row}
                  onChange={change('gender')}
                >
                  <FormControlLabel value="f" control={<Radio />} label="Mujer" />
                  <FormControlLabel value="m" control={<Radio />} label="Hombre" />
                </RadioGroup>
                <FormHelperText >{touched.gender && errors.gender}</FormHelperText>
              </FormControl>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </form>
  )
}
export default ProviderForm;