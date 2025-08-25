import { Component, OnInit } from '@angular/core';
import { RequestsService } from '../../services/requests.service';
import { CommonModule } from '@angular/common';
import { Request } from '../../models/request.model';
import { AddRequestComponent } from '../add-request/add-request.component';

@Component({
  selector: 'app-requests-list',
  standalone: true,
  imports: [CommonModule, AddRequestComponent],
  templateUrl: './requests-list.component.html',
  styleUrls: ['./requests-list.component.css']
})
export class RequestsListComponent implements OnInit {
  requests: Request[] = [];
  showAddForm: boolean = false;

  constructor(private requestsService: RequestsService) { }

  ngOnInit(): void {
    this.loadRequests();
  }

  loadRequests(): void {
    this.requestsService.getAllRequests().subscribe({
      next: (data) => {
        this.requests = data;
        console.log(this.requests);
      },
      error: (error) => {
        console.error('שגיאה בטעינת הנתונים:', error);
      }
    });
  }

  showAddRequestForm(): void {
    this.showAddForm = true;
  }

  onRequestAdded(): void {
    this.showAddForm = false;
    this.loadRequests();
  }

  onCancelAdd(): void {
    this.showAddForm = false;
  }
}
