import { createContext } from "react";

export const AuthContext = createContext({
  authenticated: false,
  user: {},
  accessToken: "",
  refreshToken: "",
  login: () => {},
  logout: () => {}
});

export const AuthProvider = AuthContext.Provider;
export const AuthConsumer = AuthContext.Consumer;