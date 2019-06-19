import React, { useContext, useState } from 'react';
import Drawer from '@material-ui/core/Drawer';
import AppBar from '@material-ui/core/AppBar';
import CssBaseline from '@material-ui/core/CssBaseline';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import MenuItem from '@material-ui/core/MenuItem';
import MailIcon from '@material-ui/icons/Mail';
import NotificationsIcon from '@material-ui/icons/Notifications';
import MoreIcon from '@material-ui/icons/MoreVert';
import { IconButton, Button, Badge, Hidden, Collapse, ListItemIcon, ListItemText, MenuList } from '@material-ui/core';
import { RedPetIcon } from '../icons/RedPetIcon';
import { GroomingIcon } from '../icons/GroomingIcon';
import { WalkingIcon } from '../icons/WalkingIcon';
import { DayCareIcon } from '../icons/DayCareIcon';
import { AccountCircle, Store, Pets, Settings } from '@material-ui/icons';
import { AuthContext } from '../../contexts/AuthContext';
import { Link } from 'react-router-dom';
import useOpen from '../../Hooks/useOpen';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import UserMenu from './UserMenu';
import Styles from './Styles';

const AppDrawer = props => {

  const classes = Styles();
  const { authenticated, user } = useContext(AuthContext)
  const [mobileAnchorEl, setMobileAnchorEl] = useState(null);
  const [anchorEl, setAnchorEl] = useState(null);
  const isMobileMenuOpen = Boolean(mobileAnchorEl);
  const isUserMenuOpen = Boolean(anchorEl);
  const { isOpen: isServicesOpen, toggle: toggleServices } = useOpen();

  const handleUserMenuOpen = event => {
    setAnchorEl(event.currentTarget);
  };
  const handleMobileMenuOpen = event => {
    setMobileAnchorEl(event.currentTarget);
  };
  const handleMobileMenuClose = () => {
    setMobileAnchorEl(null);
  };
  const handleUserMenuClose = () => {
    setAnchorEl(null);
  };

  const drawer = (
    <>
    <div className={classes.toolbar} />
      <MenuList>
        <Hidden mdUp>
          <MenuItem component={Link} button>
            <ListItemIcon > <AccountCircle /></ListItemIcon>
            <ListItemText primary='Perfil' />
          </MenuItem>
          <MenuItem component={Link} button>
            <ListItemIcon> <MailIcon /></ListItemIcon>
            <ListItemText primary='Mensajes' />
          </MenuItem>
          <MenuItem component={Link} button>
            <ListItemIcon> <NotificationsIcon /></ListItemIcon>
            <ListItemText primary='Notificaciones' />
          </MenuItem>
        </Hidden>

        {user.role == 'Customer' &&
          <>
            <MenuItem component={Link} to='/pets' button>
              <ListItemIcon> <Pets /></ListItemIcon>
              <ListItemText primary='Mascotas' />
            </MenuItem>
            <MenuItem component={Link} button>
              <ListItemIcon> <Pets /></ListItemIcon>
              <ListItemText primary='Reservas' />
            </MenuItem>
            <MenuItem component={Link} button onClick={toggleServices}>
              <ListItemIcon>
                <Store />
              </ListItemIcon>
              <ListItemText primary="Servicios" />
              {isServicesOpen ? <ExpandLess /> : <ExpandMore />}
            </MenuItem>
            <Collapse in={isServicesOpen} timeout="auto" unmountOnExit>
              <MenuList component="div" disablePadding>
                <MenuItem component={Link} button className={classes.nested}>
                  <ListItemIcon> <GroomingIcon /></ListItemIcon>
                  <ListItemText primary='Peluqueria' />
                </MenuItem>
                <MenuItem component={Link} button className={classes.nested}>
                  <ListItemIcon> <WalkingIcon /></ListItemIcon>
                  <ListItemText primary='Paseos' />
                </MenuItem>
                <MenuItem component={Link} button className={classes.nested}>
                  <ListItemIcon> <DayCareIcon /></ListItemIcon>
                  <ListItemText primary='Guarderia' />
                </MenuItem>
                <MenuItem component={Link} button className={classes.nested}>
                  <ListItemIcon> <DayCareIcon /></ListItemIcon>
                  <ListItemText primary='Hospedaje' />
                </MenuItem>
              </MenuList>
            </Collapse>
          </>
        }
        {user.role == 'Admin' &&
          <MenuItem component={Link} to='/admin' button>
            <ListItemIcon> <Settings /></ListItemIcon>
            <ListItemText primary='Admin' />
          </MenuItem>
        }
      </MenuList>
      <Divider />
    </>
  );
  return (
    <div className={classes.toolbar}>
      <CssBaseline />
      <AppBar position="fixed" className={classes.appBar}>
        <Toolbar>
          <IconButton component={Link} to='/'>
            <RedPetIcon />
          </IconButton>
          <Hidden smDown>
            <Typography className={classes.title} variant="h6" noWrap>
              RedPet
              </Typography>
          </Hidden>
          <div className={classes.grow} />
          {!authenticated ?
            <Button component={Link} to='/login'>Iniciar Sesión</Button>
            :
            <>
              <Hidden smDown >
                <IconButton>
                  <Badge badgeContent={4} color="secondary">
                    <MailIcon />
                  </Badge>
                </IconButton>
                <IconButton>
                  <Badge badgeContent={17} color="secondary">
                    <NotificationsIcon />
                  </Badge>
                </IconButton>
                <IconButton
                  aria-owns='material-appbar'
                  aria-haspopup="true"
                  onClick={handleUserMenuOpen}
                >
                  <AccountCircle />
                </IconButton>
              </Hidden>
              <Hidden mdUp>
                <IconButton aria-haspopup="true" onClick={handleMobileMenuOpen}>
                  <MoreIcon />
                </IconButton>
              </Hidden>
            </>
          }
        </Toolbar>
      </AppBar>
      {authenticated && (
        <>
          <Hidden smDown>
            <Drawer
              className={classes.drawer}
              variant="permanent"
              classes={{
                paper: classes.drawerPaper,
              }}
            >
              {drawer}
            </Drawer>
          </Hidden>

          <Hidden mdUp>
            <Drawer
              className={classes.drawer}
              variant="temporary"
              open={isMobileMenuOpen}
              onClose={handleMobileMenuClose}
              classes={{
                paper: classes.drawerPaper,
              }}
            >
              {drawer}
            </Drawer>
          </Hidden>
        </>
      )}
      <UserMenu
        open={isUserMenuOpen}
        onClose={handleUserMenuClose}
        anchorEl={anchorEl}
      ></UserMenu>

    </div>
  );
}

export default AppDrawer;