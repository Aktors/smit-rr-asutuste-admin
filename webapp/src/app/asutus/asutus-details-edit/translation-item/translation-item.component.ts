import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormGroup} from '@angular/forms';
import {TranslationItemFormGroup} from './translation-item.model';

@Component({
  selector: 'app-translation-item',
  templateUrl: './translation-item.component.html',
  styleUrls: ['./translation-item.component.scss']
})
export class TranslationItemComponent {
  @Input() itemForm!: FormGroup<TranslationItemFormGroup>;
  @Output() remove = new EventEmitter<void>();

  removeItem() {
    this.remove.emit();
  }
}
