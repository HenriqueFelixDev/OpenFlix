import { Action } from "@ngrx/store"

export class FavoriteActionModel implements Action {
    type: string;
    payload: any;

    constructor(type: string, payload: any = null) {
        this.type = type
        this.payload = payload
    }
}