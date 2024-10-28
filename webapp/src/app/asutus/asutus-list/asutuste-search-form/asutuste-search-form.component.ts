import {Component, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {AsutusSearchCriteria, AsutusSearchFormGroup} from './asutuste-search-form.model';

@Component({
  selector: 'app-asutuste-search-form',
  templateUrl: './asutuste-search-form.component.html',
  styleUrls: ['./asutuste-search-form.component.scss']
})
export class AsutusteSearchFormComponent{
  form: FormGroup<AsutusSearchFormGroup>;

  @Output() search = new EventEmitter<AsutusSearchCriteria>();

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group<AsutusSearchFormGroup>({
      codePart: new FormControl(''),
      namePart: new FormControl('')
    });
  }

  performSearch(): void {
    if (this.form.valid) {
      this.search.emit(this.form.getRawValue());
    }
  }
}
