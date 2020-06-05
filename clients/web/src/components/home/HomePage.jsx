import React from "react";
import { useSelector, useDispatch } from "react-redux";
import * as authenticationActions from "../../redux/actions/authenticationActions";
import HomePageAppHeader from "../home-page-app-header/HomePageAppHeader.jsx";

function HomePage() {
  const authenticated = useSelector(
    (state) => state.authentication.authenticated
  );
  const dispatch = useDispatch();

  const getAccessToken = () => {
    dispatch(authenticationActions.authenticate({ authenticated: true }));
  };

  return (
    <HomePageAppHeader
      authenticated={authenticated}
      getAccessToken={getAccessToken}
    />
  );
}

export default HomePage;
