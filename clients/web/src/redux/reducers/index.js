import { combineReducers } from "redux";
import authentication from "./authenticationReducer";

const rootRecucer = combineReducers({
  authentication,
});

export default rootRecucer;
