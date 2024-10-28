import {Component, Input, ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'app-replication-log-details',
  templateUrl: './replication-log-details.component.html',
  styleUrls: ['./replication-log-details.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ReplicationLogDetailsComponent {
  private _json: any;

  @Input() set json(value: any) {
    this._json = value;
    this.formattedJson = value;
  }

  formattedJson = '';
}
