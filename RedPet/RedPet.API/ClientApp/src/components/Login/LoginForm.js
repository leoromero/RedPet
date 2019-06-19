import React, { useState, useContext } from 'react';
import { Card, Divider, Grid, TextField, Typography, Button, CardActionArea, CardHeader, CardContent, CardActions } from '@material-ui/core';
import FacebookLoginButton from './FacebookLoginButton';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { makeStyles } from '@material-ui/styles';

const LoginForm = (props) => {
  const {
    values,
    errors,
    touched,
    handleSubmit,
    handleChange,
    isValid,
    setFieldTouched
    } = props;

    const change = name => e => {
      e.persist();
      handleChange(e);
      setFieldTouched(name);
    }
  
  return (
    <form id='loginForm' onSubmit={handleSubmit}>
    <Grid container>
      <Grid item xs={12} container direction="column" alignItems="center" justify='center'>
        <Grid item>
          <TextField
            name='username'
            label='Usuario'
            value={values.username}
            onChange={change('username')}
            helperText={touched.username ? errors.username : ''}
            error={Boolean(touched.username && errors.username)}
          />
        </Grid>
        <Grid item>
          <TextField
            name='password'
            label='Contraseña'
            value={values.password}
            onChange={change('password')}
            helperText={touched.password ? errors.password : ''}
            error={Boolean(touched.password && errors.password)}
          />
        </Grid>
      </Grid>
    </Grid>
    </form>
  )
}
export default LoginForm;