import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Route, Router } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [NgIf],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  creds = {
    email: '',
    password: '',
  };
  error: { title: string; errors?: [string] } | null = null;
  constructor(private userService: UserService, private router: Router) {}
  handleChange(event: any) {
    //@ts-ignore
    this.creds[event.target.name] = event.target.value;
  }

  submit() {
    this.userService.login(this.creds).subscribe({
      next: (data) => {
        console.log(data);
        localStorage.setItem('token', data.token);
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.log(err);
        this.error = { ...err.error, title: 'Invalid Credentials' };
      },
    });
  }
}
