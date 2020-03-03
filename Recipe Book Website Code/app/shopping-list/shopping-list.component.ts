import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from 'rxjs';

import {Ingredient} from '../shared/ingredient.model';
import {ShoppingListService} from './shopping-list.service';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit, OnDestroy {
  ingredients: Ingredient[];
  private subscription: Subscription;

  constructor(private shoppingListService: ShoppingListService) { }

  /**
   * OnInit method that will grab all ingredients from shopping list
   * and displays it to the user
   */
  ngOnInit() {
    this.ingredients = this.shoppingListService.getIngredients();
    this.subscription = this.shoppingListService.ingredientsChanged.subscribe(
      (ingredients: Ingredient[]) => {
        this.ingredients = ingredients;
      }
    );
  }

  /**
   * Method that will start the edit component once its been called.
   * @param index - Ingredient index
   */
  onEditItem(index: number) {
    this.shoppingListService.startedEditing.next(index);
  }

  /**
   * OnDestroy method that unsubscribes from the subscription that was
   * used in the OnInit method.
   */
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
