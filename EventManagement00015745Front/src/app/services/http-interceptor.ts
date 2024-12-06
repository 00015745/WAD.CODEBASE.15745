import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptorFn,
  HttpHandlerFn,
} from '@angular/common/http';
import { inject } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

export const authInterceptor: HttpInterceptorFn = (
  req: HttpRequest<unknown>,
  next: HttpHandlerFn
): Observable<HttpEvent<any>> => {
  const userService = inject(UserService); // Angular's DI to get the UserService

  // Get the current user's token from the UserService or LocalStorage
  const user = userService.currentUser; // Assuming you have a currentUser with the token

  // If the user has a token, clone the request and add the Authorization header
  if (user && user.token) {
    const clonedRequest = req.clone({
      setHeaders: {
        Authorization: `Bearer ${user.token}`, // Add the token to the headers
      },
    });

    // Pass the cloned request to the next handler
    return next(clonedRequest);
  }

  // If no token, pass the request as is
  return next(req);
};
