import React from "react";

import classes from "./BuildControl.css";

/**
 * This component creates a single build control for a specific burger ingredient
 * @param {*} props - The props that this component wll use
 */
const buildControl = (props) => (
  <div className={classes.BuildControl}>
    <div className={classes.Label}>{props.label}</div>
    <button
      className={classes.Less}
      onClick={props.removed}
      disabled={props.disabled}
    >
      -
    </button>
    {props.ingredients}
    <button className={classes.More} onClick={props.added}>
      +
    </button>
  </div>
);

export default buildControl;
