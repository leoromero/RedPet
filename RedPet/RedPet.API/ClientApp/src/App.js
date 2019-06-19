import React, { Component } from 'react';
import MessageProvider from './contexts/MessageContext';
import ApplicationBar from './components/AppBar/ApplicationBar';
import { Paper, createMuiTheme, CssBaseline, Button } from '@material-ui/core';
import Messages from './components/Messages';
import { ThemeProvider } from '@material-ui/styles';
import dateUtils from '@date-io/date-fns';
import esLocale from 'date-fns/locale/es'
import Router from './components/Router';
import Auth from './components/Auth';
import AppDrawer from './components/AppBar/AppDrawer';
import { grey, pink } from '@material-ui/core/colors';
import { MuiPickersUtilsProvider } from '@material-ui/pickers';

const styles = {
  rootPaper: {
    display: 'flex',
    flexDirection: 'column',
    flex: 1
  }
}

const theme = createMuiTheme({
  palette: {
    primary: {
      main: grey[800],
    },
    secondary: {
      main: pink[500]
    },
    text: {
      primary: "#fff",
      secondary: "#000"
    }
  },
  overrides: {
    MuiPaper: {
      root: {
        color: "#000"
      },
    },
    MuiInput: {
      root: {
        color: "#000"
      },
    },
  }
});

export default class App extends Component {

  render() {
    return (
      <MuiPickersUtilsProvider utils={dateUtils} locale={esLocale}>
        <ThemeProvider theme={theme}>
          <Auth>
            <Messages>
              <MessageProvider>
                <Paper style={styles.rootPaper}>
                  <Router>
                  </Router>
                </Paper>
              </MessageProvider>
            </Messages>
          </Auth>
        </ThemeProvider>
      </MuiPickersUtilsProvider>
    );
  }
}
