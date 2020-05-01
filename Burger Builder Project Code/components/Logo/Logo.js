import React from "react";

import burgerLogo from "../../assets/images/burger-logo.png";
import classes from "./Logo.css";

/**
 * This component is used to display the logo of the website in certain
 * locations.
 * @param {*} props
 */
const logo = (props) => (
  <div className={classes.Logo} style={{ height: props.height }}>
    <img src={burgerLogo} alt="MyBurger" />
  </div>
);

export default logo;
