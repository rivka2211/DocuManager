import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = 'http://your-api-url'; // replace with actual API endpoint

  constructor(private http: HttpClient) { }

  // User management methods
  addUser(user: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/api/User`, user);
  }

  updateUser(id: number, user: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/api/User/${id}`, user);
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/api/User/${id}`);
  }

  updateUserRole(id: number, role: string): Observable<any> {
    return this.http.patch(`${this.baseUrl}/api/User/${id}/role`, role);
  }

  // File management methods
  addFileToUser(id: number, file: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/api/User/${id}/files`, file);
  }

  deleteFileFromUser(id: number, fileId: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/api/User/${id}/files/${fileId}`);
  }

  updateFileName(id: number, fileId: number, name: string): Observable<any> {
    return this.http.patch(`${this.baseUrl}/api/User/${id}/files/${fileId}`, name);
  }

  // Additional admin functions
  getActivityReports(): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/reports/activity`);
  }

  getSystemSettings(): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/settings`);
  }

  updateSystemSettings(settings: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/api/settings`, settings);
  }

  getAllFiles(): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/files`);
  }
}
