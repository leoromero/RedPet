import React, { useState } from 'react';
import AppBar from '@material-ui/core/AppBar';
import CssBaseline from '@material-ui/core/CssBaseline';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import { IconButton, Button, Hidden } from '@material-ui/core';
import { RedPetIcon } from '../icons/RedPetIcon';
import { Link } from 'react-router-dom';
import Styles from './Styles';
import { withRouter } from 'react-router-dom';

const AppDrawer = props => {

  const classes = Styles();
  const [ activeLink, setActiveLink ] = useState();

  const handleLinkClick = event => {
    setActiveLink(event.currentTarget.name);
    const element = document.getElementById(event.currentTarget.name)
    element.scrollIntoView({behavior:'smooth'});
  };
  
  return (
    <div className={classes.appBar}>
      <CssBaseline />
      <AppBar position="fixed">
        <Toolbar>
          <IconButton name="root" component={Link} to='/' onClick={handleLinkClick}>
            <RedPetIcon />
          </IconButton>
          <Hidden smDown>
            <Typography className={classes.title} variant="h6" noWrap>
              RedPet
              </Typography>
            <div className={classes.grow} />
            <Button name="services" variant="text" component={Link} to='/#services' color={activeLink == 'services'? "secondary" : "secondary"}  onClick={handleLinkClick} > Servicios </Button>
            <div className={classes.grow} />
            <Button name="workWithUs" variant="text" component={Link} to='/register/Provider' color='secondary'> Trabaja con RedPet </Button>

          </Hidden>
          <div className={classes.grow} />
          {
            props.location.pathname !== '/login' &&
            <Button variant='contained' color='secondary' component={Link} to='/login'>Iniciar Sesión</Button>
          }
        </Toolbar>
      </AppBar>
    </div>
  );
}

export default withRouter(AppDrawer);