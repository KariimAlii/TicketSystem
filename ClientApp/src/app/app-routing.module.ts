import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  // { path: '', redirectTo: '/home', pathMatch: 'full' }, // Default route
  // { path: 'home', component: HomeComponent },
  // { path: 'about', component: AboutComponent },
  { path: 'tickets', loadChildren: () => import('./ticket/ticket.module').then((m) => m.TicketModule) },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

