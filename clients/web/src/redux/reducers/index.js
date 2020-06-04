import { combinedReducers } from "redux";
import authentication from "./authenticationReducer";

const rootRecucer = combinedReducers({
  authentication,
});

export default rootRecucer;
