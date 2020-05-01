import React from "react";

import classes from "./Backdrop.css";

/**
 * Bacdrop compone that will darken the screen when certain
 * situations occur within the website.
 * @param {*} props
 */
const backdrop = (props) =>
  props.show ? (
    <div className={classes.Backdrop} onClick={props.clicked}></div>
  ) : null;

export default backdrop;
