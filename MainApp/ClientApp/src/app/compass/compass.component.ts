import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-compass',
  templateUrl: './compass.component.html',
  styleUrls: ['./compass.component.css']
})
export class CompassComponent implements OnInit {

  constructor() { }

  @Input() wind_direction:number;
  @Input() runway_direction:number;

  ngOnInit() {
  }

  updateWindArrowStyle(){
    let styles = {
      //transform: rotate(20deg);
      'transform': `rotate(${this.wind_direction}deg)`
    };
    return styles;
  }

  updateRunwayArrowStyle(){
    let styles = {
      //transform: rotate(20deg);
      'transform': `rotate(${this.wind_direction}deg)`
    };
    return styles;
  }



}
