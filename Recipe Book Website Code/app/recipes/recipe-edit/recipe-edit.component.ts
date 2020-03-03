import { Component, OnInit, Input } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { FormArray, FormControl, FormGroup, Validators } from "@angular/forms";
import { Observable } from "rxjs";
import { finalize } from "rxjs/operators";
import {
  AngularFireStorage,
  AngularFireStorageReference,
  AngularFireUploadTask
} from "angularfire2/storage";

import { RecipeService } from "../recipe.service";
import { Recipe } from "../recipe.model";

@Component({
  selector: "app-recipe-edit",
  templateUrl: "./recipe-edit.component.html",
  styleUrls: ["./recipe-edit.component.css"]
})
export class RecipeEditComponent implements OnInit {
  //Declaring all variables needed
  @Input() recipe: Recipe;
  downloadUrl: Observable<any>;
  imageUrl = "";
  id: number;
  ref: AngularFireStorageReference;
  task: AngularFireUploadTask;
  uploadProgress: Observable<number>;
  editMode = false;
  recipeForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private recipeService: RecipeService,
    private router: Router,
    private afStorage: AngularFireStorage
  ) {}

  /**
   * OnInit method that initializes the form and grabs
   * route parameters and stores them in variables.
   */
  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = +params["id"];
      this.editMode = params["id"] != null;

      if (this.editMode) {
        this.imageUrl = this.recipeService.getRecipe(this.id).imagePath;
      }

      this.initForm();
    });
  }

  /**
   * Method that will upload all recipe pictures to firebase server and
   * keep track of what the download url is for each picture.
   */
  upload(event) {
    const uploadId = Math.random()
      .toString(36)
      .substring(2);
    this.ref = this.afStorage.ref(uploadId);
    this.task = this.ref.put(event.target.files[0]);
    this.uploadProgress = this.task.percentageChanges();
    this.task
      .snapshotChanges()
      .pipe(
        finalize(() => {
          this.ref.getDownloadURL().subscribe(downloadURL => {
            this.imageUrl = downloadURL;
            console.log(this.imageUrl);
          });
        })
      )
      .subscribe();
  }

  /**
   * Method that is called when the form is submitted. Depending
   * on the edit mode, it will either update a recipe, or add an
   * entirely new one.
   */
  onSubmit() {
    if (this.editMode) {
      this.recipeForm.value.imagePath = this.imageUrl;
      this.recipeService.updateRecipe(this.id, this.recipeForm.value);
    } else {
      this.recipeForm.value.imagePath = this.imageUrl;
      this.recipeService.addRecipe(this.recipeForm.value);
    }
    this.onCancel();
  }

  /**
   * Method that navigates user back one route if they cancel
   * the edit mode.
   */
  onCancel() {
    this.router.navigate(["../"], { relativeTo: this.route });
  }

  /**
   * Method that will add 2 empty form control elements so
   * that the user can add a new ingredient.
   */
  onAddIngredient() {
    (<FormArray>this.recipeForm.get("ingredients")).push(
      new FormGroup({
        name: new FormControl(null, Validators.required),
        amount: new FormControl(null, [
          Validators.required,
          Validators.pattern(/^[1-9]+[0-9]*$/)
        ])
      })
    );
  }

  /**
   * Method that deletes an ingredient from a recipe at a specific index.
   * @param index - Index of ingredient
   */
  onDeleteIngredient(index: number) {
    (<FormArray>this.recipeForm.get("ingredients")).removeAt(index);
  }

  /**
   * A getter method to get all the ingredients from the form.
   */
  get controls() {
    return (<FormArray>this.recipeForm.get("ingredients")).controls;
  }

  /**
   * Private method that initializes the form by using reactive forms.
   */
  private initForm() {
    let recipeName = "";
    let recipeImagePath = "";
    let recipeDescription = "";
    const recipeIngredients = new FormArray([]);

    //Checks to see if user selected a pre-existing recipe, if
    //they did this block will preload the form with that recipes info
    if (this.editMode) {
      this.recipe = this.recipeService.getRecipe(this.id);
      recipeName = this.recipe.name;
      recipeImagePath = this.recipe.imagePath;
      recipeDescription = this.recipe.description;
      if (this.recipe["ingredients"]) {
        for (const ingredient of this.recipe.ingredients) {
          recipeIngredients.push(
            new FormGroup({
              name: new FormControl(ingredient.name, Validators.required),
              amount: new FormControl(ingredient.amount, [
                Validators.required,
                Validators.pattern(/^[1-9]+[0-9]*$/)
              ])
            })
          );
        }
      }
    }

    //Regardless of edit mode, initialize the form with all the form controls
    this.recipeForm = new FormGroup({
      name: new FormControl(recipeName, Validators.required),
      imagePath: new FormControl(recipeImagePath, Validators.required),
      description: new FormControl(recipeDescription, Validators.required),
      ingredients: recipeIngredients
    });
  }
}
