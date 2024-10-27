import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import {FormBuilder, FormGroup, FormControl, FormArray} from '@angular/forms';
import {InformationSystemDto} from '../../../../shared/model/common.model';
import {ClassifierStore} from '../../../../../services/classifiers.store';
import {ReplicationSystemItemFormGroup} from './replication-system.model';

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
      environments: this.fb.array<FormControl<string | null>>([])
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
      environmentsArray.push(new FormControl(false));
    });
  }

  removeItem(): void {
    this.remove.emit();
  }
}
