import { Subject } from "rxjs";
import { Injectable } from "@angular/core";

import { Ingredient } from "../shared/ingredient.model";

@Injectable()
export class ShoppingListService {
  ingredientsChanged = new Subject<Ingredient[]>();
  startedEditing = new Subject<number>();

  private ingredients: Ingredient[] = [];

  /**
   * Method that sets/overrides the ingredients array with the recipes
   * passed as a parameter.
   * @param ingredients - Ingredient Array
   */
  setIngredients(ingredients: Ingredient[]) {
    this.ingredients = ingredients;
    this.ingredientsChanged.next(this.ingredients.slice());
  }

  /**
   * Method that adds a ingredient object to the recipes array
   * @param ingredient - Ingredient Object
   */
  addIngredient(ingredient: Ingredient) {
    this.ingredients.push(ingredient);
    this.ingredientsChanged.next(this.ingredients.slice());
  }

  /**
   * Method that returns all ingredients.
   */
  getIngredients() {
    return this.ingredients.slice();
  }

  /**
   * Method that gets a specific ingredient based on the index.
   * @param index - Index of ingredient
   */
  getIngredient(index: number) {
    return this.ingredients[index];
  }

  /**
   * Method that adds all ingredients from array to the shopping list.
   * @param ingredients - Ingredients array
   */
  addIngredients(ingredients: Ingredient[]) {
    this.ingredients.push(...ingredients);
    this.ingredientsChanged.next(this.ingredients.slice());
  }

  /**
   * Method that updates a current ingredient based on that ingredients
   * index.
   * @param index - Index of recipe
   * @param newIngredient - New ingredient to replace old one
   */
  updateIngredient(index: number, newIngredient: Ingredient) {
    this.ingredients[index] = newIngredient;
    this.ingredientsChanged.next(this.ingredients.slice());
  }

  /**
   * Method that deletes a specific ingredient by index.
   * @param index - Ingredient Index
   */
  deleteIngredient(index: number) {
    this.ingredients.splice(index, 1);
    this.ingredientsChanged.next(this.ingredients.slice());
  }
}
