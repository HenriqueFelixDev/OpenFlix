import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { CoreModule } from "src/app/core/core.module";
import { AuthGuard } from "src/app/core/guards/auth.guard";
import { SharedModule } from "src/app/shared/shared.module";
import { LoginComponent } from "./views/login/login.component";

@NgModule({
    declarations: [
        LoginComponent
    ],
    imports: [
        CoreModule,
        SharedModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild([
            { path: 'login', component: LoginComponent, canActivate: [AuthGuard] }
        ])
    ],
})
export class LoginModule { }