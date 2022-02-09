import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private router: Router,
              private userService: UserService) { }

  login(): void {
    this.userService.login()
    .subscribe(x => {
      this.router.navigate(['/']);
    })
  }

}
