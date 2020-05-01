import React from "react";

import classes from "./DrawerToggle.css";

/**
 * Component for the side drawer toolbar for mobile devices.
 * @param {*} props
 */
const drawerToggle = (props) => (
  <div className={classes.DrawerToggle} onClick={props.clicked}>
    <div></div>
    <div></div>
    <div></div>
  </div>
);

export default drawerToggle;
