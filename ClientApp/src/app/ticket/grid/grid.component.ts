import { HandleTicketModel } from './../_Models/HandleTicket';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Ticket } from 'src/app/ticket/_Models/Ticket';
import { TicketService } from '../services/ticket.service';
import { ApiResponse } from 'src/app/_Models/ApiResponse';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css'],
})
export class GridComponent implements OnInit {
  constructor(private ticketService: TicketService) {}

  tickets: Ticket[] = [];
  page:number = 0;
  pageSize:number = 0;
  
  ngOnInit(): void {
    this.updateButtonSeverity();
  }

  loadTickets() {
    this.ticketService
      .getTickets(this.pageSize, this.page)
      .subscribe((response: ApiResponse) => {
        this.tickets = response.result;
      });
  }
  onLazyLoad(event: any) {
    this.page = event.first / event.rows + 1;
    this.pageSize = event.rows;
    this.loadTickets();
  }

  getSeverity(ticket: Ticket): string {
    if (ticket.status === 'Handled') {
      return 'success';
    } else {
      return 'warning';
    }
  }

  HandleTicket(ticket : Ticket) {

    const data: HandleTicketModel = {
      id: ticket.id,
      status : "Handled"
    };

    this.ticketService
      .handleTicket(data)
      .subscribe((response: ApiResponse) => {
        this.loadTickets();
      });
  }


  getButtonSeverity(minutesDifference: number): string {
    if (minutesDifference <= 15) {
      return 'warning';
    } else if (minutesDifference <= 30) {
      return 'success';
    } else if (minutesDifference <= 45) {
      return 'primary';
    } else if (minutesDifference <= 60) {
      return 'danger';
    } else {
      return 'secondary';
    }
  }

  updateButtonSeverity() {
    setInterval(() => {
      this.tickets.forEach(ticket => {

          const minutesDifference = Math.floor(
            (new Date().getTime() - new Date(ticket.createdDate).getTime()) / (1000 * 60)
          );


          ticket.buttonSeverity = this.getButtonSeverity(minutesDifference);


          if (minutesDifference > 60 && ticket.status === "UnHandled") {
            const data: HandleTicketModel = {
              id: ticket.id,
              status : "Handled"
            };

            this.ticketService
              .handleTicket(data)
              .subscribe((response: ApiResponse) => {
                console.log('Ticket Handled because 60 minutes passed on its creation.')
              });
          }


          this.loadTickets();

      });
    }, 1000 * 5);
  }
}
