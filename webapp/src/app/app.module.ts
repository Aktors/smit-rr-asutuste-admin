import { NgModule } from '@angular/core';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import {AppComponent} from './app.component';
import AppRoutingModule from './app-routing.module';
import {provideHttpClient} from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import {SharedModule} from './shared/shared.module';
import {AsutusModule} from './asutus/asutus.module';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import {SideMenuComponent} from './components/nav/side-menu/side-menu.component';
import {HeaderComponent} from './components/nav/header/header.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    SideMenuComponent,
    HeaderComponent,
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
    NgOptimizedImage,
    MatSnackBarModule,
  ],
  providers: [
    provideHttpClient(),
    provideAnimationsAsync(),
  ],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
