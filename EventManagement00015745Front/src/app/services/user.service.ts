import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
export interface User {
  id: number;
  username: string;
  email: string;
  token: string; // JWT token to store the session
}
@Injectable({
  providedIn: 'root',
})
export class UserService {
  apiUrl = 'https://localhost:7025/api/Auth';
  private currentUserSubject: BehaviorSubject<User | null> =
    new BehaviorSubject<User | null>(this.getUserFromLocalStorage());
  public currentUser$: Observable<User | null> =
    this.currentUserSubject.asObservable();

  constructor(private http: HttpClient) {}

  // Get current logged-in user
  get currentUser(): User | null {
    return this.currentUserSubject.value;
  }

  // Register a new user
  register(creds: {
    username: string;
    email: string;
    password: string;
  }): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/register`, creds);
  }

  // Login the user
  login(creds: { email: string; password: string }): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/login`, creds).pipe(
      // Store the user in localStorage on successful login
      tap((user) => this.setUserToLocalStorage(user))
    );
  }

  // Logout the user
  logout(): void {
    // Remove user from local storage and update the current user state
    localStorage.removeItem('user');
    this.currentUserSubject.next(null);
  }

  // Check if the user is logged in
  isLoggedIn(): boolean {
    return !!this.getUserFromLocalStorage();
  }

  // Set user information to localStorage and update currentUserSubject
  private setUserToLocalStorage(user: User): void {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSubject.next(user);
  }

  // Get user from localStorage
  private getUserFromLocalStorage(): User | null {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
  }
}
