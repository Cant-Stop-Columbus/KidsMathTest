import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

export function getAPIBaseUrl() {
  return 'https://localhost:44327/api/';
}

export function getEmptyId() {
  return '00000000-0000-0000-0000-000000000000';
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: 'API_BASE_URL', useFactory: getAPIBaseUrl, deps: [] },
  { provide: 'EMPTY_ID', useFactory: getEmptyId, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
