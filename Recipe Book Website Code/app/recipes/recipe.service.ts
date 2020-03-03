import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

import { Ingredient } from "../shared/ingredient.model";
import { ShoppingListService } from "../shopping-list/shopping-list.service";
import { Recipe } from "./recipe.model";

@Injectable()
export class RecipeService {
  recipesChanged = new Subject<Recipe[]>();

  private recipes: Recipe[] = [];

  constructor(private shoppingListService: ShoppingListService) {}

  /**
   * Method that sets/overrides the recipe array with the recipes
   * passed as a parameter.
   * @param recipes - Recipe Array
   */
  setRecipes(recipes: Recipe[]) {
    this.recipes = recipes;
    this.recipesChanged.next(this.recipes.slice());
  }

  /**
   * Method that returns all recipes.
   */
  getRecipes() {
    return this.recipes.slice();
  }

  /**
   * Method that gets a specific recipe based on the index.
   * @param index - Index of recipe
   */
  getRecipe(index: number) {
    return this.recipes[index];
  }

  /**
   * Method that adds all the ingredients from the array to the shopping list.
   * @param ingredients - Ingredient array
   */
  addIngredientsToSL(ingredients: Ingredient[]) {
    this.shoppingListService.addIngredients(ingredients);
  }

  /**
   * Method that adds a recipe object to the recipes array
   * @param recipe - Recipe Object
   */
  addRecipe(recipe: Recipe) {
    this.recipes.push(recipe);
    this.recipesChanged.next(this.recipes.slice());
  }

  /**
   * Method that updates a current recipe based on that recipes
   * index.
   * @param index - Index of recipe
   * @param newRecipe - New Recipe to replace old one
   */
  updateRecipe(index: number, newRecipe: Recipe) {
    this.recipes[index] = newRecipe;
    this.recipesChanged.next(this.recipes.slice());
  }

  /**
   * Method that deletes a specific recipe by index.
   * @param index - Recipe Index
   */
  deleteRecipe(index: number) {
    this.recipes.splice(index, 1);
    this.recipesChanged.next(this.recipes.slice());
  }
}
