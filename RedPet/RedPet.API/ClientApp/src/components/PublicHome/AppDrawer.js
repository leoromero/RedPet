import React, { useContext, useState } from 'react';
import AppBar from '@material-ui/core/AppBar';
import CssBaseline from '@material-ui/core/CssBaseline';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import { IconButton, Button, Hidden } from '@material-ui/core';
import { RedPetIcon } from '../icons/RedPetIcon';
import { AuthContext } from '../../contexts/AuthContext';
import { Link } from 'react-router-dom';
import Styles from './Styles';
import { useTheme } from '@material-ui/styles';

const AppDrawer = props => {

  const classes = Styles();
  const { authenticated, user } = useContext(AuthContext)
  const [ activeLink, setActiveLink ] = useState();
  const theme = useTheme();

  const handleLinkClick = event => {
    setActiveLink(event.currentTarget.id);
  };

  return (
    <div className={classes.root}>
      <CssBaseline />
      <AppBar position="fixed" className={classes.appBar}>
        <Toolbar>
          <IconButton component={Link} to='/' onClick={handleLinkClick}>
            <RedPetIcon />
          </IconButton>
          <Hidden smDown>
            <Typography className={classes.title} variant="h6" noWrap>
              RedPet
              </Typography>
            <div className={classes.grow} />
            <Button id="services" variant="text" component={Link} to='/#services' color={activeLink == 'services'? "secondary" : "default"} onClick={handleLinkClick} > Servicios </Button>

          </Hidden>
          <div className={classes.grow} />
          <Button component={Link} to='/login'>Iniciar Sesión</Button>

        </Toolbar>
      </AppBar>
    </div>
  );
}

export default AppDrawer;