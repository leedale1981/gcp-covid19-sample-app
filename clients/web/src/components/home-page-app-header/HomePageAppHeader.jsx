import React from "react";
import { Typography, Divider, Button } from "@material-ui/core";
import PropTypes from "prop-types";
import "./HomePageAppHeader.css";

function HomePageAppHeader(props) {
  return (
    <header className="App-header">
      <Typography variant="h2">COVID19 Stats Sample App</Typography>
      <Divider />
      <Button
        variant="contained"
        onClick={props.getAccessToken}
        style={
          props.authenticated
            ? { backgroundColor: "green" }
            : { backgroundColor: "white" }
        }
      >
        {props.authenticated ? "Logged In" : "Login"}
      </Button>
    </header>
  );
}

HomePageAppHeader.propTypes = {
  getAccessToken: PropTypes.func.isRequired,
  authenticated: PropTypes.bool.isRequired,
};

export default HomePageAppHeader;
