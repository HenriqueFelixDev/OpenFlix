import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http"
import { Observable } from "rxjs";

import { environment } from "src/environments/environment";
import { IAuthResult } from "../models/auth/auth-result";
import { Profile } from "../models/profiles/profile";

const PROFILE_KEY = 'auth:profile'
const TOKEN_KEY = 'auth:token'

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    constructor(private httpClient: HttpClient) { }

    login(username: string, password: string): Observable<IAuthResult> {
        const base64Token = btoa(`${username}:${password}`);

        this.logout()

        return this.httpClient
            .get<IAuthResult>(`${environment.apiBaseUrl}/auth/login`, { 
                headers: {
                    "Authorization": `Basic ${base64Token}`
                }
            })
    }

    signUp(username: string, email: string, password: string): Observable<IAuthResult> {
        const data = {
            username,
            email,
            password
        }

        return this.httpClient
            .post<IAuthResult>(`${environment.apiBaseUrl}/auth/signup`, data)
    }

    isAuthenticated(): boolean {
        return this.token !== null
    }

    setToken(token: string) {
        localStorage.setItem(TOKEN_KEY, token)
    }

    get token() : string | null {
        return localStorage.getItem(TOKEN_KEY)
    }

    setCurrentProfile(profile: Profile) {
        sessionStorage.setItem(PROFILE_KEY, JSON.stringify(profile))
    }

    get currentProfile(): Profile | null {
        const profileSerialized = sessionStorage.getItem(PROFILE_KEY);

        if (!profileSerialized) {
            return null
        }

        return JSON.parse(profileSerialized)
    }

    logout() {
        localStorage.removeItem(TOKEN_KEY)
        sessionStorage.removeItem(PROFILE_KEY)
    }
}