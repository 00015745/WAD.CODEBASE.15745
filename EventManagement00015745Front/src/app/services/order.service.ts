import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ticket } from './event.service';
export interface Order {
  id: number;
  userId: number;
  ticketId: number;
  quantity: number;
  orderDate: Date;
  ticket?: Ticket;
}
@Injectable({
  providedIn: 'root',
})
export class OrderService {
  apiUrl = 'https://localhost:7025/api/Orders'; // The endpoint for orders

  constructor(private http: HttpClient) {}

  // Fetch orders for the current user
  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiUrl}`); // Assuming the API endpoint is like this
  }

  // Create a new order
  createOrder(ticketId: number, quantity: number): Observable<Order> {
    return this.http.post<Order>(this.apiUrl, {
      ticketId,
      quantity,
    }); // Send order data to create a new order
  }

  // Delete an order by ID
  deleteOrder(orderId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${orderId}`); // Send delete request to API
  }
}
