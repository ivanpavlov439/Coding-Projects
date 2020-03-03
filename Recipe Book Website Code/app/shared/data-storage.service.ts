import { Injectable } from "@angular/core";
import { map, tap } from "rxjs/operators";
import { HttpClient } from "@angular/common/http";

import { RecipeService } from "../recipes/recipe.service";
import { Recipe } from "../recipes/recipe.model";
import { ShoppingListService } from "../shopping-list/shopping-list.service";
import { Ingredient } from "./ingredient.model";
import { User } from "../auth/user.model";
import { AuthService } from "../auth/auth.service";

@Injectable({ providedIn: "root" })
export class DataStorageService {

  constructor(
    private http: HttpClient,
    private recipeService: RecipeService,
    private slService: ShoppingListService,
    private authService: AuthService
  ) {}

  /**
   * Method that will store all recipes onto the DB using restful API
   */
  storeRecipes() {
    const recipes = this.recipeService.getRecipes();
    this.http
      .put("https://recipe-book-292e7.firebaseio.com/" + this.authService.userSubject.value.id + "/recipes.json", recipes)
      .subscribe(response => {
        console.log(response);
      });
  }

  /**
   * Method that fetches all recipes from the DB and stores it in an
   * observable for the application to subscribe to later on.
   */
  fetchRecipes() {
    return this.http
      .get<Recipe[]>("https://recipe-book-292e7.firebaseio.com/" + this.authService.userSubject.value.id + "/recipes.json")
      .pipe(
        map(recipes => {
          return recipes.map(recipe => {
            return {
              ...recipe,
              ingredients: recipe.ingredients ? recipe.ingredients : []
            };
          });
        }),
        tap(recipes => {
          this.recipeService.setRecipes(recipes);
        })
      );
  }

  /**
   * Method that will store all shopping list items onto the DB using restful API
   */
  storeShoppingList() {
    const ingredients = this.slService.getIngredients();
    this.http
      .put(
        "https://recipe-book-292e7.firebaseio.com/" + this.authService.userSubject.value.id + "/shoppingList.json",
        ingredients
      )
      .subscribe(response => {
        console.log(response);
      });
  }

  /**
   * Method that fetches all shopping list ingredients from the DB
   * and stores it in an observable for the application to subscribe to later on.
   */
  fetchShoppingList() {
    return this.http
      .get<Ingredient[]>(
        "https://recipe-book-292e7.firebaseio.com/" + this.authService.userSubject.value.id + "/shoppingList.json"
      )
      .subscribe(ingredients => {
        this.slService.setIngredients(ingredients);
      });
  }
}
