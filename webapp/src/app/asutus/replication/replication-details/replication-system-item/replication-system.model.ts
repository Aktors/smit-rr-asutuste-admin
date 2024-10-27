import { FormControl, FormArray, FormGroup } from '@angular/forms';

export interface ReplicationSystemItemFormGroup {
  code: FormControl<string | null>;
  environments: FormArray<FormControl<string| null>>;
}
