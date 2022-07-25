import { BreakpointObserver } from "@angular/cdk/layout";
import { Component, Input, OnChanges, OnInit } from "@angular/core";
import { Serie } from "src/app/core/models/videos/serie";

@Component({
    selector: 'app-video-cards-carousel',
    templateUrl: './video-cards-carousel.component.html',
    styleUrls: ['./video-cards-carousel.component.scss']
})
export class VideoCardsCarouselComponent implements OnInit {
    @Input()
    categoryName: string = ''

    @Input()
    videos: Array<Serie> = []

    currentPage: number = 0
    leftButtonDisabled: boolean = true
    rightButtonDisabled: boolean = false
    videosByPage: number = 1

    constructor(private breakpointObserver: BreakpointObserver) {}

    ngOnInit(): void {
        this.breakpointObserver.observe(['(max-width: 600px)', '(min-width: 600px)', '(min-width: 992px)'])
            .subscribe(state => {
                if (state.breakpoints['(max-width: 600px)']) {
                    this.videosByPage = 1
                } else if (state.breakpoints['(min-width: 600px)']) {
                    this.videosByPage = 3
                } else if (state.breakpoints['(min-width: 992px)']) {
                    this.videosByPage = 5
                }

                if (this.videos.length <= this.videosByPage) {
                    this.leftButtonDisabled = true
                    this.rightButtonDisabled = true
                }
            })
    }

    onLeftClick() {
        this.updateCurrentPage(this.currentPage - 1)
    }

    onRightClick() {
        this.updateCurrentPage(this.currentPage + 1)
    }

    private updateCurrentPage(value: number) {
        const maxPage = Math.ceil(this.videos.length / this.videosByPage) - 1

        this.currentPage = Math.max(value, 0)
        this.currentPage = Math.min(this.currentPage, maxPage)

        this.leftButtonDisabled = this.currentPage == 0
        this.rightButtonDisabled = this.currentPage == maxPage
    }
}