import React, { useState, useContext } from 'react';
import { Card, Divider, Grid, Button, CardHeader, CardContent, CardActions } from '@material-ui/core';
import FacebookLoginButton from './FacebookLoginButton';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { MessageContext } from '../../contexts/MessageContext';
import { makeStyles } from '@material-ui/styles';
import LoginForm from './LoginForm';
import { Formik } from 'formik';
import loginValidation from '../../validations/loginValidation';
import Auth from '../../helpers/Auth';
import CircularProgress from '@material-ui/core/CircularProgress';
import { withRouter } from 'react-router-dom';


const Login = (props) => {
  const showMessage = useContext(MessageContext);
  const { login } = useContext(AuthContext);
  const [user, setUser] = useState('');
  const [loading, setLoading] = useState(false);
  const [password, setPassword] = useState('');
  const classes = styles();

  const submitForm = async (model) => {
    setLoading(true);

    const apiResponse = await Auth.login(model.username, model.password);

    if (apiResponse.ok) {
      login(apiResponse.accessToken, apiResponse.refreshToken, apiResponse.user);

      props.history.push("/");
    }
    else {
      setLoading(false);
      if (apiResponse.status === 403) {
        showMessage("Usuario o contraseña incorrectos", 'info');
      }
    }
  }

  return (
    <Card>
      <CardHeader
        titleTypographyProps={{ align: "center" }}
        title='Iniciar Sesión'
      />
      <CardContent>
        <Formik enableReinitialize
          initialValues={{ username: '', password: '' }}
          validationSchema={loginValidation}
          onSubmit={submitForm}
          component={LoginForm} />
      </CardContent>

      <CardActions>
        <Grid container>
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
              <Button color='secondary' variant='contained' type='submit' form="loginForm" >
                {loading && <CircularProgress size={24} color='primary' className={classes.circularProgress} />}
                Iniciar Sesión</Button>
            </Grid>
          </Grid>
          <Divider variant='middle'></Divider>
          <Grid container justify='center' className={classes.row}>
            <Grid item>
              <FacebookLoginButton login={login} />
            </Grid>
          </Grid>
        </Grid>
      </CardActions>
    </Card >
  )
}
export default withRouter(Login);