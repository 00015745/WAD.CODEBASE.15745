import { Component } from '@angular/core';
import { CreateEventDto, EventService } from '../services/event.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-event',
  imports: [],
  templateUrl: './new-event.component.html',
  styleUrl: './new-event.component.css',
})
export class NewEventComponent {
  constructor(private eventService: EventService, private router: Router) {}
  data: CreateEventDto = {
    title: '',
    description: '',
    startDate: '',
    endDate: '',
  };
  handleChange(event: any) {
    //@ts-ignore
    this.data[event.target.name] = event.target.value;
  }
  submit() {
    this.eventService.createEvent(this.data).subscribe({
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
