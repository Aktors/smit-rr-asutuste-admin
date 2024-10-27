import {FormControl} from '@angular/forms';

export interface TranslationItemFormGroup {
  code: FormControl<string | null>;
  text: FormControl<string | null>;
}
