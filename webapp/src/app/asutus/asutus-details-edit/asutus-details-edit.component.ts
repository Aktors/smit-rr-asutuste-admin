import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ClassifierStore} from '../../../services/classifiers.store';
import {ClassifierDto} from '../../shared/model/common.model';
import {AsutusFormGroup} from './asutus-details-edit.model';
import {TranslationItemFormGroup} from './translation-item/translation-item.model';
import {ActivatedRoute, Router} from '@angular/router';
import {AsutusDto, TranslationDto} from '../../shared/model/asutus.model';
import {AsutusClient} from '../../../services/api/asutus.client';

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
    private router: Router,
    private route: ActivatedRoute,
    private classifierStore: ClassifierStore,
    private asutusClient: AsutusClient
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

    const code = this.route.snapshot.paramMap.get('code');
    if(code)
      this.fetchAsutusDetails(code);
  }

  private fetchAsutusDetails(code: string): void {
    this.asutusClient.getByCode(code).subscribe({
      next: (data) => {
        this.form.patchValue({...data});
        this.form.controls.translations.clear();
        data.translations.forEach((translation) => {
          const translationForm = this.fb.group<TranslationItemFormGroup>({
            code: new FormControl<string>({ value: translation.code, disabled: true }),
            text: new FormControl<string>(translation.text, Validators.required)
          });
          this.form.controls.translations.push(translationForm);
          this.usedLanguages.add(translation.code);
          this.setNextActiveTranslation();
        });
      },
      error: (err) => {
        console.error(err);
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

      this.setNextActiveTranslation();
    }
  }

  removeTranslation(index: number): void {
    const languageCode = this.form.controls.translations.at(index).get('code')?.value;
    if(languageCode){
      this.usedLanguages.delete(languageCode);
    }
    this.form.controls.translations.removeAt(index);
  }

  save(): void {
    const code = this.form.controls.code.value;
    if (!code) {
      console.error('No code available for update');
      return;
    }

    //TODO: add validation and fix from types.
    const asutusData: AsutusDto = {
      code: this.form.controls.code.value!,
      name: this.form.controls.name.value!,
      startDate: this.form.controls.startDate.value!,
      endDate: this.form.controls.endDate.value ?? undefined,
      translations: this.form.controls.translations.getRawValue()
        .map((translationForm) => ({
        code: translationForm.code!,
        text: translationForm.text!
      }))
    };

    this.asutusClient.update(code, asutusData).subscribe({
      next: () => {
        this.router.navigate(['/asutused']);
      },
      error: (err) => {
        console.error('Failed to update Asutus:', err);
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/asutused']);
  }

  private setNextActiveTranslation(){
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
