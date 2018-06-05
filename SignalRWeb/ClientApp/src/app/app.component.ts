import {Component} from '@angular/core';
import {Message} from 'primeng/api';
import { HubConnection } from '@aspnet/signalr';

@Component({selector: 'app-root', templateUrl: './app.component.html', styleUrls: ['./app.component.css']})
export class AppComponent {
  public _hubConnection : signalR.HubConnection;

  msgs : Message[] = [];

  constructor() {}

  ngOnInit() : void {    
    this._hubConnection = new HubConnection('http://localhost:49446/notifyhub');
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log(err));
  
    this
      ._hubConnection
      .on('BroadcastMessage', (type : string, payload : string) => {
        this.msgs.push({severity: type, summary: payload});
      });
  }
}