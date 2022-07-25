import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlSegment, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AuthService } from "../services/auth.service";

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const isLoggedIn = route.url[0].path == 'login'
        const isAuthenticated = this.authService.isAuthenticated()

        if (isAuthenticated) {
            if (isLoggedIn) {
                this.router.navigateByUrl('/selecionar-perfil')
                return false
            }
            
            return true
        }

        // if (!isAuthenticated)
        if (isLoggedIn) {
            return true
        }

        this.router.navigateByUrl('/')
        return false
    }
}