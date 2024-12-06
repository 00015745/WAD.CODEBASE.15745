import { Component, OnInit } from '@angular/core';
import { Order, OrderService } from '../services/order.service';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-orders',
  imports: [NgFor],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css',
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  constructor(private orderService: OrderService) {}
  ngOnInit(): void {
    this.orderService.getOrders().subscribe((orders) => {
      this.orders = orders;
    });
  }
}
