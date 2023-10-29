import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridComponent } from './grid/grid.component';
import { RouterModule, Routes } from '@angular/router';
import { TagModule } from 'primeng/tag';
import { DataViewModule } from 'primeng/dataview';
import { ButtonModule } from 'primeng/button';
import { CreateFormComponent } from './create-form/create-form.component';
import { ReactiveFormsModule } from '@angular/forms';
const ticketRoutes: Routes = [
  { path: '', component: GridComponent },
  { path: 'create', component: CreateFormComponent },
  // { path: 'details/:id', component: TicketDetailsComponent },
];


@NgModule({
  declarations: [
    GridComponent,
    CreateFormComponent
  ],
  imports: [
    CommonModule,
    TagModule,
    DataViewModule,
    ButtonModule,
    ReactiveFormsModule,
    RouterModule.forChild(ticketRoutes)
  ],
  exports : [
    GridComponent
  ]
})
export class TicketModule { }
