import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLoginComponent } from './core/admin-login/admin-login.component';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path:"",
    redirectTo:"admin-login",
    pathMatch:"full"
  },
  {
    path:"admin-login",
    component:AdminLoginComponent,
    title:"Login"
  },
  {
    path:"admin/dashboard",
    loadChildren: () => import("./inventory/inventory.module").then(mod=>mod.InventoryModule),
    // canActivate:[DashboardGuardService]
  }
  ,
  {
    path:"**",
    component:PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
