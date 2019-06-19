import { IconButton } from '@material-ui/core';
import { Close } from '@material-ui/icons';
import React from 'react';
import { SnackbarProvider } from 'notistack';

const Messages = (props) => {
   
    return (
        <SnackbarProvider action={ () =>
            <IconButton key="close" color="inherit">
              <Close />
            </IconButton>
        }
          anchorOrigin={{
            vertical: 'bottom',
            horizontal: 'right',
        }}>
        {props.children}
        </SnackbarProvider>
    );
};

export default Messages;