import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";

import { Recipe } from "../recipe.model";
import { RecipeService } from "../recipe.service";

@Component({
  selector: "app-recipe-detail",
  templateUrl: "./recipe-detail.component.html",
  styleUrls: ["./recipe-detail.component.css"]
})
export class RecipeDetailComponent implements OnInit {
  recipe: Recipe;
  id: number;

  constructor(
    private recipeService: RecipeService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  /**
   * OnInit method that grabs the id param from URL and gets the recipe
   * associated with that id and stores it in an object variable.
   */
  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = +params["id"];
      this.recipe = this.recipeService.getRecipe(this.id);
    });
  }

  /**
   * Method that will add all ingredients from the recipes to the current
   * shopping list.
   */
  onAddToShoppingList() {
    this.recipeService.addIngredientsToSL(this.recipe.ingredients);
  }

  /**
   * Method that will navigate user to the edit page for the selected recipe
   */
  onEditRecipe() {
    this.router.navigate(["edit"], { relativeTo: this.route });
  }

  /**
   * Method that deletes the selected recipe, once deleted app
   * will automatically navigate user back to general recipes
   * page.
   */
  onDeleteRecipe() {
    this.recipeService.deleteRecipe(this.id);
    this.router.navigate(["/recipes"]);
  }
}
