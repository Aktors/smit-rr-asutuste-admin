import {Component, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {SearchCriteria} from './asutuste-search-form.model';

@Component({
  selector: 'app-asutuste-search-form',
  templateUrl: './asutuste-search-form.component.html',
  styleUrls: ['./asutuste-search-form.component.scss']
})
export class AsutusteSearchFormComponent{
  form: FormGroup;

  @Output() search = new EventEmitter<SearchCriteria>();

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group<SearchCriteria>({
      codePart: '',
      namePart: ''
    });
  }

  performSearch(): void {
    if (this.form.valid) {
      this.search.emit(this.form.value);
      console.log(this.form.value);
    }
  }
}
