import { TestBed } from '@angular/core/testing';

import { AcccountService } from './accounts.service';

describe('UsersService', () => {
  let service: AcccountService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AcccountService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
