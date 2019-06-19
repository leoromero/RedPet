import React, { useState } from 'react';
import FacebookLogin from 'react-facebook-login';
import Auth from '../../helpers/Auth';
import { withRouter } from 'react-router-dom';
import CircularProgress from '@material-ui/core/CircularProgress';
import { makeStyles } from '@material-ui/styles';

const useStyles = makeStyles((theme) => ({
  wrapper: {
    margin: theme.spacing(),
    position: 'relative',
  },
  circularProgress: {
    position: 'absolute',
    top: '50%',
    left: '50%',
    marginTop: -12,
    marginLeft: -12,
  }
}));

const FacebookLoginButton = (props) => {
  const [loading, setLoading] = useState(false);
  const classes = useStyles();

  const responseFacebook = async (response) => {
    const apiResponse = await Auth.loginWithFacebook(response.accessToken);

    if (apiResponse.ok) {
      props.login(apiResponse.accessToken, apiResponse.refreshToken, apiResponse.user);
    }
    else{
      setLoading(false);
    }
  }

  const handleClick = () => {
    setLoading(true);
  };
  return (
    <div className={classes.wrapper}>
      <FacebookLogin
        appId="250801285850865"
        fields="name,email,picture"
        callback={responseFacebook}
        icon="fa-facebook"
        textButton="Iniciar con facebook"
        size='small'
        onClick={handleClick}
        isDisabled={loading}
      />
      {loading && <CircularProgress size={24} color='secondary' className={classes.circularProgress} />}
    </div >
  )
}
export default withRouter(FacebookLoginButton);