import {Component} from '@angular/core';
import {Message} from 'primeng/api';
import {HubConnection} from '@aspnet/signalr';

@Component({selector: 'app-root', templateUrl: './app.component.html', styleUrls: ['./app.component.css']})
export class AppComponent {
  public _hubConnection : signalR.HubConnection;
  public _hubConnectionStocs : signalR.HubConnection;
  msgs : Message[] = [];
  stocs: any[] = [];
  constructor() {}

  ngOnInit() : void {
    this._hubConnection = new HubConnection('http://localhost:49446/notifyhub');
    this
      ._hubConnection.start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log(err));

    this
      ._hubConnection.on('BroadcastMessage', (type : string, payload : string) => {
        this.msgs.push({severity: type, summary: payload});
      });

    this._hubConnectionStocs = new HubConnection('http://localhost:49446/stochub');

    this._hubConnectionStocs.start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log(err));

    this._hubConnectionStocs.on('SetConnectionId', data => {
      console.log("ConnectionID : " + data);
      var result = this._hubConnectionStocs.invoke('ConnectGroup', 'Vivek', data);
      console.log(result);
    });

    this._hubConnectionStocs.on('ChangeStocValue', data => {
      console.log(JSON.stringify(data));
      this.stocs.push(data);
      //this.msgs.push({severity: "1", summary: data.value});
    });
  }
}
