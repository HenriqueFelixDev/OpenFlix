import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { LayoutModule } from '@angular/cdk/layout'

import { DefaultLayoutComponent } from "./layouts/default-layout/default-layout.component";
import { AppBarComponent } from "./components/appbar/appbar.component";
import { VideoCardComponent } from "./components/video-card/video-card.component";
import { VideoCardsCarouselComponent } from "./components/video-carousel/video-cards-carousel.component";
import { CoreModule } from "../core/core.module";

@NgModule({
    declarations: [
        AppBarComponent,
        VideoCardComponent,
        VideoCardsCarouselComponent,
        DefaultLayoutComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        RouterModule,
        LayoutModule
    ],
    exports: [
        AppBarComponent,
        VideoCardComponent,
        VideoCardsCarouselComponent,
        DefaultLayoutComponent
    ]
})
export class SharedModule {}