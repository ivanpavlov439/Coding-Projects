import {
  Component,
  ComponentFactoryResolver,
  ViewChild,
  OnDestroy
} from "@angular/core";
import { NgForm } from "@angular/forms";
import { Observable, Subscription } from "rxjs";
import { Router } from "@angular/router";

import { AuthService, AuthResponseData } from "./auth.service";
import { AlertComponent } from "../shared/alert/alert.component";
import { PlaceholderDirective } from "../shared/placeholder/placeholder.directive";

@Component({
  selector: "app-auth",
  templateUrl: "./auth.component.html"
})
export class AuthComponent implements OnDestroy {

  //Creating new ViewChild ement using a directive to gain access to
  //ng-template to display the alert component
  @ViewChild(PlaceholderDirective) alertHost: PlaceholderDirective;

  isLogin = true;
  isLoading = false;
  error: string = null;

  private closeSub: Subscription;

  constructor(
    private authService: AuthService,
    private router: Router,
    private componentFactoryResolver: ComponentFactoryResolver
  ) {}

  /**
   * A method that will keep track whether the user is logging in or
   * signing up.
   */
  onSwitchMode() {
    this.isLogin = !this.isLogin;
  }

  /**
   * The method thats called when the user either signs up or logs in.
   * @param authForm - The NgForm object to get access to all form elements
   */
  onSubmit(authForm: NgForm) {

    //Basic check to see if form is valid
    if (!authForm.valid) {
      return;
    }
    const email = authForm.value.email;
    const password = authForm.value.password;

    let authObs: Observable<AuthResponseData>;

    this.isLoading = true;

    if (this.isLogin) {
      authObs = this.authService.login(email, password);
    } else {
      authObs = this.authService.signup(email, password);
    }

    //Subscribing to the auth observable to see if the login was a success or not.
    //If it was a success, navigate user away, otherwise display error alert.
    authObs.subscribe(
      responseData => {
        console.log(responseData);
        this.isLoading = false;
        this.router.navigate(["/recipes"]);
      },
      errorMsg => {
        console.log(errorMsg);
        this.error = errorMsg;
        this.showErrorAlert(errorMsg);
        this.isLoading = false;
      }
    );

    //Regardless of outcome, reset the form
    authForm.reset();
  }

  /**
   * Method that resets the error message
   */
  onHandleError() {
    this.error = null;
  }

  /**
   * On destroy method that will unsubscribe from any subscriptions still active
   */
  ngOnDestroy() {
    if (this.closeSub) {
      this.closeSub.unsubscribe();
    }
  }

  /**
   * Private method that will create a new alert component with the error message associated with it.
   * @param message - Error message
   */
  private showErrorAlert(message: string) {

    //Creating the component factory
    const alertCompFact = this.componentFactoryResolver.resolveComponentFactory(
      AlertComponent
    );

    //Getting the view container of the alert component
    const hostViewContainerRef = this.alertHost.viewContainerRef;
    hostViewContainerRef.clear();

    //Creating variable to store the alert component
    const componentRef = hostViewContainerRef.createComponent(alertCompFact);

    //Setting the message as well as subscribing to the component instance
    componentRef.instance.message = message;
    this.closeSub = componentRef.instance.close.subscribe(() => {
      this.closeSub.unsubscribe();
      hostViewContainerRef.clear();
    });
  }
}
