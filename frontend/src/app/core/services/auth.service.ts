import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // Qui la logica vera del servizio auth
  isLoggedIn(): boolean {
    // Mock: true/false a seconda della logica reale
    return !!localStorage.getItem('token');
  }
  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
