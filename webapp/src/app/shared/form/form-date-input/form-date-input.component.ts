import {ChangeDetectionStrategy, Component, Input} from '@angular/core';

@Component({
  selector: 'app-form-date-input',
  templateUrl: './form-date-input.component.html',
  styleUrls: ['./form-date-input.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FormDateInputComponent{
  @Input() label!: string;
}
