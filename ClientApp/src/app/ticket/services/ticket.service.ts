import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/_Models/ApiResponse';
import { HttpService } from 'src/app/_Services/http-service.service';
import { HandleTicketModel } from '../_Models/HandleTicket';
import { CreateTicketModel } from '../_Models/CreateTicketModel';

@Injectable({
  providedIn: 'root',
})
export class TicketService {
  constructor(private httpService: HttpService) {}

  // private cachedTickets: Ticket[] = [];

  getTickets(PageSize: number, Page: number): Observable<ApiResponse> {
    return this.httpService.get<ApiResponse>('Ticket/GetAll', PageSize, Page);
  }

  createTicket(data : CreateTicketModel) : Observable<ApiResponse>{
    return this.httpService.post<ApiResponse>('Ticket/Create', data);
  }

  handleTicket(data : HandleTicketModel): Observable<ApiResponse> {
    return this.httpService.put<ApiResponse>('Ticket/Handle', data);
  }
}
