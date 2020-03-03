import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpParams
} from "@angular/common/http";
import { take, exhaustMap } from "rxjs/operators";

import { AuthService } from "./auth.service";

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  /**
   * Intercept method that will catch any form of http request only once and return
   * either the original request if their is no user associated with the request. Or
   * it will return a modified request setting the auth param with the users token.
   * @param req - Original http request
   * @param next - The http handler that will return the http request
   */
  intercept(req: HttpRequest<any>, next: HttpHandler) {

    //returning this subject to be subscribed later in the application
    return this.authService.userSubject.pipe(
      take(1),
      exhaustMap(user => {
        if (!user) {
          return next.handle(req);
        }

        //Creating a new request by adding a HttpParam for the authorization
        //of the user.
        const modifiedReq = req.clone({
          params: new HttpParams().set("auth", user.token)
        });
        return next.handle(modifiedReq);
      })
    );
  }
}
