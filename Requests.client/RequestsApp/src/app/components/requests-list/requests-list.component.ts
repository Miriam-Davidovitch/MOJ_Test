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
  errorMessage: string = '';
  isLoading: boolean = false;

  constructor(private requestsService: RequestsService) { }

  ngOnInit(): void {
    this.loadRequests();
  }

  loadRequests(): void {
    this.isLoading = true;
    this.errorMessage = '';
    
    this.requestsService.getAllRequests().subscribe({
      next: (data) => {
        this.requests = data;
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = 'שגיאה בטעינת הנתונים. אנא נסו שוב מאוחר יותר.';
        this.isLoading = false;
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

  retryLoadRequests(): void {
    this.loadRequests();
  }
}
