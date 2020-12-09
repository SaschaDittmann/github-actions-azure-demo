import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Employee } from './employee';
import { environment } from './../../environments/environment';

@Injectable()
export class EmployeeService {
  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    const params = new HttpParams()
      .set('code', environment.apiKey);
    return this.http.get<Employee[]>(environment.apiUrl + 'Get', { params })
      .pipe(
        catchError(this.handleError)
      );
  }

  getEmployee(id: string, cityName: string): Observable<Employee> {
    if (id === '') {
      return of(this.initializeEmployee());
    }
    const params = new HttpParams()
      .set('code', environment.apiKey);
    const url = `${environment.apiUrl + 'Get'}/${id}/${cityName}`;
    return this.http.get<Employee>(url, { params })
      .pipe(
        catchError(this.handleError)
      );
  }

  createEmployee(employee: Employee): Observable<Employee> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const params = new HttpParams()
      .set('code', environment.apiKey);
    return this.http.post<Employee>(environment.apiUrl + 'CreateOrUpdate', employee, { headers: headers, params })
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteEmployee(id: string, cityname: string): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const params = new HttpParams()
      .set('code', environment.apiKey);
    const url = `${environment.apiUrl + 'Delete'}/${id}/${cityname}`;
    return this.http.delete<Employee>(url, { headers: headers, params })
      .pipe(
        catchError(this.handleError)
      );
  }

  updateEmployee(employee: Employee): Observable<Employee> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const params = new HttpParams()
      .set('code', environment.apiKey);
    const url = environment.apiUrl + 'CreateOrUpdate';
    return this.http.put<Employee>(url, employee, { headers: headers, params })
      .pipe(
        map(() => employee),
        catchError(this.handleError)
      );
  }

  private handleError(err: any) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }

  private initializeEmployee(): Employee {
    return {
      id: '',
      name: '',
      address: '',
      gender: '',
      company: '',
      designation: '',
      cityname: ''
    };
  }
}
