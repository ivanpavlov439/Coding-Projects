import React from "react";

import classes from "./Order.css";

/**
 * This component makes the order that the user has made and
 * displays all the info regarding a specific order to the
 * authenticated user.
 * @param {*} props
 */
const order = (props) => {
  const ingredients = [];

  // Getting all the ingredients from the props and storing it
  // in its own local array.
  for (let ingredientName in props.ingredients) {
    ingredients.push({
      name: ingredientName,
      amount: props.ingredients[ingredientName],
    });
  }

  // Mapping all the ingredients in a span element to be nicely displayed
  // to the user.
  const ingredientOutput = ingredients.map((ig) => {
    return (
      <span
        style={{
          textTransform: "capitalize",
          display: "inline-block",
          margin: "0 8px",
          border: "1px solid #ccc",
          padding: "5px",
        }}
        key={ig.name}
      >
        {ig.name} ({ig.amount})
      </span>
    );
  });

  return (
    <div className={classes.Order}>
      <p>Name: {props.orderData.name}</p>
      <p>Email: {props.orderData.email}</p>
      <p>Country: {props.orderData.country}</p>
      <p>
        Street: {props.orderData.street}, {props.orderData.zipCode}
      </p>
      <p>Delivery Method: {props.orderData.deliveryMethod}</p>
      <p>Ingredients: {ingredientOutput}</p>
      <p>
        Price: <strong>CAD {Number.parseFloat(props.price).toFixed(2)}</strong>
      </p>
    </div>
  );
};

export default order;
