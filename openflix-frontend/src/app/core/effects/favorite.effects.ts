import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType, OnInitEffects, ROOT_EFFECTS_INIT } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { catchError, EMPTY, map, mergeMap } from 'rxjs';
import { ActionTypes, add, getFavorites, remove } from '../actions/favorite.actions';
import { Favorite } from '../models/favorites/favorite';
import { FavoriteActionModel } from '../models/favorites/favorite-action';
import { FavoriteService } from '../services/favorite.service'

@Injectable()
export class FavoriteEffects implements OnInitEffects {
    ngrxOnInitEffects(): Action {
        return { type: ActionTypes.GET_FAVORITES };
    }

    getFavorites$ = createEffect(() => this.actions$.pipe(
        ofType(getFavorites), 
        mergeMap(() => this.favoriteService.getFavoriteSeries()
            .pipe(map(series => ({ type: ActionTypes.ONLOAD, series })))),
        catchError(() => EMPTY)
    ))

    addFavoriteSerie$ = createEffect(() => this.actions$.pipe(
        ofType(add),
        mergeMap((serie) => this.favoriteService.addFavoriteSerie(serie)
            .pipe(map((() => ({ type: ActionTypes.GET_FAVORITES })))))
    ))

    removeFavoriteSerie$ = createEffect(() => this.actions$.pipe(
        ofType(remove),
        mergeMap((serie) => this.favoriteService.removeFavoriteSerie(serie)
            .pipe(map((() => ({ type: ActionTypes.GET_FAVORITES })))))
    ))

    constructor(private favoriteService: FavoriteService, private actions$: Actions) {}
}