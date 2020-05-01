import React from "react";

import classes from "./Button.css";

/**
 * Basic component that creates a button element that is used within
 * the website.
 * @param {*} props
 */
const button = (props) => (
  <button
    disabled={props.disabled}
    className={[classes.Button, classes[props.btnType]].join(" ")}
    onClick={props.clicked}
  >
    {props.children}
  </button>
);

export default button;
