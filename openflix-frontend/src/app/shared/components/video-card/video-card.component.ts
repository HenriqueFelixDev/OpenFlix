import { Component, Input, OnInit, Output } from "@angular/core";
import { Router } from "@angular/router";
import { select, Store } from "@ngrx/store";
import { Observable } from "rxjs";
import * as moment from 'moment'

import { Serie } from "src/app/core/models/videos/serie";
import { Favorite } from "src/app/core/models/favorites/favorite";
import { add, remove } from "src/app/core/actions/favorite.actions";

@Component({
    selector: 'app-video-card',
    templateUrl: './video-card.component.html',
    styleUrls: ['./video-card.component.scss']
})
export class VideoCardComponent implements OnInit {
    @Input()
    serie!: Serie;

    isFavorite: boolean = false

    favorites$: Observable<Favorite>

    constructor(private router: Router, private store: Store<{favorites: Favorite}>) {
        this.favorites$ = this.store.pipe(select('favorites'))
    }

    ngOnInit() {
        this.favorites$.subscribe((state: Favorite) => {
            this.isFavorite = state.checkIfIsFavorite(this.serie)
        })
    }

    get serieDuration() {
        const duration = this.serie.videos
            .reduce((acc, current) => current.duration + acc, 0)

        return moment.duration(duration, 'seconds').humanize()
    }

    onCardClick() {
        this.router.navigate(['video', this.serie.id])
    }

    onFavoriteClick(event: PointerEvent | MouseEvent) {
        event.stopPropagation()

        const action = this.isFavorite
            ? remove(this.serie)
            : add(this.serie)

        this.store.dispatch(action)
    }
}