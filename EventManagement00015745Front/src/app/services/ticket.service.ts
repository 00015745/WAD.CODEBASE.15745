import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Event } from './event.service';
export interface Ticket {
  id: number;
  price: number;
  quantityAvailable: number;
  eventId: number;
  event?: Event;
}
@Injectable({
  providedIn: 'root',
})
export class TicketService {
  apiUrl = 'https://localhost:7025/api/Tickets';

  constructor(private http: HttpClient) {}

  // Fetch all tickets
  getAllTickets(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(this.apiUrl);
  }

  // Fetch tickets for a specific event by event ID
  getTicketsByEvent(eventId: number): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(`${this.apiUrl}/${eventId}`);
  }

  // Fetch a single ticket by its ID
  getTicketById(id: number): Observable<Ticket> {
    return this.http.get<Ticket>(`${this.apiUrl}/${id}`);
  }

  // Create a new ticket
  createTicket(ticket: {
    eventId: string | number;
    price: string | number;
    quantityAvailable: string | number;
  }): Observable<Ticket> {
    return this.http.post<Ticket>(this.apiUrl, ticket);
  }

  // Update an existing ticket
  updateTicket(ticket: Ticket): Observable<Ticket> {
    return this.http.put<Ticket>(`${this.apiUrl}/${ticket.id}`, ticket);
  }

  // Delete a ticket by ID
  deleteTicket(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
