import React from "react";

import classes from "./Burger.css";
import BurgerIngredient from "./BurgerIngredient/BurgerIngredient";

/**
 * This component displays an image of the burger itself to the user
 * depending on the ingredients that the user has chosen.
 * @param {*} props - The props that this component will need to use
 */
const burger = (props) => {
  // Getting all ingredients from the props
  let transformedIngredients = Object.keys(props.ingredients)
    .map((igKey) => {
      // Returning a copy of the original array so that data is always
      // up to date.
      return [...Array(props.ingredients[igKey])].map((_, i) => {
        return <BurgerIngredient key={igKey + i} type={igKey} />;
      });
    })
    .reduce((arr, el) => {
      return arr.concat(el);
    }, []);

  // Checks to see if the user has put any ingredients
  if (transformedIngredients.length === 0) {
    transformedIngredients = <p>Please start adding ingredients!</p>;
  }
  return (
    <div className={classes.Burger}>
      <BurgerIngredient type="bread-top" />
      {transformedIngredients}
      <BurgerIngredient type="bread-bottom" />
    </div>
  );
};

export default burger;
