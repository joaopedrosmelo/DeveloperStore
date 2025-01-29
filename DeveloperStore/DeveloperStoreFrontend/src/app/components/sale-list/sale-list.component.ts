import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Sale } from '../../models/sale.model';

@Component({
  selector: 'app-sale-list',
  templateUrl: './sale-list.component.html',
  styleUrls: ['./sale-list.component.css']
})
export class SaleListComponent implements OnInit {
  sales: Sale[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getSales().subscribe(data => {
      this.sales = data;
    });
  }
}
