import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";

import * as actions from "../../../store/actions/index";

/**
 * Class based component that handles the logout of a user
 */
class Logout extends Component {
  componentDidMount() {
    this.props.onLogout();
  }

  render() {
    // Redirects the user back to main page after logging out
    return <Redirect to="/" />;
  }
}

const mapDispatchToProps = (dispatch) => {
  return {
    onLogout: () => dispatch(actions.logout()),
  };
};

export default connect(null, mapDispatchToProps)(Logout);
