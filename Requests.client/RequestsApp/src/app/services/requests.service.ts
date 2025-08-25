import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Request } from '../models/request.model';

@Injectable({
  providedIn: 'root'
})
export class RequestsService {
  private apiUrl = 'http://localhost:5171/api';
  
  constructor(private http: HttpClient) { }

  getAllRequests(): Observable<Request[]> {
    return this.http.get<Request[]>(`${this.apiUrl}/Requests`);
  }

  createRequest(request: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Requests`, request);
  }
}
