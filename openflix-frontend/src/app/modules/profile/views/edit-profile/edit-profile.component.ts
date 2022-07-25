import { Component, OnInit } from "@angular/core"
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ProfileImage } from "src/app/core/models/profiles/profile-image";
import { environment } from "src/environments/environment";
import { ProfileService } from "../../services/profile.service";

@Component({
    templateUrl: './edit-profile.component.html',
    styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {
    id: number | null = null;
    profileForm: FormGroup;
    selectImage: boolean = false;
    
    constructor(private formBuilder: FormBuilder, private profileService: ProfileService, private router: Router, private activatedRoute: ActivatedRoute) {
        this.profileForm = this.formBuilder.group({
            name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(32)]),
            image: new FormControl(null, [Validators.required])
        })
        
        const id = this.activatedRoute.snapshot.paramMap.get('id')
        if (id) {
            this.id = +id
        }
    }

    ngOnInit(): void {
        if (this.id) {
            this.profileService.getProfileById(this.id).subscribe((profile) => {
                this.profileForm.controls['name'].setValue(profile.name)
                this.profileForm.controls['image'].setValue(profile.profileImage)
            })
        }
    }

    get profileImage() {
        return this.profileForm.get('image')?.value?.imageName
    }

    controlIsInvalid(name: string): boolean {
        var control = this.profileForm.get(name)

        if (!control) return false

        return control.invalid && (control.dirty || control.touched)
    }

    getControlError(controlName: string, errorName: string) {
        return this.profileForm.get(controlName)?.errors?.[errorName]
    }

    onSelectPhotoClick() {
        this.selectImage = true
    }


    cancelSelectImage() {
        this.selectImage = false
    }

    selectProfileImage(image: ProfileImage) {
        this.profileForm.controls['image'].setValue(image)
        this.selectImage = false
    }

    onSaveClick() {
        const { name, image } = this.profileForm.value

        if (this.id) {
            this.profileService.editProfile(this.id, name, image.id).subscribe(() => {
                this.router.navigateByUrl('/selecionar-perfil')
            })
            return
        }

        this.profileService.createProfile(name, image.id).subscribe(() => {
            this.router.navigateByUrl('/selecionar-perfil')
        })
    }
}