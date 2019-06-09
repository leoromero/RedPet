import React from 'react';
import { Menu, MenuItem, IconButton, Badge } from '@material-ui/core';
import AccountCircle from '@material-ui/icons/AccountCircle';
import MailIcon from '@material-ui/icons/Mail';
import NotificationsIcon from '@material-ui/icons/Notifications';

const MobileMenu = (props) =>
  <Menu
    anchorEl={props.anchorEl}
    anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
    transformOrigin={{ vertical: 'top', horizontal: 'right' }}
    open={props.open}
    onClose={props.onClose}
    getContentAnchorEl={null}
  >
    <MenuItem onClick={props.onClose}>
      <IconButton>
        <Badge badgeContent={4} color="secondary">
          <MailIcon />
        </Badge>
      </IconButton>
      <p>Mensajes</p>
    </MenuItem>
    <MenuItem onClick={props.onClose}>
      <IconButton>
        <Badge badgeContent={11} color="secondary">
          <NotificationsIcon />
        </Badge>
      </IconButton>
      <p>Notificaciones</p>
    </MenuItem>
    <MenuItem onClick={props.openUserMenu}>
      <IconButton>
        <AccountCircle />
      </IconButton>
      <p>Perfil</p>
    </MenuItem>
  </Menu>

export default MobileMenu;