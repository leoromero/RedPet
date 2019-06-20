import React, { useState, useContext, useEffect } from 'react';
import { Card, Grid, Button, CardHeader, CardContent, CardActions } from '@material-ui/core';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import FacebookLoginButton from '../Login/FacebookLoginButton';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import { MessageContext } from '../../contexts/MessageContext';
import RegisterForm from './RegisterForm';
import { Formik } from 'formik';
import userValidation from '../../validations/userValidation';
import { userModel } from '../../models/user/user';
import { withRouter } from 'react-router-dom';

const Register = (props) => {

  const showMessage = useContext(MessageContext);
  const { login } = useContext(AuthContext);
  const classes = styles();
  const [user, setUser] = useState(undefined);

  useEffect(() => {
    if (props.userId) {
      const apiCall = async () => {
        const apiResponse = await useApi(Api.users.getById(props.userId), showMessage);

        if (apiResponse.ok) {
          setUser(apiResponse.result);
        }
      };

      apiCall();
    }
  }, []);


  const submitForm = async user => {
    const role = props.role === "Provider" ? "Provider" : "Customer";

    let apiResponse = '';
    if (role === "Customer")
      apiResponse = await useApi(Api.customers.create(user), showMessage);
    else if(role === "Provider")
      apiResponse = await useApi(Api.providers.create(user), showMessage);

    if (apiResponse.ok) {
      showMessage("Usuario creado con exito", "success");
      props.history.push("/");
    }
  }

  return (
    <Card>
      <CardHeader
        titleTypographyProps={{ align: "center" }}
        title={'Nuevo ' + (props.role === "Provider" ? "Cuidador" : "Usuario")}
      />
      <CardContent>
        <Formik enableReinitialize
          initialValues={user ? user : userModel}
          validationSchema={userValidation}
          onSubmit={submitForm}
          component={RegisterForm} />
      </CardContent>
      <CardActions>
        <Grid container>
          <Grid container justify='space-evenly' className={classes.row}>
            <Grid item>
              <Button color='default' variant='contained'>Cancelar</Button>
            </Grid>
            <Grid item>
              <Button type='submit' form="user" color='secondary' variant='contained'>Crear Usuario</Button>
            </Grid>
          </Grid>
          <Grid item container justify='center' className={classes.row}>
            <FacebookLoginButton login={login} />
          </Grid>
        </Grid>
      </CardActions>
    </Card >
  )
}
export default withRouter(Register);