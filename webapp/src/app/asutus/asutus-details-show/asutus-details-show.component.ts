import {Component, OnInit} from '@angular/core';
import {AsutusDto} from '../../shared/model/asutus.model';
import {ActivatedRoute, Router} from '@angular/router';
import {AsutusClient} from '../../../services/api/asutus.client';
import {AsutusFormStore} from '../asutus-form/asutus-form.store';

@Component({
  selector: 'app-austus-details',
  templateUrl: './asutus-details-show.component.html',
  styleUrls: ['./asutus-details-show.component.scss']
})
export class AsutusDetailsShowComponent implements OnInit {
  asutusDetails?: AsutusDto;
  isLoading = true;
  error: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private asutusFormStore: AsutusFormStore,
    private asutusClient: AsutusClient
  ) {}

  ngOnInit(): void {
    const code = this.route.snapshot.paramMap.get('code');
    if (code) {
      this.fetchAsutusDetails(code);
      this.asutusFormStore.activeAsutusCode.next(code);
    } else {
      this.error = 'No code provided in route';
      this.isLoading = false;
    }
  }

  private fetchAsutusDetails(code: string): void {
    this.asutusClient.getByCode(code).subscribe({
      next: (data) => {
        this.asutusDetails = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.error = 'Failed to load Asutus details';
        this.isLoading = false;
        console.error(err);
      }
    });
  }

  editAsutus(): void {
    if (this.asutusDetails) {
      this.router.navigate(['/asutused/manage', this.asutusDetails.code, 'edit']);
    }
  }
  goBack(): void {
    this.router.navigate(['/asutused']);
  }
}
