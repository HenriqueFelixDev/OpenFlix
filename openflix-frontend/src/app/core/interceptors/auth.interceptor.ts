import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { AuthService } from "../services/auth.service";

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = this.authService.token
        const profile = this.authService.currentProfile
        
        let headers = req.headers

        if (token) {
            headers = headers.set('Authorization', `Bearer ${token}`)
        }

        if (profile) {
            headers = headers.set('X-Profile-ID', profile.id.toString())
        }

        return next.handle(req.clone({ headers }))
    }

}