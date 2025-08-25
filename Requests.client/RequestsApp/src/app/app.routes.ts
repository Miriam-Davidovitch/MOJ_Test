import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: '/home' , pathMatch :'full'},

    { path: 'home', loadComponent: () => import('./components/home/home.component').then(m => m.HomeComponent) },

    { path: 'requestsList', loadComponent: () => import('./components/requests-list/requests-list.component').then(m => m.RequestsListComponent) },
    
    {path: '**' , redirectTo: '/home' }
];
