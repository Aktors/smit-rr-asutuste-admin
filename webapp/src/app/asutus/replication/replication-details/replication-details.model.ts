import {FormArray, FormControl, FormGroup} from '@angular/forms';
import {ReplicationSystemItemFormGroup} from './replication-system-item/replication-system.model';

export interface ReplicationDetailsFormGroup {
  selectedSystem: FormControl<string | null>;
  replicationSystems: FormArray<FormGroup<ReplicationSystemItemFormGroup>>; // Array of ReplicationSystemItemFormGroup
}
