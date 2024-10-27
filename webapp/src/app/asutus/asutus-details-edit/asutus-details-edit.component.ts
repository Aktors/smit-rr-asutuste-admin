import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ClassifierStore} from '../../../services/classifiers.store';
import {ClassifierDto} from '../../shared/model/common.model';
import {AsutusFormGroup} from './asutus-details-edit.model';
import {TranslationItemFormGroup} from './translation-item/translation-item.model';

@Component({
  selector: 'app-asutud-details-edit',
  templateUrl: './asutus-details-edit.component.html',
  styleUrls: ['./asutus-details-edit.component.scss']
})
export class AsutusDetailsEditComponent implements OnInit{
  form: FormGroup<AsutusFormGroup>;
  knownLanguages: ClassifierDto[] = [];
  usedLanguages = new Set<string>();

  constructor(
    private fb: FormBuilder,
    private classifierStore: ClassifierStore
  ) {
    this.form = this.fb.group<AsutusFormGroup>({
      code: new FormControl<string>('', Validators.required),
      name: new FormControl<string>('', Validators.required),
      startDate: new FormControl<Date | null>(null, Validators.required),
      endDate: new FormControl<Date | null>(null),
      translations: this.fb.array<FormGroup<TranslationItemFormGroup>>([]),
      selectedLanguage: new FormControl<string | null>(null)
    });
  }

  ngOnInit(): void {
    this.classifierStore.lang$.subscribe((languages) => {
      this.knownLanguages = languages;
      if (this.knownLanguages.length > 0) {
        this.form.controls.selectedLanguage.setValue(this.knownLanguages[0].code);
      }
    });
  }

  addTranslation(): void {
    const languageCode = this.form.controls.selectedLanguage.value;
    if (languageCode && !this.usedLanguages.has(languageCode)) {
      const translationForm = this.fb.group<TranslationItemFormGroup>({
        code: new FormControl<string>({ value: languageCode, disabled: true }),
        text: new FormControl<string>('', Validators.required),
      });
      this.form.controls.translations.push(translationForm);
      this.usedLanguages.add(languageCode);

      const nextAvailableLanguage = this.knownLanguages.find(
        (lang) => !this.usedLanguages.has(lang.code)
      );

      if (nextAvailableLanguage) {
        this.form.controls.selectedLanguage.setValue(nextAvailableLanguage.code);
      } else {
        this.form.controls.selectedLanguage.reset();
      }
    }
  }

  // Remove a translation by index
  removeTranslation(index: number): void {
    const languageCode = this.form.controls.translations.at(index).get('code')?.value;
    if(languageCode){
      this.usedLanguages.delete(languageCode);
    }
    this.form.controls.translations.removeAt(index);
  }
}
