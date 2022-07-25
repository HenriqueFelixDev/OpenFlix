import { Component, ElementRef, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { select, Store } from "@ngrx/store";
import { Observable } from "rxjs";
import { add, remove } from "src/app/core/actions/favorite.actions";
import { Favorite } from "src/app/core/models/favorites/favorite";
import { Serie } from "src/app/core/models/videos/serie";
import videojs, { VideoJsPlayerOptions } from 'video.js';
import { VideoService } from "../../services/video.service";

@Component({
    templateUrl: './video.component.html',
    styleUrls: ['./video.component.scss', './video-player-skin.scss'],
    encapsulation: ViewEncapsulation.None
})
export class VideoComponent implements OnInit, OnDestroy {
    @ViewChild('target', { static: true }) target?: ElementRef;
    player?: videojs.Player;
    serie: Serie = {id: 1, title: '', banner: '', author: '', category: null, videos: []}
    isFavorite: boolean = false
    
    favorite$: Observable<Favorite>

    constructor(private videoService: VideoService, private activatedRoute: ActivatedRoute, private store: Store<{favorites: Favorite}>) {
        this.favorite$ = this.store.pipe(select('favorites'))
    }

    ngOnInit(): void {
        

        const id = this.activatedRoute.snapshot.paramMap.get('id')
        
        if (id) {
            this.videoService.getVideoById(+id).subscribe(serie => {
                this.serie = serie

                let options: VideoJsPlayerOptions = {
                    aspectRatio: '16:6',
                    responsive: true,
                    bigPlayButton: true,
                    controls: true,
                    fill: true,
                    fluid: true,
                    sources: [
                        { src: serie.videos[0].url, type: 'video/mp4' }
                    ]
                }
        
                this.player = videojs(this.target!.nativeElement, options)
            })
        }

        this.favorite$.subscribe(favorite => {
            this.isFavorite = favorite.checkIfIsFavorite(this.serie)
        })
    }

    onFavoriteButtonClick() {
        const action = this.isFavorite
            ? remove(this.serie)
            : add(this.serie)

        this.store.dispatch(action)
    }

    ngOnDestroy(): void {
        if (this.player) {
            this.player.dispose()
        }
    }
}