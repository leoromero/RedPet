import React, { useState, useContext } from 'react';
import { Card, Divider, Grid, TextField, Typography, Button } from '@material-ui/core';
import FacebookLoginButton from './facebookLoginButton';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { makeStyles } from '@material-ui/styles';

const Login = (props) => {
  const { login } = useContext(AuthContext);
  const [user, setUser] = useState('');
  const [password, setPassword] = useState('');
  const classes = styles();
  return (
    <Card>
      <Grid container className={classes.row}>
        <Grid item xs={12}>
          <Typography align='center' variant='title'>Iniciar Sesión</Typography>
        </Grid>
        <Grid item item xs={12}>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <TextField
                label='Usuario'
                value={user}
                onChange={(event) => setUser(event.target.value)}
              />
            </Grid>
          </Grid>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <TextField
                label='Contraseña'
                value={password}
                onChange={(event) => setPassword(event.target.value)}
              />
            </Grid>
          </Grid>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <Divider variant='middle' />
            </Grid>
          </Grid>
          <Grid container justify='space-evenly' className={classes.row}>
            <Grid item>
              <Button color='default' variant='contained'>Cancelar</Button>
            </Grid>
            <Grid item>
              <Button color='primary' variant='contained'>Iniciar Sesión</Button>
            </Grid>
          </Grid>
          <Divider variant='middle'></Divider>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <FacebookLoginButton login={login} />
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Card>
  )
}
export default Login;