import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RequestsService } from '../../services/requests.service';

@Component({
  selector: 'app-add-request',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-request.component.html',
  styleUrls: ['./add-request.component.css']
})
export class AddRequestComponent {
  @Output() requestAdded = new EventEmitter<void>();
  @Output() cancel = new EventEmitter<void>();

  requestorName: string = '';
  requestTopic: string = '';
  requestDescription: string = '';
  isSubmitting: boolean = false;
  
  errors: { [key: string]: string } = {};
  successMessage: string = '';
  touched: { [key: string]: boolean } = {};

  constructor(private requestsService: RequestsService) {}

  onSubmit(): void {
    this.clearMessages();
    
    // סימון כל השדות כמושים
    this.touched['requestorName'] = true;
    this.touched['requestDescription'] = true;
    
    // בדיקת כל השדות
    this.validateField('requestorName');
    this.validateField('requestDescription');
    
    if (!this.validateForm()) {
      return;
    }

    this.isSubmitting = true;
    
    const newRequest = {
      requestorName: this.requestorName.trim(),
      requestTopic: this.requestTopic.trim(),
      requestDescription: this.requestDescription.trim()
    };

    this.requestsService.createRequest(newRequest).subscribe({
      next: (response) => {
        this.successMessage = 'הבקשה נוצרה בהצלחה!';
        setTimeout(() => {
          this.resetForm();
          this.requestAdded.emit();
        }, 1500);
      },
      error: (error) => {
        this.handleServerError(error);
        this.isSubmitting = false;
      }
    });
  }

  onCancel(): void {
    this.resetForm();
    this.cancel.emit();
  }

  private validateForm(): boolean {
    let isValid = true;

    if (!this.requestorName.trim()) {
      this.errors['requestorName'] = 'שם המבקש חובה';
      isValid = false;
    }

    if (this.requestDescription.length > 255) {
      this.errors['requestDescription'] = 'התיאור ארוך מדי (מקסימום 255 תווים)';
      isValid = false;
    }

    return isValid;
  }

  private handleServerError(error: any): void {
    if (error.error && error.error.Message) {
      this.errors['server'] = error.error.Message;
    } else {
      this.errors['server'] = 'שגיאה ביצירת הבקשה';
    }
  }

  private clearMessages(): void {
    this.errors = {};
    this.successMessage = '';
  }

  onFieldBlur(fieldName: string): void {
    this.touched[fieldName] = true;
    this.validateField(fieldName);
  }

  onFieldChange(fieldName: string): void {
    if (this.touched[fieldName]) {
      this.validateField(fieldName);
    }
  }

  private validateField(fieldName: string): void {
    delete this.errors[fieldName];

    switch (fieldName) {
      case 'requestorName':
        if (!this.requestorName.trim()) {
          this.errors['requestorName'] = 'שם המבקש חובה';
        }
        break;
      case 'requestDescription':
        if (this.requestDescription.length > 255) {
          this.errors['requestDescription'] = 'התיאור ארוך מדי (מקסימום 255 תווים)';
        }
        break;
    }
  }

  private resetForm(): void {
    this.requestorName = '';
    this.requestTopic = '';
    this.requestDescription = '';
    this.isSubmitting = false;
    this.touched = {};
    this.clearMessages();
  }
}