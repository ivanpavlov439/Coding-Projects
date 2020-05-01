import React from "react";

import classes from "./Spinner.css";

// Basic spinner component to use while website does server requests
const spinner = () => <div className={classes.Loader}>Loading...</div>;

export default spinner;
