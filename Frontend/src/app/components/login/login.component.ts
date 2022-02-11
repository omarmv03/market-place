import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  get f() { return this.loginForm.controls; }
  loginForm: FormGroup;
  constructor(private router: Router,
    private userService: UserService,
    private fb: FormBuilder,
    private toastr: ToastrService) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required, Validators.maxLength(50)]],
      password: ['', [Validators.required, Validators.maxLength(30)]]
    }
    )
  }

  login(): void {
    if (this.loginForm.valid) {
      this.userService.login(this.loginForm.value)
        .subscribe(() => {
          this.router.navigate(['/']);
        })
    } else {
      this.toastr.error('Requeried fields')
    }
  }

}
