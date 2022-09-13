import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClientCreate } from 'src/app/models/client/ClientCreate';
import { ClientService } from 'src/app/services/client-service/client.service';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css'],
})
export class ClientFormComponent implements OnInit {
  clientForm: FormGroup = new FormGroup({});

  constructor(private _clientService: ClientService, private _router: Router, ) {}

  ngOnInit(): void {
    this.clientForm = new FormGroup({
      name: new FormControl('', [
        Validators.required,
      ]),
      lastName: new FormControl('', [
        Validators.required,
      ]),
      address: new FormControl('', [
        Validators.required,
      ]),
    });

  }

  onSubmit(form: any) {
    var data = this.clientForm.getRawValue();
    var newClient = new ClientCreate(data.name, data.lastName, data.address);

    this._clientService.create(newClient).subscribe({
      next: (response) => {
        if (response.error) {
          console.log("error al crear el cliente");
        } else {
          this._router.navigate(['clientes']);
        }
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
