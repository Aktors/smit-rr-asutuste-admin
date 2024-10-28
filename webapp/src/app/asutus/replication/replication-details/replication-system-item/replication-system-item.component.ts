import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { InformationSystemDto } from '../../../../shared/model/common.model';
import { ClassifierStore } from '../../../../../services/classifiers.store';
import { ReplicationSystemItemFormGroup } from './replication-system.model';

@Component({
  selector: 'app-replication-system-item',
  templateUrl: './replication-system-item.component.html',
  styleUrls: ['./replication-system-item.component.scss']
})
export class ReplicationSystemItemComponent implements OnInit {
  @Input() formGroup!: FormGroup<ReplicationSystemItemFormGroup>;
  @Input() informationSystem!: InformationSystemDto;
  @Output() remove = new EventEmitter<void>();

  availableInstances: { code: string; name: string }[] = [];

  constructor(private classifierStore: ClassifierStore) {  }

  ngOnInit(): void {
    this.classifierStore.instance$.subscribe((instances) => {
      this.availableInstances = instances;
    });
  }

  removeItem(): void {
    this.remove.emit();
  }
}
