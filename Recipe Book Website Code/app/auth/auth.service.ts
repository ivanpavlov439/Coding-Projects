import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { catchError, tap } from "rxjs/operators";
import { throwError, BehaviorSubject } from "rxjs";
import { environment } from "../../environments/environment";
import { Router } from "@angular/router";

import { User } from "./user.model";
import { RecipeService } from "../recipes/recipe.service";
import { ShoppingListService } from "../shopping-list/shopping-list.service";

/**
 * Interface that will store the details of all the http responses it gets
 */
export interface AuthResponseData {
  idToken: string;
  email: string;
  refreshToken: string;
  expiresIn: string;
  localId: string;
  registered?: boolean;
}

@Injectable({ providedIn: "root" })
export class AuthService {
  userSubject = new BehaviorSubject<User>(null);
  private tokenExpTimer: any;

  constructor(
    private http: HttpClient,
    private router: Router,
    private recipeService: RecipeService,
    private slService: ShoppingListService
  ) {}

  /**
   * Logout method that will logout the current user and remove all info about them
   * from the application and local storage.
   */
  logout() {
    this.userSubject.next(null);
    this.router.navigate(["/auth"]);
    localStorage.removeItem("userData");
    this.recipeService.setRecipes([]);
    this.slService.setIngredients([]);

    if (this.tokenExpTimer) {
      clearTimeout(this.tokenExpTimer);
    }
    this.tokenExpTimer = null;
  }

  /**
   * Method that will automatically logout the user
   * @param expirationDuration Duration until token expires
   */
  autoLogout(expirationDuration: number) {
    this.tokenExpTimer = setTimeout(() => {
      this.logout();
    }, expirationDuration);
  }

  /**
   * Method that signs up the user using the firebase restful API
   * @param email - Users email
   * @param password - Users password
   */
  signup(email: string, password: string) {
    return this.http
      .post<AuthResponseData>(
        "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=" +
          environment.firebaseAPIKey,
        {
          email: email,
          password: password,
          returnSecureToken: true
        }
      )
      .pipe(
        catchError(this.handleError),
        tap(resData => {
          this.handleAuth(
            resData.email,
            resData.localId,
            resData.idToken,
            +resData.expiresIn
          );
        })
      );
  }

  /**
   * Method that logins the user using the firebase restful API
   * @param email - Users email
   * @param password - Users password
   */
  login(email: string, password: string) {
    return this.http
      .post<AuthResponseData>(
        "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=" +
          environment.firebaseAPIKey,
        {
          email: email,
          password: password,
          returnSecureToken: true
        }
      )
      .pipe(
        catchError(this.handleError),
        tap(resData => {
          this.handleAuth(
            resData.email,
            resData.localId,
            resData.idToken,
            +resData.expiresIn
          );
        })
      );
  }

  /**
   * Method that will automatically login the user if the user data still
   * exists in local storage
   */
  autoLogin() {
    const userData: {
      email: string;
      id: string;
      _token: string;
      _tokenExpirationDate: string;
    } = JSON.parse(localStorage.getItem("userData"));
    if (!userData) {
      return;
    }

    const loadedUser = new User(
      userData.email,
      userData.id,
      userData._token,
      new Date(userData._tokenExpirationDate)
    );

    if (loadedUser.token) {
      this.userSubject.next(loadedUser);
      const expDuration =
        new Date(userData._tokenExpirationDate).getTime() -
        new Date().getTime();
      this.autoLogout(expDuration);
    }
  }

  /**
   * Method that will handle authentication and store user details
   * inside local storage.
   * @param email - User email
   * @param userId - User Id
   * @param token - User token
   * @param expiresIn - Time until token expires
   */
  private handleAuth(
    email: string,
    userId: string,
    token: string,
    expiresIn: number
  ) {
    const expDate = new Date(new Date().getTime() + expiresIn * 1000);
    const user = new User(email, userId, token, expDate);
    this.userSubject.next(user);
    this.autoLogout(expiresIn * 1000);
    localStorage.setItem("userData", JSON.stringify(user));
  }

  /**
   * Private method that will handle all error messages that can happen while
   * using the restful API
   * @param errorRes HttpErrorResponse object
   */
  private handleError(errorRes: HttpErrorResponse) {
    let errorMsg = "An unknown error occurred!";
    if (!errorRes.error || !errorRes.error.error) {
      return throwError(errorMsg);
    }
    switch (errorRes.error.error.message) {
      case "EMAIL_EXISTS":
        errorMsg = "This email exists already!";
        break;
      case "EMAIL_NOT_FOUND":
      case "INVALID_PASSWORD":
        errorMsg = "Email and/or password is invalid!";
        break;
    }
    return throwError(errorMsg);
  }
}
