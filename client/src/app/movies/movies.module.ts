import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoviesComponent } from './movies.component';
import { MoviesServicesService } from './services/MoviesServices.service';


@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [MoviesComponent],
  exports: [MoviesComponent],
  providers: [MoviesServicesService]
})
export class MoviesModule { }
