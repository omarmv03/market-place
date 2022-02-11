import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { GenericResponse } from 'src/app/model/genericResponse';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  get f() { return this.registerForm.controls; }
  registerForm: FormGroup;
  constructor(private router: Router,
              private userService: UserService,
              private toastr: ToastrService,
              private fb: FormBuilder) {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.maxLength(50)]],
      password: ['', [Validators.required, Validators.maxLength(30)]],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      lastname: ['', [Validators.required, Validators.maxLength(50)]]
    }
    )
  }

  register(): void {
    if (this.registerForm.valid) {
      this.userService.register(this.registerForm.value)
        .subscribe((r: GenericResponse) => {
          this.toastr.success(r.message);
          this.router.navigate(['/']);
        })
    } else {
      this.toastr.error('Requeried fields')
    }
  }

}
