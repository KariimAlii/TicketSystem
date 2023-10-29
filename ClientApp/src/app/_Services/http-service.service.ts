import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class HttpService {
    private apiUrl = 'http://localhost:5116/api';

    constructor(private http: HttpClient) { }

    //! GET Request
    get<T>(endpoint: string , PageSize:number , Page:number): Observable<T> {
      const url = `${this.apiUrl}/${endpoint}`;
      console.log(
        'url:   ' + url
      )
      let params = new HttpParams()
        .set('Page', Page.toString())
        .set('PageSize', PageSize.toString());

      return this.http.get<T>(url, { params });
    }

    //! POST Request
    post<T>(endpoint: string, data: any): Observable<T> {
      const url = `${this.apiUrl}/${endpoint}`;
      return this.http.post<T>(url, data);
    }

    //! PUT Request
    put<T>(endpoint: string, data: any): Observable<T> {
      const url = `${this.apiUrl}/${endpoint}`;
      return this.http.put<T>(url, data);
    }

    //! DELETE Request
    delete<T>(endpoint: string): Observable<T> {
      const url = `${this.apiUrl}/${endpoint}`;
      return this.http.delete<T>(url);
    }
}
