import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { environment } from "src/environments/environment";
import { Serie } from "../models/videos/serie";

@Injectable({
    providedIn: 'root'
})
export class FavoriteService {
    constructor(private httpClient: HttpClient) {}
    
    getFavoriteSeries(): Observable<Array<Serie>> {
        return this.httpClient
            .get<Array<Serie>>(`${environment.apiBaseUrl}/favorites`)
    }

    addFavoriteSerie(serie: Serie): Observable<void> {
        return this.httpClient
            .post<void>(`${environment.apiBaseUrl}/favorites/${serie.id}`, {})
    }
    
    removeFavoriteSerie(serie: Serie): Observable<void> {
        return this.httpClient
            .delete<void>(`${environment.apiBaseUrl}/favorites/${serie.id}`)
    }
}