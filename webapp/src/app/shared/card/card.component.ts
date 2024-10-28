import {Component, HostBinding, Input, ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'app-card',
  template: '<ng-content></ng-content>',
  styleUrls: ['./card.component.scss'],
  encapsulation: ViewEncapsulation.None,
  host: {
    class: 'v-card',
  }
})
export class CardComponent {
  @Input() size: "sm" | "md" = "sm";
  @Input() variant: "primary" | "secondary" | "tertiary" = "primary";
  @Input() flat: boolean = false;

  @HostBinding('class.v-card--flat') get flatClass() {
    return this.flat;
  }

  // Bind the size class dynamically based on `size`
  @HostBinding('class')
  get sizeClass() {
    return `v-card--${this.size} v-card--${this.variant}`;
  }
}
