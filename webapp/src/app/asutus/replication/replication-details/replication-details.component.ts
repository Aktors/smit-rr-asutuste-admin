import { Component, OnInit } from '@angular/core';
import { InformationSystemDto } from '../../../shared/model/common.model';
import { ReplicationDetailsFormGroup } from './replication-details.model';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { InformationSystemsStore } from '../../../../services/information-systems.store';
import { ReplicationSystemItemFormGroup, EnvironmentFormGroup } from './replication-system-item/replication-system.model';
import {ReplicationClient} from '../../../../services/api/replication.client';
import {ActivatedRoute, Router} from '@angular/router';
import {environment} from '../../../../environments/environment';
import {ReplicationSystemDto} from '../../../shared/model/replication.model';
import {AsutusFormStore} from '../../asutus-form/asutus-form.store';

@Component({
  selector: 'app-replication-details',
  templateUrl: './replication-details.component.html',
  styleUrls: ['./replication-details.component.scss']
})
export class ReplicationDetailsComponent implements OnInit {
  form: FormGroup<ReplicationDetailsFormGroup>;
  knownSystems: InformationSystemDto[] = [];
  usedSystems = new Set<string>();

  constructor(
    private fb: FormBuilder,
    private asutusFormStore: AsutusFormStore,
    private informationSystemsStore: InformationSystemsStore,
    private replicationClient: ReplicationClient
  ) {
    this.form = this.fb.group<ReplicationDetailsFormGroup>({
      selectedSystem: new FormControl<string | null>(null),
      replicationSystems: this.fb.array<FormGroup<ReplicationSystemItemFormGroup>>([])
    });
  }

  ngOnInit(): void {
    this.informationSystemsStore.informationSystems$.subscribe((systems) => {
      this.knownSystems = systems;
    });
    console.log(this.asutusFormStore.activeAsutusCode);
  }

  addReplicationSystem(): void {
    const selectedSystemCode = this.form.controls.selectedSystem.value;

    if (selectedSystemCode && !this.usedSystems.has(selectedSystemCode)) {
      const selectedSystem = this.knownSystems.find((system) => system.code === selectedSystemCode);

      if (selectedSystem) {
        const replicationSystemForm = this.fb.group<ReplicationSystemItemFormGroup>({
          code: new FormControl<string>(selectedSystem.code),
          environments: this.fb.array<FormGroup<EnvironmentFormGroup>>(
            selectedSystem.instances.map((instance) =>
              this.fb.group<EnvironmentFormGroup>({
                code: new FormControl<string>(instance),
                isChecked: new FormControl<boolean>(false)
              })
            )
          )
        });

        this.form.controls.replicationSystems.push(replicationSystemForm);
        this.usedSystems.add(selectedSystemCode);
        this.form.controls.selectedSystem.reset();
      }
    }
  }

  removeReplicationSystem(index: number): void {
    const removedSystem = this.form.controls.replicationSystems.at(index).get('code')?.value;
    if (removedSystem) {
      this.usedSystems.delete(removedSystem);
      this.form.controls.replicationSystems.removeAt(index);
    }
  }

  getInformationSystemByCode(code: string | null | undefined): InformationSystemDto {
    return this.knownSystems.find((system) => system.code === code) ?? { name: "", code: "", instances: [] };
  }

  replicate(): void {
    if(this.asutusFormStore.activeAsutusCode.value){
      const data: ReplicationSystemDto[] = this.form.controls.replicationSystems.controls.map(rs => {
        return {
          code: rs.controls.code.value!,
          environments: rs.controls.environments.controls
            .filter(env => env.value.isChecked?.valueOf())
            .map(env => env.controls.code.value!)
        }
      });
      this.replicationClient
        .publish(this.asutusFormStore.activeAsutusCode.value,data)
        .subscribe(() => {
          console.log("saved");
          console.log(data);
        });
    }
  }
}
