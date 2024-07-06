import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./shared/components/layout/layout.component'),
    children: [
      {
        path: 'inicio',
        loadComponent: () =>
          import('./shopping/home/home.component').then((m) => m.HomeComponent),
      },
      {
        path: 'productos',
        loadComponent: () =>
          import('./shopping/products/products.component').then(
            (m) => m.ProductsComponent
          ),
      },
      {
        path: 'contacto',
        loadComponent: () =>
          import('./shopping/contact/contact.component').then(
            (m) => m.ContactComponent
          ),
      },
      {
        path: '',
        redirectTo: 'inicio',
        pathMatch: 'full',
      },
      {
        path: '**',
        redirectTo: 'inicio',
      },
    ],
  },
];
