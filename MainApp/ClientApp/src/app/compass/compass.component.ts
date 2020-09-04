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
  @Input() display_flight_arrow:boolean;

  ngOnInit() {
    console.log(`display flight arrow:${this.display_flight_arrow}`);
  }

  updateWindArrowStyle(){
    let styles = {
      'transform': `rotate(${this.wind_direction}deg)`
    };
    return styles;
  }

  updateRunwayArrowStyle(){
    let styles = {
      'transform': `rotate(${this.runway_direction}deg)`
    };
    return styles;
  }



}
