import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Store {
  storeId: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private apiUrl = 'https://localhost:7008/api/Store';

  constructor(private http: HttpClient) { }

  getStores(): Observable<Store[]> {
    return this.http.get<Store[]>(this.apiUrl);
  }

  getStoreById(id: number): Observable<Store> {
    return this.http.get<Store>(`${this.apiUrl}/${id}`);
  }
}
