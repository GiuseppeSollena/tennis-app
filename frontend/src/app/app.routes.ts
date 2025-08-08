import { Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';


export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { 
        path: 'home',
        loadComponent: () => import('./features/home/home.component').then(m => m.HomeComponent)
      },
      {
        path: 'teams',
        loadComponent: () => import('./features/teams/teams.component').then(m => m.TeamsComponent)
      }
    ]
  },
  { path: '**', redirectTo: 'home' }
];
