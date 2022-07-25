import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Profile } from "src/app/core/models/profiles/profile";
import { ProfileImage } from "src/app/core/models/profiles/profile-image";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class ProfileService {
    constructor(private httpClient: HttpClient) {}

    getProfiles() : Observable<Array<Profile>> {
        return this.httpClient.get<Array<Profile>>(`${environment.apiBaseUrl}/profiles`);
    }

    getProfileImages() : Observable<Array<ProfileImage>> {
        return this.httpClient.get<Array<ProfileImage>>(`${environment.apiBaseUrl}/profile-images`);
    }

    createProfile(name: string, imageId: number) {
        const data = { name, imageId }
        return this.httpClient.post(`${environment.apiBaseUrl}/profiles`, data)
    }

    getProfileById(id: number): Observable<Profile> {
        return this.httpClient.get<Profile>(`${environment.apiBaseUrl}/profiles/${id}`)
    }

    editProfile(id: number, name: string, imageId: number) {
        const data = { name, imageId }
        return this.httpClient.put(`${environment.apiBaseUrl}/profiles/${id}`, data)
    }

    deleteProfile(id: number) {
        return this.httpClient.delete(`${environment.apiBaseUrl}/profiles/${id}`)
    }
}