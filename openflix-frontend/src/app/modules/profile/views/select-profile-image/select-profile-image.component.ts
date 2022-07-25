import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { ProfileImage } from "src/app/core/models/profiles/profile-image";
import { environment } from "src/environments/environment";
import { ProfileService } from "../../services/profile.service";

@Component({
    selector: 'app-select-profile-image',
    templateUrl: './select-profile-image.component.html'
})
export class SelectPhotoComponent implements OnInit {
    selectedImage: ProfileImage | null = null;
    profileImages: Array<ProfileImage> = []

    @Output()
    onChooseImage = new EventEmitter<ProfileImage>();

    @Output()
    onCancel = new EventEmitter();

    constructor(private profileService: ProfileService) {}

    ngOnInit(): void {
        this.profileService.getProfileImages().subscribe(images => {
            this.profileImages = images
        })
    }

    selectImage(image: ProfileImage) {
        this.selectedImage = image
    }

    onCancelClick() {
        this.onCancel.emit()
    }

    onSaveClick() {
        this.onChooseImage.emit(this.selectedImage!)
    }
}