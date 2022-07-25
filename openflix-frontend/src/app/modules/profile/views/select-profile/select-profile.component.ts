import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "@ngrx/store";
import { getFavorites } from "src/app/core/actions/favorite.actions";
import { Favorite } from "src/app/core/models/favorites/favorite";
import { Profile } from "src/app/core/models/profiles/profile";
import { AuthService } from "src/app/core/services/auth.service";
import { environment } from "src/environments/environment";
import { ProfileService } from "../../services/profile.service";

@Component({
    templateUrl: './select-profile.component.html'
})
export class SelectProfileComponent implements OnInit {
    profiles: Array<Profile> = []

    constructor(private profileService: ProfileService, private authService: AuthService, private router: Router, private store: Store<{favorites: Favorite}>) {}

    ngOnInit(): void {
        this.loadProfiles()
    }

    private loadProfiles() {
        this.profileService.getProfiles().subscribe(profiles => {
            this.profiles = profiles
        })
    }

    selectProfile(profile: Profile) {
        this.authService.setCurrentProfile(profile)
        this.store.dispatch(getFavorites())
        this.router.navigate(['home'])
    }

    onAddProfileClick() {
        this.router.navigate(['/editar-perfil'])
    }

    onEditProfile(profile: Profile) {
        this.router.navigate(['/editar-perfil', profile.id])
    }

    onDeleteProfile(profile: Profile) {
        this.profileService.deleteProfile(profile.id).subscribe(() => {
            this.loadProfiles()
        })
    }
}