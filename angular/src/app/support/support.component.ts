import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-support',
  templateUrl: './support.component.html',
  styleUrls: ['./support.component.scss']
})

export class SupportComponent {
  private interval:any = null;
  private sessionKey:any = null;

  constructor(private http: HttpClient) {}

  startChat(){
    if(this.interval != null){
      console.log(this.interval)
      return;
    }
    this.http.post('https://localhost:44386/api/chat/start', null)
    .subscribe(
      (response) => {
        console.log(response)
        this.sessionKey = response;
        this.interval = setInterval(() => this.poll(), 1000);
      },
      (error) => {             
      },);
  }
  
  poll() {
    this.http.get('https://localhost:44386/api/chat/poll?key=' + this.sessionKey)
    .subscribe(
      (response) => {   
      },
      (error) => {             
      },);
  }

  ngOnDestroy(){
    clearInterval(this.interval);
  }
}
