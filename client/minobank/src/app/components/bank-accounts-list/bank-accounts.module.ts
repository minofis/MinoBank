import { NgModule } from '@angular/core';
import { BankAccountsListComponent } from './bank-accounts-list.component';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  exports: [
    BankAccountsListComponent
  ],
  declarations: [
    BankAccountsListComponent
  ],
  imports: [
    BrowserModule
  ]
})
export class BankAccountsModule { }