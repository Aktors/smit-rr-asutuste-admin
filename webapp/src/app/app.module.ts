import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AppComponent} from './app.component';
import AppRoutingModule from './app-routing.module';
import {provideHttpClient} from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import {HeaderComponent} from './components/header/header.component';
import {SharedModule} from './shared/shared.module';
import {AsutusModule} from './asutus/asutus.module';
import {ReplicationLogComponent} from './asutus/replication/replication-log/replication-log.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { TableComponent } from './shared/table/table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavMenuComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    BrowserModule,
    AppRoutingModule,
    AsutusModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
  ],
  providers: [
    provideHttpClient(),
    provideAnimationsAsync(),
  ],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
