import { Component } from '@angular/core';
import { TicketService } from '../services/ticket.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CreateEventDto } from '../services/event.service';

@Component({
  selector: 'app-new-ticket',
  imports: [],
  templateUrl: './new-ticket.component.html',
  styleUrl: './new-ticket.component.css',
})
export class NewTicketComponent {
  constructor(
    private ticketService: TicketService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  data = {
    price: '',
    quantityAvailable: '',
  };
  handleChange(event: any) {
    //@ts-ignore
    this.data[event.target.name] = event.target.value;
  }
  submit() {
    console.log('submit');
    this.ticketService
      .createTicket({
        price: parseFloat(this.data.price),
        quantityAvailable: parseInt(this.data.quantityAvailable),
        eventId: parseInt(this.route.snapshot.paramMap.get('id')!),
      })
      .subscribe({
        next: (data) => {
          console.log(data);
          this.router.navigate(['/']);
        },
        error: (err) => {
          console.log(err);
        },
      });
  }
}
