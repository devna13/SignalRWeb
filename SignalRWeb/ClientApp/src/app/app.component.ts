import {Component} from '@angular/core';
import {Message} from 'primeng/api';
import {HubConnection, HubConnectionBuilder, IHubProtocol} from '@aspnet/signalr';

@Component({selector: 'app-root', templateUrl: './app.component.html', styleUrls: ['./app.component.css']})
export class AppComponent {
  public _hubConnection : HubConnection;

  msgs : Message[] = [];

  constructor() {}

  ngOnInit() : void {
    let builder = new HubConnectionBuilder();
    // this._hubConnection =
    // builder.withUrl('https://localhost:44374/notification/notify').build();
    this._hubConnection = builder
      .withUrl('/notifyhub')      
      .build();

    this
      ._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error :', err));;
    // this._hubConnection   .start()   .then(() => console.log('Connection
    // started!'))   .catch(err => console.log('Error while establishing connection
    // :('));

    this
      ._hubConnection
      .on('BroadcastMessage', (type : string, payload : string) => {

        this
          .msgs
          .push({severity: type, summary: payload});
      });
  }
}