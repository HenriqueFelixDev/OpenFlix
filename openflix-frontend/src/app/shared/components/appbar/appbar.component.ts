import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { Profile } from "src/app/core/models/profiles/profile";
import { AuthService } from "src/app/core/services/auth.service";
import { environment } from "src/environments/environment";

@Component({
    selector: 'appbar',
    templateUrl: './appbar.component.html',
    styleUrls: ['./appbar.component.scss']
})
export class AppBarComponent implements OnInit {
    profile: Profile | null = null;

    constructor(private authService: AuthService, private router: Router) {}

    ngOnInit(): void {
        this.profile = this.authService.currentProfile
    }
    
    onLogoutClick() {
        this.authService.logout()
        this.router.navigateByUrl('/')
    }
}