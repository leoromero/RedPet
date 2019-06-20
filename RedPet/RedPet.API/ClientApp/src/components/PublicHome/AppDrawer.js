import React, { useState } from 'react';
import AppBar from '@material-ui/core/AppBar';
import CssBaseline from '@material-ui/core/CssBaseline';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import { IconButton, Button, Hidden, MenuList, MenuItem, Divider, ListItemText, Drawer } from '@material-ui/core';
import { RedPetIcon } from '../icons/RedPetIcon';
import { Link } from 'react-router-dom';
import Styles from './Styles';
import { withRouter } from 'react-router-dom';
import useOpen from '../../Hooks/useOpen';
import MoreIcon from '@material-ui/icons/MoreVert';

const AppDrawer = props => {

  const classes = Styles();
  const [activeLink, setActiveLink] = useState();
  const { isOpen: isDrawerOpen, toggle: toggleDrawer } = useOpen();

  const handleLinkClick = event => {
    setActiveLink(event.currentTarget.name);
    const element = document.getElementById(event.currentTarget.name)
    element.scrollIntoView({ behavior: 'smooth' });
    setTimeout(() => {
      toggleDrawer();
    }, 500);
  };

  const drawer = (
    <>
      <div className={classes.toolbar} />
      <MenuList>
        <>
          <MenuItem name="services" component={Link} to='/#services' onClick={handleLinkClick} button>
            <ListItemText primary='Servicios' />
          </MenuItem>
          <MenuItem component={Link} to='/register/Provider' onClick={toggleDrawer} button>
            <ListItemText primary='Trabaja con RedPet' />
          </MenuItem>
          <MenuItem component={Link} to='/register' onClick={toggleDrawer} button>
            <ListItemText primary='Registrate' />
          </MenuItem>
          <MenuItem component={Link} to='/login' onClick={toggleDrawer} button>
            <ListItemText primary='Iniciar Sesion' />
          </MenuItem>
        </>
      </MenuList>
      <Divider />
    </>
  );
  return (
    <div className={classes.toolbar}>
      <CssBaseline />
      <AppBar position="fixed" className={classes.appBar}>
        <Toolbar>
          <IconButton name="root" component={Link} to='/' onClick={handleLinkClick}>
            <RedPetIcon />
          </IconButton>
          <Hidden smDown>
            <Typography className={classes.title} variant="h6" noWrap>
              RedPet
              </Typography>
            <div className={classes.grow} />
            <Button name="services" variant="text" component={Link} to='/#services' color={activeLink == 'services' ? "secondary" : "secondary"} onClick={handleLinkClick} > Servicios </Button>
            <div className={classes.grow} />
            <Button name="workWithUs" variant="text" component={Link} to='/register/Provider' color='secondary'> Trabaja con RedPet </Button>

          </Hidden>
          <div className={classes.grow} />
          {
            props.location.pathname !== '/login' &&
            <Hidden mdDown>
            <Button variant='contained' color='secondary' component={Link} to='/login'>Iniciar Sesión</Button>
            </Hidden>  
          }
          <Hidden mdUp>
          <IconButton aria-haspopup="true" onClick={toggleDrawer}>
            <MoreIcon />
          </IconButton>
        </Hidden>
        </Toolbar>
      </AppBar>
      <Hidden mdUp>
        <Drawer
          className={classes.drawer}
          variant="temporary"
          open={isDrawerOpen}
          onClose={toggleDrawer}
          classes={{
            paper: classes.drawerPaper,
          }}
        >
          {drawer}
        </Drawer>
      </Hidden>
    </div>
  );
}

export default withRouter(AppDrawer);