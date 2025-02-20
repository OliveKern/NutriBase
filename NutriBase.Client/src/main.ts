//import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
//import { AppModule } from './app/app.module';
//platformBrowserDynamic().bootstrapModule(AppModule, {
//  ngZoneEventCoalescing: true
//})
//  .catch(err => console.error(err));

import { bootstrapApplication } from "@angular/platform-browser";
import { AppComponent } from "./app/app.component";
import { appConfig } from "./app/app.config";
import { provideRouter } from "@angular/router";

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
