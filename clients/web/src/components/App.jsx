import React from "react";
import { Route, Switch } from "react-router";
import HomePage from "./home/HomePage.jsx";

function App() {
  return (
    <div className="App">
      <Switch>
        <Route exact path="/" render={() => <HomePage />} />
      </Switch>
    </div>
  );
}

export default App;
