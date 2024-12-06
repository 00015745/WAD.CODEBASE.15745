import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  apiUrl = 'https://localhost:7025/api/Events';
  constructor(private http: HttpClient) {}

  // Get all events
  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(this.apiUrl);
  }

  // Get event by ID
  getEventById(eventId: number): Observable<Event> {
    return this.http.get<Event>(`${this.apiUrl}/${eventId}`);
  }

  // Create a new event
  createEvent(eventData: CreateEventDto): Observable<Event> {
    return this.http.post<Event>(this.apiUrl, eventData);
  }

  // Update an event
  updateEvent(eventId: number, eventData: UpdateEventDto): Observable<Event> {
    return this.http.put<Event>(`${this.apiUrl}/${eventId}`, eventData);
  }

  // Delete an event
  deleteEvent(eventId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${eventId}`);
  }
}
export interface Event {
  id: number;
  title: string;
  description: string;
  startDate: string; // ISO Date string
  endDate: string; // ISO Date string
}

export interface Ticket {
  id: number;
  eventId: number;
  price: number;
  quantityAvailable: number;
  event?: Event;
}

export interface CreateEventDto {
  title: string;
  description: string;
  startDate: string; // ISO Date string
  endDate: string; // ISO Date string
}

export interface UpdateEventDto {
  title?: string;
  description?: string;
  startDate?: string; // ISO Date string
  endDate?: string; // ISO Date string
}
