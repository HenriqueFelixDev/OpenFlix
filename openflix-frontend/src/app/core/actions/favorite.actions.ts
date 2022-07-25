import { createAction, props } from "@ngrx/store";
import { Favorite } from "../models/favorites/favorite";
import { Serie } from "../models/videos/serie";

export enum ActionTypes {
    ADD = 'ADD',
    REMOVE = 'REMOVE',
    ONLOAD = 'ONLOAD',
    GET_FAVORITES = 'GET'
}

export const add = createAction(ActionTypes.ADD, props<Serie>())

export const remove = createAction(ActionTypes.REMOVE, props<Serie>())

export const onload = createAction(ActionTypes.ONLOAD, props<Favorite>())

export const getFavorites = createAction(ActionTypes.GET_FAVORITES)