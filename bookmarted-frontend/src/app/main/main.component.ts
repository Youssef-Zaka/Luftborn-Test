import { Component, OnInit } from '@angular/core';
import { NgForOf, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StoreService } from '../api/store.service';
import { BookAvailabilityService } from '../api/book-availability.service';

interface Store {
  storeId: number;
  name: string;
}

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

@Component({
  selector: 'app-main',
  standalone: true,
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
  imports: [FormsModule, NgForOf, NgIf]
})
export class MainComponent implements OnInit {
  stores: Store[] = [];
  bookAvailabilities: BookAvailability[] = [];
  selectedStoreId: number | null = null;

  constructor(
    private storeService: StoreService,
    private bookAvailabilityService: BookAvailabilityService
  ) {}

  ngOnInit() {
    this.loadStores();
  }

  loadStores() {
    this.storeService.getStores().subscribe({
      next: (data) => (this.stores = data),
      error: (err) => console.error('Error loading stores', err)
    });
  }

  onStoreChange() {
    if (this.selectedStoreId) {
      this.bookAvailabilityService.getBooksByStore(this.selectedStoreId).subscribe({
        next: (data) => (this.bookAvailabilities = data),
        error: (err) => console.error('Error loading books', err)
      });
    }
  }
}
