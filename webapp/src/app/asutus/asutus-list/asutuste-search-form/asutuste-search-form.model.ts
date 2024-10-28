import {FormControl} from '@angular/forms';

export interface AsutusSearchCriteria {
  codePart: string | null;
  namePart: string | null;
}

export interface AsutusSearchFormGroup {
  codePart: FormControl<string | null>;
  namePart: FormControl<string | null>;
}

