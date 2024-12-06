import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Event, EventService } from '../services/event.service';
import { DatePipe, NgFor, NgIf } from '@angular/common';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-index',
  imports: [MatTableModule, MatPaginatorModule, NgIf],
  templateUrl: './index.component.html',
  styleUrl: './index.component.css',
})
export class IndexComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['title', 'description', 'startDate', 'endDate'];
  dataSource: MatTableDataSource<Event> | null = null;
  //@ts-ignore
  @ViewChild(MatPaginator) paginator: MatPaginator;
  //@ts-ignore
  @ViewChild(MatSort) sort: MatSort;
  user;
  constructor(
    private eventService: EventService,
    private _liveAnnouncer: LiveAnnouncer,
    private userService: UserService
  ) {
    this.user = this.userService.currentUser;
  }
  ngAfterViewInit() {
    if (this.dataSource) {
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }
  }
  ngOnInit() {
    this.loadEvents();
  }

  loadEvents() {
    this.eventService.getEvents().subscribe({
      next: (data) => (this.dataSource = new MatTableDataSource(data)),
      error: (err) => console.error('Error fetching events:', err),
    });
  }
  announceSortChange(sortState: any) {
    // This example uses English messages. If your application supports
    // multiple language, you would internationalize these strings.
    // Furthermore, you can customize the message to add additional
    // details about the values being sorted.
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }
}
