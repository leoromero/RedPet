import React, { useState, useContext } from 'react';
import { AppBar, Toolbar, Typography, Badge, IconButton, Menu, MenuItem, Button } from '@material-ui/core';
import AccountCircle from '@material-ui/icons/AccountCircle';
import MailIcon from '@material-ui/icons/Mail';
import NotificationsIcon from '@material-ui/icons/Notifications';
import MoreIcon from '@material-ui/icons/MoreVert';
import { withStyles } from '@material-ui/core/styles';
import { RedPetIcon } from '../icons/RedPetIcon';
import { DayCareIcon } from '../icons/DayCareIcon';
import { WalkingIcon } from '../icons/WalkingIcon';
import { GroomingIcon } from '../icons/GroomingIcon';
import UserMenu from './UserMenu';
import MobileMenu from './MobileMenu';
import Can from '../Can';
import { AuthContext } from '../../contexts/AuthContext';
import { Link } from 'react-router-dom';
const styles = theme => ({
  root: {
    width: '100%',
  },
  grow: {
    flexGrow: 1,
  },
  menuButton: {
    marginLeft: -12,
    marginRight: 20,
  },
  title: {
    display: 'none',
    [theme.breakpoints.up('sm')]: {
      display: 'block',
      marginLeft: 10
    },
  },
  sectionDesktop: {
    display: 'none',
    [theme.breakpoints.up('md')]: {
      display: 'flex',
    },
  },
  sectionMobile: {
    display: 'flex',
    [theme.breakpoints.up('md')]: {
      display: 'none',
    },
  },
});

const ApplicationBar = (props) => {
  const { authenticated, user } = useContext(AuthContext)
  const [anchorEl, setAnchorEl] = useState(null);
  const [mobileAnchorEl, setMobileAnchorEl] = useState(null);
  const isMenuOpen = Boolean(anchorEl);
  const isMobileMenuOpen = Boolean(mobileAnchorEl);
  const { classes } = props;


  const handleUserMenuOpen = event => {
    setAnchorEl(event.currentTarget);
  };
  const handleMobileMenuOpen = event => {
    setMobileAnchorEl(event.currentTarget);
  };
  const handleMenuClose = () => {
    setAnchorEl(null);
    handleMobileMenuClose();
  };
  const handleMobileMenuClose = () => {
    setMobileAnchorEl(null);
  };
  return (
    <div className={classes.root}>
      <AppBar position="static">
        <Toolbar>
          <IconButton >
            <RedPetIcon />
          </IconButton>
          <Typography className={classes.title} variant="h6" noWrap>
            RedPet
              </Typography>
          <div className={classes.grow} />
          {!authenticated ?
            <Button component={Link} to='/login'>Iniciar Sesión</Button>
            :
            <>
              <div className={classes.sectionDesktop}>
                <IconButton>
                  <GroomingIcon />
                </IconButton>
                <IconButton>
                  <WalkingIcon />
                </IconButton>
                <IconButton >
                  <DayCareIcon />
                </IconButton>
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
                  aria-owns={isMenuOpen ? 'material-appbar' : undefined}
                  aria-haspopup="true"
                  onClick={handleUserMenuOpen}
                >
                  <AccountCircle />
                </IconButton>
              </div>
              <div className={classes.sectionMobile}>
                <IconButton aria-haspopup="true" onClick={handleMobileMenuOpen}>
                  <MoreIcon />
                </IconButton>
              </div>
            </>
          }
        </Toolbar>
      </AppBar>
      <UserMenu
        open={isMenuOpen}
        onClose={handleMenuClose}
        anchorEl={anchorEl}
      ></UserMenu>
      <MobileMenu
        open={isMobileMenuOpen}
        onClose={handleMobileMenuClose}
        anchorEl={mobileAnchorEl}
        openUserMenu={handleUserMenuOpen}
      ></MobileMenu>
    </div>
  );
};

export default withStyles(styles)(ApplicationBar);