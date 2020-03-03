import { Component, OnInit, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";

import { DataStorageService } from "../shared/data-storage.service";
import { AuthService } from "../auth/auth.service";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.css"]
})
export class HeaderComponent implements OnInit, OnDestroy {
  collapsed = true;
  isAuthenticated = false;
  private userSub: Subscription;

  constructor(
    private dataStorageService: DataStorageService,
    private authService: AuthService
  ) {}

  /**
   * OnInit method that checks whether or not a user is logged in or not
   * using the auth service subscription.
   */
  ngOnInit() {
    this.userSub = this.authService.userSubject.subscribe(user => {
      this.isAuthenticated = !!user;
    });
  }

  /**
   * Method that saves all recipes created in the DB.
   */
  onSaveRecipe() {
    this.dataStorageService.storeRecipes();
  }

  /**
   * Method that fetches all recipes in the DB.
   */
  onFetchRecipes() {
    this.dataStorageService.fetchRecipes().subscribe();
  }

  /**
   * Method that saves the shopping list in the DB.
   */
  onSaveSl() {
    this.dataStorageService.storeShoppingList();
  }

  /**
   * Method that saves the shopping list in the DB.
   */
  onFetchSl() {
    this.dataStorageService.fetchShoppingList();
  }

  /**
   * Method that will logout the current user
   */
  onLogout() {
    this.authService.logout();
  }

  /**
   * OnDestroy method that unsubscribes from all subscriptions that
   * were created.
   */
  ngOnDestroy() {
    this.userSub.unsubscribe();
  }
}
