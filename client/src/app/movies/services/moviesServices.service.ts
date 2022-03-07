import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';

import { HttpClient } from '@angular/common/http';
import { Movie } from '../models/movie.model';

@Injectable()
export class MoviesServicesService {
  private static readonly url = environment.apiBaseUrl + "Movies";
  private moviesSubject: ReplaySubject<Movie[]> = new ReplaySubject(1);
  private hasMovieRequestBeenSet: boolean = false;

  get movies$(): Observable<Movie[]> {
    if (!this.hasMovieRequestBeenSet) {
      this.hasMovieRequestBeenSet = true;
      this.httpClient.get<Movie[]>(MoviesServicesService.url).subscribe(res=>{
        console.log("loaded");

        this.moviesSubject.next(res);
      });
    }
    return this.moviesSubject.asObservable();
  }

  constructor(private httpClient: HttpClient) {}
}
