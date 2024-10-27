import {FormArray, FormControl, FormGroup} from '@angular/forms';
import {TranslationItemFormGroup} from './translation-item/translation-item.model';

export interface AsutusFormGroup {
  code: FormControl<string | null>;
  name: FormControl<string | null>;
  startDate: FormControl<Date | null>;
  endDate: FormControl<Date | null>;
  translations: FormArray<FormGroup<TranslationItemFormGroup>>;
  selectedLanguage: FormControl<string | null>;
}
