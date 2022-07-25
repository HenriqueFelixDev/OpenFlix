import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { CoreModule } from "src/app/core/core.module";
import { AuthGuard } from "src/app/core/guards/auth.guard";
import { SharedModule } from "src/app/shared/shared.module";
import { VideoService } from "./services/video.service";
import { HomeComponent } from "./views/home/home.component";
import { MyListComponent } from "./views/my-list/my-list.component";
import { SearchVideosComponent } from "./views/search-videos/search-videos.component";
import { VideoComponent } from "./views/video/video.component";

@NgModule({
    declarations: [
        HomeComponent,
        SearchVideosComponent,
        MyListComponent,
        VideoComponent
    ],
    imports: [
        CoreModule,
        HttpClientModule,
        FormsModule,
        CommonModule,
        SharedModule,
        RouterModule.forChild([
            { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'pesquisar', component: SearchVideosComponent, canActivate: [AuthGuard] },
            { path: 'minha-lista', component: MyListComponent, canActivate: [AuthGuard] },
            { path: 'video/:id', component: VideoComponent, canActivate: [AuthGuard] },
        ])
    ],
    providers: [
        VideoService
    ],
    exports: [
        RouterModule
    ]
})
export class VideosModule {}