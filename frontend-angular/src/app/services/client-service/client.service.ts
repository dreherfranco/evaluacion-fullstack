import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Api } from 'src/app/commons/Api';
import { Observable } from 'rxjs';
import { ClientCreate } from 'src/app/models/client/ClientCreate';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  public url: string;
  public headers =  new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private _http: HttpClient) 
  {
    this.url = Api.url + "/clientes";
  }

  getAll(): Observable<any>{
    return this._http.get(this.url, { headers: this.headers });
  }

  create(client: ClientCreate): Observable<any>{
    let params = JSON.stringify(client);
    return this._http.post(this.url, params, { headers: this.headers });
  }

}
