import {Component, ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html',
  styleUrl: 'header.component.scss',
  encapsulation: ViewEncapsulation.None,
  host:{
    class:'v-header'
  }
})
export class HeaderComponent {

}
