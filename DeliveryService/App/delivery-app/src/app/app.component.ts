import { Component } from '@angular/core';
import {CostService} from './shared/cost.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Delivery App';
  cost = 0;

  constructor (private costService : CostService) {}

  calculateCost(orderId : number) : void {
    this.costService.getCost(orderId).subscribe((data:any) => {this.cost=data; console.log(data);});
    
  }
}
