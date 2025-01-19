import { NgModule } from '@angular/core';
import { BankAccountsListComponent } from './bank-accounts-list.component';
import { BrowserModule } from '@angular/platform-browser';
import { BankAccountsService } from '../../services/bank-accounts.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  exports: [
    BankAccountsListComponent
  ],
  declarations: [
    BankAccountsListComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [
    BankAccountsService
  ]
})
export class BankAccountsModule { }