import {Component, Input, ViewEncapsulation} from '@angular/core';
import {SideMenuItem} from './side-menu.model';

@Component({
  selector: 'app-side-menu',
  templateUrl: 'side-menu.component.html',
  styleUrls: ['side-menu.component.scss'],
  host: {
    class: 'side-navigation'
  },
  encapsulation: ViewEncapsulation.None
})
export class SideMenuComponent {
  @Input() items!: SideMenuItem[];

}
