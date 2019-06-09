import React, { Component, useContext } from "react";
import { BrowserRouter as AppRouter, Route, Switch } from "react-router-dom";
import LoginPage from "./Login/LoginPage";
import PetPage from "./Pet/PetPage";
import { AuthContext } from "../contexts/AuthContext";
import HomePage from "./Home/HomePage";
import styles from "../styles/styles";
import PetsPage from "./Pet/PetsPage";
import PublicHome from "./PublicHome/PublicHome";
import PublicAppDrawer from "./PublicHome/AppDrawer";
import AppDrawer from "./AppBar/AppDrawer";

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
        <Switch>
          <main className={authenticated && classes.main}>
            <div className={classes.toolbar}></div>
            <div className={authenticated && classes.content}>
              {
                !authenticated ? (
                  <>
                    <Route exact path="/" component={PublicHome} />
                    <Route path="/login" component={LoginPage} />
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

            </div>
          </main>
        </Switch>
      </>
    </AppRouter>
  );
}

export default Router;