import React, { Component, useContext } from "react";
import { BrowserRouter as AppRouter, Route, Switch } from "react-router-dom";
import LoginPage from "./Login/LoginPage";
import RegisterPage from "./Register/RegisterPage";
import PetPage from "./Pet/PetPage";
import { AuthContext } from "../contexts/AuthContext";
import HomePage from "./Home/HomePage";
import styles from "../styles/styles";
import PetsPage from "./Pet/PetsPage";
import PublicHome from "./PublicHome/PublicHome";
import PublicAppDrawer from "./PublicHome/AppDrawer";
import AppDrawer from "./AppBar/AppDrawer";
import { Grid } from "@material-ui/core";

const Router = (props) => {
  const { authenticated } = useContext(AuthContext);
  const classes = styles(props);
  return (
    <AppRouter>
      <>
        {props.children}
        {
          authenticated ?
            <AppDrawer />
            :
            <PublicAppDrawer />
        }
        <main className={!authenticated ? classes.main : classes.mainAuthenticated}>
          <Grid container item xs={12} className={!authenticated ? classes.contentWithoutPadding : classes.content}>
            <Switch>
              {
                !authenticated ? (
                  <>
                    <Route exact path="/" component={PublicHome} />
                    <Route path="/login" component={LoginPage} />
                    <Route exact path="/register/" component={RegisterPage} />
                    <Route path="/register/:role" component={RegisterPage} />
                  </>
                ) :
                  (
                    <>
                      <Route exact path="/" component={HomePage} />
                      <Route path="/pets" component={PetsPage} />
                      <Route path="/pet/new" component={PetPage} />
                      <Route path="/pet/:id" component={PetPage} />
                    </>
                  )
              }
              {/* <Route path="/meals/:userId" component={Meals} /> */}
              {/* <Route path="/meal/user/:userId" component={Meal} /> */}
              {/* <Route path="/meal/:id" component={Meal} /> */}
              {/* <Route path="/users" exact component={Users} /> */}
              {/* <Route path="/users/:id" component={User} /> */}

            </Switch>
          </Grid>
        </main>
      </>
    </AppRouter>
  );
}

export default Router;