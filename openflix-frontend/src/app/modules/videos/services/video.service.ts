import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CategoryzedVideo } from "src/app/core/models/videos/categoryzed-video";
import { Serie } from "src/app/core/models/videos/serie";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class VideoService {
    constructor(private httpClient: HttpClient) {}

    getCategoryzedVideos(): Observable<Array<CategoryzedVideo>> {
        return this.httpClient
            .get<Array<CategoryzedVideo>>(`${environment.apiBaseUrl}/videos/categoryzed`)
    }

    searchVideos(search: string) {
        return this.httpClient
            .get<Array<Serie>>(`${environment.apiBaseUrl}/videos?s=${search}`)
    }

    getVideoById(id: number) {
        return this.httpClient
            .get<Serie>(`${environment.apiBaseUrl}/videos/${id}`)
    }
}