import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, forkJoin, map, switchMap } from 'rxjs';
import { BookService } from './book.service';

interface BookAvailability {
  bookAvailabilityId: number;
  storeId: number;
  bookId: number;
  price: number;
  stock: number;
  title: string;
  description: string;
  genre: string;
  condition: string;
}

@Injectable({
  providedIn: 'root'
})
export class BookAvailabilityService {
  private apiUrl = 'https://localhost:7008/api/BookAvailability';

  constructor(private http: HttpClient, private bookService: BookService) {}

  getBooksByStore(storeId: number): Observable<BookAvailability[]> {
    return this.http.get<BookAvailability[]>(`${this.apiUrl}/store/${storeId}`).pipe(
      switchMap((availabilities) => {
        const bookRequests = availabilities.map((availability) =>
          this.bookService.getBookById(availability.bookId).pipe(
            map((book) => ({
              ...availability,
              title: book.title ?? 'Unknown Title',
              description: book.description ?? 'No description available',
              genre: book.genre ?? 'Unknown Genre',
              condition: book.condition ?? 'Unknown Condition'
            }))
          )
        );

        return forkJoin(bookRequests);
      })
    );
  }
}
