import React from "react";
import { NavLink } from "react-router-dom";

import classes from "./NavigationItem.css";

/**
 * This component creates a single navigation item using the
 * react router dom package for routing purposes.
 * @param {*} props
 */
const navigationItem = (props) => (
  <li className={classes.NavigationItem}>
    <NavLink
      to={props.link}
      exact={props.exact}
      activeClassName={classes.active}
    >
      {props.children}
    </NavLink>
  </li>
);

export default navigationItem;
