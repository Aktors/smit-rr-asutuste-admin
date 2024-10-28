import {Component, inject, ViewEncapsulation} from '@angular/core';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-asutus',
  templateUrl: './asutus.component.html',
  styleUrl: './asutus.component.scss',
  encapsulation: ViewEncapsulation.None,
  host: {
    class: 'v-container v-pt-6 v-pt-lg-8 v-pb-10 v-pb-lg-12 v-flex v-flex-column v-gap-7',
  }
})
export class AsutusComponent {

}
