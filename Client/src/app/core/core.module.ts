import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { TestErrorComponent } from './test-error/test-error.component';
import { NotFonundComponent } from './not-fonund/not-fonund.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [NavbarComponent, TestErrorComponent, NotFonundComponent, ServerErrorComponent],
  imports: [
    CommonModule,
    RouterModule,
    ToastrModule.forRoot({
      positionClass:'toast-bottom-right',
      preventDuplicates:true
    })
  ],
  exports:[NavbarComponent]
})
export class CoreModule { }
