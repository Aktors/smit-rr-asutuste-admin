import {Component, ViewEncapsulation} from '@angular/core';
import {SideMenuItem} from './components/nav/side-menu/side-menu.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  title = 'webapp';
  navigationItems: SideMenuItem[] = [{
    label: 'Asutus',
    location: '/asutused',
    icon: 'apartment'
  }];
}
