import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Book {
  bookId: number;
  title: string;
  description: string;
  genre: string;
  condition: string;
}

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'https://localhost:7008/api/Book';

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }

  getBookById(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/${id}`);
  }
}
