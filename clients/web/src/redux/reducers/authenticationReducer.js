export default function authenticationReducer(state = [], action) {
  switch (action.type) {
    case "AUTHENTICATION_COMPLETE":
      return [...state, { ...action.authenticationResult }];

    default:
      return state;
  }
}
