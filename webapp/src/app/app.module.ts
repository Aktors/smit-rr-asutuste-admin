import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AppComponent} from './app.component';
import AppRoutingModule from './app-routing.module';
import {provideHttpClient} from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import {HeaderComponent} from './components/header/header.component';
import {NavigationMenuComponent} from './components/nav-menu/nav-menu.component';
import {SharedModule} from './shared/shared.module';
import {NavMenuItemComponent} from './components/nav-menu-item/nav-menu-item.component';
import {AsutusModule} from './asutus/asutus.module';
import {ReplicationLogComponent} from './asutus/replication/replication-log/replication-log.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavigationMenuComponent,
    NavMenuItemComponent,
    ReplicationLogComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    BrowserModule,
    AppRoutingModule,
    AsutusModule
  ],
  providers: [
    provideHttpClient(),
  ],
  exports: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
