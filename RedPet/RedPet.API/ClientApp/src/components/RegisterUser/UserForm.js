import React, { useState, useContext } from 'react';
import { Grid, TextField, FormControl, FormLabel, RadioGroup, FormControlLabel, FormHelperText, Radio } from '@material-ui/core';
import styles from '../../styles/styles';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { MessageContext } from '../../contexts/MessageContext';

const UserForm = (props) => {
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

  const validateEmail = email => {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
  }

  const handleEmailChange = async e => {
    e.persist();
    setUserExists(false);
    const email = e.currentTarget.value;
    if (!validateEmail(email)) return;

    const apiResponse = await useApi(Api.users.validateEmail(e.currentTarget.value), showMessage);

    if (apiResponse) {
      if (apiResponse.status !== 200 && apiResponse.status !== 409) {
        showMessage('Se produjo un error intentando conectar al servidor. Intente de nuevo mas tarde.', 'error');
      }

      setUserExists(apiResponse.status === 409);
    }
  }

  return (
    <form onSubmit={handleSubmit} id='user'>
      <Grid container>
        <Grid item container xs={12} sm={twoColumns ? 6 : 12}>
          <Grid item xs={12} container justify='center' className={classes.row}>
            <TextField
              name='email'
              label='Email'
              value={values.email}
              onChange={change('email')}
              onBlur={handleEmailChange}
              helperText={userExists ? "Este email ya esta registrado." : touched.email ? errors.email : ''}
              error={Boolean((touched.email && errors.email) || userExists)}
            />
          </Grid>
          {isNew &&
            <>
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
            </>
          }
        </Grid>
        <Grid item container xs={12} sm={twoColumns ? 6 : 12}>
          <Grid item item xs={12} container justify='center' className={classes.row}>
            <TextField
              name='firstName'
              label='Nombre'
              value={values.firstName}
              onChange={change('firstName')}
              helperText={touched.firstName ? errors.firstName : ''}
              error={Boolean(touched.firstName && errors.firstName)}
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
                  <FormControlLabel value="f" control={<Radio checked={values.gender === "f"} />} label="Mujer" />
                  <FormControlLabel value="m" control={<Radio checked={values.gender === "m"} />} label="Hombre" />
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
export default UserForm;