import { Component, OnInit } from "@angular/core";
import { CategoryzedVideo } from "src/app/core/models/videos/categoryzed-video";
import { VideoService } from "../../services/video.service";

@Component({
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.html'],
})
export class HomeComponent implements OnInit {
    categoryzedVideos: Array<CategoryzedVideo> = []
    constructor(private videoService: VideoService) {}

    ngOnInit() {
        this.videoService.getCategoryzedVideos().subscribe(videos => {
            this.categoryzedVideos = videos
        })
    }
}