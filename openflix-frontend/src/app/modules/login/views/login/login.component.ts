import { Component } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";

import { IAuthResult } from "src/app/core/models/auth/auth-result";
import { AuthService } from "src/app/core/services/auth.service";

@Component({
    templateUrl: './login.component.html'
})
export class LoginComponent {
    loginForm: FormGroup;
    signupForm: FormGroup

    constructor(
        private authService: AuthService,
        private formBuilder: FormBuilder,
        private router: Router
    ) {
        const usernameValidators = [Validators.required, Validators.minLength(3), Validators.maxLength(32)]
        const passwordValidators = [Validators.required, Validators.minLength(6), Validators.maxLength(32)]
        
        this.loginForm = this.formBuilder.group({
            username: new FormControl('', usernameValidators),
            password: new FormControl('', passwordValidators)
        })

        this.signupForm = this.formBuilder.group({
            username: new FormControl('', usernameValidators),
            email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(128)]),
            password: new FormControl('', passwordValidators),
            repeatPassword: new FormControl('', passwordValidators),
        })
    }

    controlIsInvalid(form: FormGroup, name: string): boolean {
        var control = form.get(name)

        if (!control) return false

        return control.invalid && (form.dirty || control.touched)
    }

    getControlError(form: FormGroup,controlName: string, errorName: string) {
        return form.get(controlName)?.errors?.[errorName]
    }

    onLoginClick(event: MouseEvent) {
        event.preventDefault()
        const {username, password} = this.loginForm.value

        this.authService
            .login(username, password)
            .subscribe(result => this._onAuthComplete(result))
    }

    onSignUpClick(event: MouseEvent) {
        event.preventDefault();
        const {username, email, password} = this.signupForm.value
        this.authService
            .signUp(username, email, password)
            .subscribe(result => this._onAuthComplete(result))
    }

    private _onAuthComplete(result: IAuthResult) {
        this.authService.setToken(result.token)
        this.router.navigateByUrl('/selecionar-perfil')
    }
}