/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PolizaService } from './poliza.service';

describe('Service: Poliza', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PolizaService]
    });
  });

  it('should ...', inject([PolizaService], (service: PolizaService) => {
    expect(service).toBeTruthy();
  }));
});
