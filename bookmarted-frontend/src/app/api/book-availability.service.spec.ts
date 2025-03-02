import { TestBed } from '@angular/core/testing';

import { BookAvailabilityService } from './book-availability.service';

describe('BookAvailabilityService', () => {
  let service: BookAvailabilityService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookAvailabilityService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
