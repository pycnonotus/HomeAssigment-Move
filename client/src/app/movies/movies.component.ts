import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from './models/movie.model';
import { MoviesServicesService } from './services/MoviesServices.service';



@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {

  readonly movies$: Observable<Movie[]>
  constructor(moviesServicesService: MoviesServicesService) {
    this.movies$ = moviesServicesService.movies$;
  }

  ngOnInit() {
  }

}
