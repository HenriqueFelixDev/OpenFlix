import { createReducer, on } from "@ngrx/store";

import { add, onload, remove } from "../actions/favorite.actions";
import { Favorite } from "../models/favorites/favorite";

export const favorites = new Favorite()

export const favoritesReducer = createReducer(
    favorites,
    on(add, (favorites, serie) => {
        const series = [...favorites.series, serie]
        return new Favorite(series)
    }),
    on(remove, (favorites, serie) => {
        const serieIsFavorite = favorites.checkIfIsFavorite(serie)

        if (!serieIsFavorite) {
            return favorites
        }

        const series = favorites.series
            .filter(filterSerie => filterSerie.id !== serie.id)

        return new Favorite(series)
    }),
    on(onload, (oldFavorites, newFavorites) => {
        return new Favorite(newFavorites.series)
    })
)
