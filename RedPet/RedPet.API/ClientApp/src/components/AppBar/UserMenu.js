import React, { useContext } from 'react';
import { Menu, MenuItem } from '@material-ui/core';
import { AuthContext } from '../../contexts/AuthContext';

const UserMenu = (props) => {

  const { logout } = useContext(AuthContext);

  const signOut = () => {
    logout();
    props.onClose();
  };
  return (
    <Menu
      anchorEl={props.anchorEl}
      anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
      transformOrigin={{ vertical: 'top', horizontal: 'right' }}
      open={props.open}
      onClose={props.onClose}
      getContentAnchorEl={null}
    >
      <MenuItem onClick={props.onClose}>Perfil</MenuItem>
      <MenuItem onClick={props.onClose}>Mi Cuenta</MenuItem>
      <MenuItem onClick={signOut}>Cerrar sesión</MenuItem>
    </Menu>
  );
}

export default UserMenu;