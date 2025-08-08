import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiUrls } from '../configs/config';

export interface Team {
  name: string;
  players: string[];
}

@Injectable({ providedIn: 'root' })
export class TeamsService {
  private readonly apiUrl = ApiUrls.teams;

  constructor(private http: HttpClient) {}

  saveTeams(teams: Team[]): Observable<any> {
    return this.http.post(this.apiUrl, { teams });
  }
}
