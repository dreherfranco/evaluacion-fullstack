import { Component, OnInit } from '@angular/core';
import { Client } from 'src/app/models/client/Client';
import { ClientService } from 'src/app/services/client-service/client.service';

@Component({
  selector: 'app-clients-list',
  templateUrl: './clients-list.component.html',
  styleUrls: ['./clients-list.component.css'],
})
export class ClientsListComponent implements OnInit {
  clients: Client[] = [];
  constructor(private _clientService: ClientService) {}

  ngOnInit(): void {
    this._clientService.getAll().subscribe({
      next: (res) => this.clients = res
    });
  }
}
