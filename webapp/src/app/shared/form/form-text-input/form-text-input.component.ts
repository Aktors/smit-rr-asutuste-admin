import {Component, input, Input, ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'app-form-text-input',
  templateUrl: './form-text-input.component.html',
  styleUrls: ['./form-text-input.component.scss']
})
export class FormTextInputComponent {
  @Input() placeholder:string | undefined;
  @Input() size: "sm" | "md" | "lg" = "sm";
  @Input() disabled = false;

  @Input() field!: string;
  @Input() label!: string;
  @Input() description: string | undefined;
  @Input() required = false;
}
