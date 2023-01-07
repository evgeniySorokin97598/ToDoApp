import { Injectable } from '@angular/core';

import { Config } from '../Interfaces/IConfig';

export const CONFIG_DEFAULT: Config = {
  apiHost: '',
};

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  private readonly config: Config;

  constructor() {
    this.config = {
      apiHost: process.env["API_HOST"] ?? CONFIG_DEFAULT.apiHost,
    };
  }

  GetConfig(): Config {
    return this.config;
  }
}