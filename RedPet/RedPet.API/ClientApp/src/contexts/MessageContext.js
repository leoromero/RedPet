import React from 'react';
import { withSnackbar } from 'notistack';

export const MessageContext = React.createContext();

const MessageProvider = (props) => {
 
  const showMessage = (message, type) => {
    props.enqueueSnackbar(message,{
      variant:type ? type : 'info'
    });
  }

  const { children } = props;
  
  return (
    <MessageContext.Provider
      value={showMessage}
    >
        {children}
    </MessageContext.Provider>
  );
};
export default withSnackbar(MessageProvider);