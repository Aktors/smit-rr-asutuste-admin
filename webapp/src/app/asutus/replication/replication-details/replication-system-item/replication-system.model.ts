import { FormControl, FormArray, FormGroup } from '@angular/forms';

export interface EnvironmentFormGroup {
  code: FormControl<string | null>;
  isChecked: FormControl<boolean | null>;
}

export interface ReplicationSystemItemFormGroup {
  code: FormControl<string | null>;
  environments: FormArray<FormGroup<EnvironmentFormGroup>>;
}
