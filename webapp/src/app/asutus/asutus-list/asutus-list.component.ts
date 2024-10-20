import {Component, OnInit} from '@angular/core';
import {WeatherForecast, WeatherService} from '../../../services/weather.service';

@Component({
  selector: 'asutus-list',
  templateUrl: './asutus-list.component.html',
  styleUrl: './asutus-list.component.scss'
})
export class AsutusListComponent{
  items: WeatherForecast[] = [];

  constructor(private weatherService: WeatherService) { }

  fetchItems(): void {
    this.weatherService.getForecast().subscribe(res => this.items = res);
  }
}
