import { Routes } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { EventComponent } from './event/event.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { OrdersComponent } from './orders/orders.component';
import { NewEventComponent } from './new-event/new-event.component';
import { NewTicketComponent } from './new-ticket/new-ticket.component';

export const routes: Routes = [
  {
    path: '',
    component: IndexComponent,
  },
  {
    path: 'events/new',
    component: NewEventComponent,
  },
  {
    path: 'events/:id',
    component: EventComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'orders',
    component: OrdersComponent,
  },
  {
    path: 'tickets/:eventId/new',
    component: NewTicketComponent,
  },
];
