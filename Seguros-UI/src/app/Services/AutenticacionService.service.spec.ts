/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AutenticacionServiceService } from './AutenticacionService.service';

describe('Service: AutenticacionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AutenticacionServiceService]
    });
  });

  it('should ...', inject([AutenticacionServiceService], (service: AutenticacionServiceService) => {
    expect(service).toBeTruthy();
  }));
});
