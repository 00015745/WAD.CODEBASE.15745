import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  imports: [],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  creds = {
    email: '',
    password: '',
    username: '',
  };
  constructor(private userService: UserService, private router: Router) {}
  handleChange(event: any) {
    //@ts-ignore
    this.creds[event.target.name] = event.target.value;
  }

  submit() {
    this.userService.register(this.creds).subscribe({
      next: (data) => {
        console.log(data);
        this.router.navigate(['/login']);
      },
    });
  }
}
