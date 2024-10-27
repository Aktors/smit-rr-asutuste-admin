import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { InformationSystemDto } from '../../../../shared/model/common.model';
import { ClassifierStore } from '../../../../../services/classifiers.store';
import { ReplicationSystemItemFormGroup, EnvironmentFormGroup } from './replication-system.model';

@Component({
  selector: 'app-replication-system-item',
  templateUrl: './replication-system-item.component.html',
  styleUrls: ['./replication-system-item.component.scss']
})
export class ReplicationSystemItemComponent implements OnInit {
  @Input() informationSystem!: InformationSystemDto;
  @Output() remove = new EventEmitter<void>();

  form: FormGroup<ReplicationSystemItemFormGroup>;
  availableInstances: { code: string; name: string }[] = [];

  constructor(
    private fb: FormBuilder,
    private classifierStore: ClassifierStore
  ) {
    this.form = this.fb.group<ReplicationSystemItemFormGroup>({
      code: new FormControl<string>(this.informationSystem?.code || ''),
      environments: this.fb.array<FormGroup<EnvironmentFormGroup>>([]) // Array for environments
    });
  }

  ngOnInit(): void {
    this.classifierStore.instance$.subscribe((instances) => {
      this.availableInstances = instances;
      this.createEnvironmentControls();
    });

    this.form.controls.code.setValue(this.informationSystem.code);
  }

  private createEnvironmentControls(): void {
    const environmentsArray = this.form.get('environments') as FormArray;

    this.availableInstances.forEach((instance) => {
      const environmentGroup = this.fb.group<EnvironmentFormGroup>({
        code: new FormControl<string>(instance.code),
        isChecked: new FormControl<boolean>(false)
      });
      environmentsArray.push(environmentGroup);
    });
  }

  updateCheckboxValue(index: number, isChecked: boolean): void {
    const environment = this.form.controls.environments.at(index);
    environment.controls.isChecked.setValue(isChecked);
  }

  removeItem(): void {
    this.remove.emit();
  }

  get environments(): FormArray<FormGroup<EnvironmentFormGroup>> {
    return this.form.get('environments') as FormArray<FormGroup<EnvironmentFormGroup>>;
  }
}
