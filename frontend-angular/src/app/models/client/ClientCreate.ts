export class ClientCreate{
    name: string;
    lastName: string;
    address: string;
     
    constructor(name: string, lastName: string, address: string){
        this.name = name;
        this.lastName = lastName;
        this.address = address;
    }
}