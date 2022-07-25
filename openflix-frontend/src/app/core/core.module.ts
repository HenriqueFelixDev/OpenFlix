import { CommonModule } from "@angular/common";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { AuthInterceptor } from "./interceptors/auth.interceptor";
import { UnauthenticatedInterceptor } from "./interceptors/unauthenticated.interceptor";
import { ApiImagePipe } from "./pipes/api-image.pipe";
import { AuthService } from "./services/auth.service";

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule
    ],
    declarations: [
        ApiImagePipe
    ],
    providers: [
        AuthService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: UnauthenticatedInterceptor,
            multi: true
        }
    ],
    exports: [
        RouterModule,
        ApiImagePipe
    ]
})
export class CoreModule {}