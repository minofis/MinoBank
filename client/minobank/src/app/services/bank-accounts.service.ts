import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBankAccount } from '../models/bankAccount';

@Injectable({
  providedIn: 'root'
})
export class BankAccountsService {

  constructor(private _httpClient: HttpClient){}
  
  baseServerUrl: string = "http://localhost:5205/minobank/bankaccounts/";

  public getBankAccounts(): Observable<IBankAccount[]>
  {
    return this._httpClient.get<IBankAccount[]>(this.baseServerUrl);
  }
}