import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgIf } from '@angular/common';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  pingResult?: string;

  constructor(private http: HttpClient) { }

  pingBackend() {
    this.http.get(`${environment.apiUrl}/ping`, { responseType: 'text' as const })
      .subscribe({
        next: res => this.pingResult = res,
        error: err => this.pingResult = 'Errore: ' + (err?.message ?? 'backend non raggiungibile')
      });
  }
}