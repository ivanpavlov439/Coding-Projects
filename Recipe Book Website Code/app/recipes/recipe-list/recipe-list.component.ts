import { Component, OnDestroy, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Subscription } from "rxjs";

import { Recipe } from "../recipe.model";
import { RecipeService } from "../recipe.service";

@Component({
  selector: "app-recipe-list",
  templateUrl: "./recipe-list.component.html",
  styleUrls: ["./recipe-list.component.css"]
})
export class RecipeListComponent implements OnInit, OnDestroy {
  recipes: Recipe[];
  subscription: Subscription;

  constructor(
    private recipeService: RecipeService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  /**
   * OnInit method that grabs all recipes from the recipe service.
   */
  ngOnInit() {
    this.subscription = this.recipeService.recipesChanged.subscribe(
      (recipes: Recipe[]) => {
        this.recipes = recipes;
      }
    );
    this.recipes = this.recipeService.getRecipes();
  }

  /**
   * Method that will navigate users to a new page when they
   * want to create new recipe.
   */
  onNewRecipe() {
    this.router.navigate(["new"], { relativeTo: this.route });
  }

  /**
   * OnDestroy method that unsubscribes from the subscription used in the
   * OnInit method.
   */
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
