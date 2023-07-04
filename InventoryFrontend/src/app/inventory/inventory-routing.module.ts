import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PageNotFoundComponent } from '../shared/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path:"",
    component:DashboardComponent,
    title:"Admin - Dashboard",
    children:[
      {
        path:"",
        redirectTo:"inventory",
        pathMatch:"full"
      },
      {
        path:"inventory",
        component:PageNotFoundComponent
      },
      {
        path:"warehouses",
        component:PageNotFoundComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryRoutingModule { }
