import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { Event, EventService, Ticket } from '../services/event.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { pluck } from 'rxjs';
import { NgFor, NgIf } from '@angular/common';
import { TicketService } from '../services/ticket.service';
import { OrderService } from '../services/order.service';
@Component({
  selector: 'app-event',
  imports: [NgIf, NgFor],
  templateUrl: './event.component.html',
  styleUrl: './event.component.css',
})
export class EventComponent implements OnInit {
  event: Event | null = null;
  tickets: Ticket[] = [];
  selectedTicket: Ticket | null = null;
  qty: number = 1;
  constructor(
    private eventService: EventService,
    private route: ActivatedRoute,
    private ticketService: TicketService,
    private orderService: OrderService
  ) {}
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.eventService.getEventById(parseInt(id!)).subscribe((event) => {
      this.event = event;
    });
    this.ticketService.getTicketsByEvent(parseInt(id!)).subscribe((tickets) => {
      this.tickets = tickets;
    });
  }
  updateQty(e: any): void {
    this.qty = e.target.value;
  }
  clear() {
    console.log('close');
    this.selectedTicket = null;
    this.qty = 1;
  }
  submit() {
    console.log('submit');
    if (this.selectedTicket) {
      this.orderService
        .createOrder(this.selectedTicket.id, this.qty)
        .subscribe((order) => {
          console.log('order', order);
        });
    }
  }
}
