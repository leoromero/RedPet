import React, { Component } from "react";
import { AuthProvider } from "../contexts/AuthContext";
import AuthHelper from "../helpers/Auth";
 
class Auth extends Component {
  state = {
    authenticated: false,
    user: {
      id: null,
      username: "",
      role: "Visitor"
    },
    accessToken: "",
    refreshToken: ""
  };

componentDidMount = () => {
  let user = AuthHelper.retrieveUser();
  if(user){
    let accessToken = AuthHelper.retrieveAccessToken();
    let refreshToken = AuthHelper.retrieveRefreshToken();

    this.setState({
      authenticated:true,
      user: user,
      accessToken: accessToken,
      refreshToken: refreshToken
    });
  }
};

  login = (accessToken, refreshToken, user) => {
    this.setSession(accessToken, refreshToken, user);
  };

  logout = () => {
    this.setState({
      authenticated: false,
      user: {
        id: null,
        username: "",
        role: "Visitor"
      },
      accessToken: "",
      refreshToken: ""
    });
    AuthHelper.logout();
  };

  setSession(accessToken, refreshToken, user) { 
    this.setState({
      authenticated: true,
      accessToken: accessToken,
      refreshToken: refreshToken,
      user
    });
  }

  render() {
    const authProviderValue = {
      ...this.state,
      login: this.login,
      logout: this.logout
    };    
     return(
      <AuthProvider value={authProviderValue}>
        {this.props.children}
      </AuthProvider>
     );
  }
}

export default Auth;