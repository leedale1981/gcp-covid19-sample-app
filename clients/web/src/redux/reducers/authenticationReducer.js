export default function authenticationReducer(
  state = { authenticated: false },
  action
) {
  switch (action.type) {
    case "AUTHENTICATION_COMPLETE":
      return {
        ...state,
        authenticated: action.authenticationResult.authenticated,
      };

    default:
      return state;
  }
}
