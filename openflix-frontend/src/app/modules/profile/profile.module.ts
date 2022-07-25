import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { CoreModule } from "src/app/core/core.module";
import { AuthGuard } from "src/app/core/guards/auth.guard";
import { SharedModule } from "src/app/shared/shared.module";
import { AddProfileButtonComponent } from "./components/add-profile-button/add-profile-button.component";
import { ProfileImageComponent } from "./components/profile-image/profile-image.component";
import { ProfileService } from "./services/profile.service";
import { EditProfileComponent } from "./views/edit-profile/edit-profile.component";
import { SelectPhotoComponent } from "./views/select-profile-image/select-profile-image.component";
import { SelectProfileComponent } from "./views/select-profile/select-profile.component";

@NgModule({
    declarations: [
        SelectProfileComponent,
        EditProfileComponent,
        SelectPhotoComponent,
        ProfileImageComponent,
        AddProfileButtonComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        SharedModule,
        ReactiveFormsModule,
        RouterModule.forChild([
            { path: 'selecionar-perfil', component: SelectProfileComponent, canActivate: [AuthGuard] },
            { path: 'editar-perfil', component: EditProfileComponent, canActivate: [AuthGuard] },
            { path: 'editar-perfil/:id', component: EditProfileComponent, canActivate: [AuthGuard] },
        ])
    ],
    providers: [
        ProfileService
    ]
})
export class ProfileModule {}