import { Component, OnInit } from "@angular/core";
import { select, Store } from "@ngrx/store";
import { Observable } from "rxjs";
import { Favorite } from "src/app/core/models/favorites/favorite";
import { Serie } from "src/app/core/models/videos/serie";
import { VideoService } from "../../services/video.service";

@Component({
    templateUrl: './my-list.component.html'
})
export class MyListComponent implements OnInit {
    favorite$: Observable<Favorite>
    series: Serie[] = []

    constructor(private store: Store<{favorites: Favorite}>) {
        this.favorite$ = this.store.pipe(select('favorites'))
    }

    ngOnInit(): void {
        this.favorite$.subscribe(favorite => {
            this.series = favorite.series
        })
    }
}