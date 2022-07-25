import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { catchError, map, Observable, pipe } from "rxjs";
import { AuthService } from "../services/auth.service";

@Injectable()
export class UnauthenticatedInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService, private router: Router) {}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req)
        .pipe(
            catchError<any, any>(err => {
                if (err instanceof HttpErrorResponse) {
                    if(err.status === 401) {
                        this.authService.logout()
                        this.router.navigateByUrl('/')
                    }
                }
                return err
            })
        )
    }
}