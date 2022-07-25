import { Component } from "@angular/core";
import { Serie } from "src/app/core/models/videos/serie";
import { VideoService } from "../../services/video.service";

@Component({
    templateUrl: './search-videos.component.html',
    styleUrls: ['./search-videos.component.scss']
})
export class SearchVideosComponent{
    series: Array<Serie> = []
    search: string = ''

    constructor(private videoService: VideoService) {}

    onSearchClick(): void {
        this.videoService.searchVideos(this.search).subscribe(series => {
            this.series = series
        })
    }
}