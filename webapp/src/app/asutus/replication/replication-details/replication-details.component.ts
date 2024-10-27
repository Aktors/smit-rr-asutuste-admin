import {Component, OnInit} from '@angular/core';
import {InformationSystemDto} from '../../../shared/model/common.model';
import {ReplicationDetailsFormGroup} from './replication-details.model';
import {FormArray, FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {InformationSystemsStore} from '../../../../services/information-systems.store';
import {ReplicationSystemItemFormGroup} from './replication-system-item/replication-system.model';

@Component({
  selector: 'app-replication-details',
  templateUrl: './replication-details.component.html',
  styleUrls: ['./replication-details.component.scss']
})
export class ReplicationDetailsComponent  implements OnInit {
  form: FormGroup<ReplicationDetailsFormGroup>;
  knownSystems: InformationSystemDto[] = [];
  usedSystems = new Set<string>();

  constructor(
    private fb: FormBuilder,
    private informationSystemsStore: InformationSystemsStore
  ) {
    // Initialize the form with the new form group type
    this.form = this.fb.group<ReplicationDetailsFormGroup>({
      selectedSystem: new FormControl<string | null>(null), // Control for the selected system
      replicationSystems: this.fb.array<FormGroup<ReplicationSystemItemFormGroup>>([]), // Array for replication systems
    });
  }

  ngOnInit(): void {
    // Populate known systems from the information systems store
    this.informationSystemsStore.informationSystems$.subscribe((systems) => {
      this.knownSystems = systems;
    });
  }

  // Getter for the replicationSystems array
  get replicationSystems(): FormArray<FormGroup<ReplicationSystemItemFormGroup>> {
    return this.form.controls.replicationSystems;
  }

  // Add a new replication system
  addReplicationSystem(): void {
    const selectedSystemCode = this.form.controls.selectedSystem.value;

    if (selectedSystemCode && !this.usedSystems.has(selectedSystemCode)) {
      const selectedSystem = this.knownSystems.find((system) => system.code === selectedSystemCode);

      if (selectedSystem) {
        // Create a new ReplicationSystemItemFormGroup
        const replicationSystemForm = this.fb.group<ReplicationSystemItemFormGroup>({
          code: new FormControl<string>(selectedSystem.code),
          environments: this.fb.array<FormControl<string | null>>(
            selectedSystem.instances.map((instance) => new FormControl<string | null>(instance))
          ),
        });

        // Add the form group to the replicationSystems array
        this.replicationSystems.push(replicationSystemForm);
        this.usedSystems.add(selectedSystemCode);
        this.form.controls.selectedSystem.reset(); // Reset selection after adding
      }
    }
  }

  // Remove a replication system by index
  removeReplicationSystem(index: number): void {
    const removedSystem = this.replicationSystems.at(index).get('code')?.value;
    if (removedSystem) {
      this.usedSystems.delete(removedSystem);
      this.replicationSystems.removeAt(index);
    }
  }

  getInformationSystemByCode(code: string | null | undefined): InformationSystemDto {
    return this.knownSystems.find((system) => system.code === code) ?? { name: "", code: "", instances:[]};
  }
}
