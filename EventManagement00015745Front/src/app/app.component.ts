import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { User, UserService } from './services/user.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'EventManagement00015745Front';
  user: User | null = null;
  constructor(private userService: UserService) {
    this.user = userService.currentUser;
  }
  logout() {
    this.userService.logout();
    this.user = null;
  }
}
