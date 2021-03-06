import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {TestErrorComponent} from './core/test-error/test-error.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { NotFonundComponent } from './core/not-fonund/not-fonund.component';


const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'test-error',component:TestErrorComponent},
  {path:'servererror',component:ServerErrorComponent},
  {path:'notfound',component:NotFonundComponent},
  {path:'shop',loadChildren:()=>import('./shop/shop.module').then(m=>m.ShopModule)},
  {path:'**',redirectTo:'',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
