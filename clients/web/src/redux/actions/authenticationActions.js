export function authenticate(authenticationResult) {
  return { type: "AUTHENTICATION_COMPLETE", authenticationResult };
}
