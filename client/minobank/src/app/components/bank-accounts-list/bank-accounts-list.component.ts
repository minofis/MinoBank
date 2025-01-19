import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { IBankAccount } from '../../models/bankAccount';
import { BankAccountsService } from '../../services/bank-accounts.service';

@Component({
  selector: 'app-bank-accounts-list',
  templateUrl: './bank-accounts-list.component.html',
  styleUrl: './bank-accounts-list.component.scss'
})
export class BankAccountsListComponent {
  public bankAccounts$?: Observable<IBankAccount[]>;

  constructor(private _bankAccountsService: BankAccountsService) {}

  public ngOnInit(): void
  {
    this.bankAccounts$ = this._bankAccountsService.getBankAccounts();
  }
}