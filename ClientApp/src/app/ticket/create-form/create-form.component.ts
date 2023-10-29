import { TicketService } from './../services/ticket.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-create-form',
  templateUrl: './create-form.component.html',
  styleUrls: ['./create-form.component.css']
})
export class CreateFormComponent {
  ticketForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private ticketService: TicketService,
    private router : Router
  )
  {
    this.ticketForm = this.fb.group({
      phoneNumber: ['', Validators.required],
      status: ['', Validators.required],
      governorateId: ['', Validators.required],
      districtId: ['', Validators.required],
      cityId: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.ticketForm.valid) {
      const ticketData = this.ticketForm.value;
      this.ticketService
        .createTicket(ticketData)
        .subscribe(
          (response) => {
            console.log('Ticket added successfully', response);
            this.router.navigate(['tickets']);
          },
          (error) => {
            console.error('Error adding ticket', error);
          }
      );
    }
  }
}
