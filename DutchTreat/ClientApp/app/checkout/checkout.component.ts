import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { DataService } from '../shared/dataService';

@Component({
  selector: 'checkout',
  templateUrl: 'checkout.component.html',
  styleUrls: ['checkout.component.css']
})
export class Checkout {
  errorMessage: string = "";

  constructor(public data: DataService, private router: Router) { }

  onCheckout() {
    this.data.checkout()
      .subscribe(success => {
        if (success) {
          this.router.navigate(['']);
        }
      }, err => this.errorMessage = "Failed to save order");
  }
}