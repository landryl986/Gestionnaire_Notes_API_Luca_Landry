import { TestBed } from '@angular/core/testing';

import { PhilialService } from './philial.service';

describe('PhilialService', () => {
  let service: PhilialService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PhilialService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
