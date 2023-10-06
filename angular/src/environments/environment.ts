import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Chat',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44386/',
    redirectUri: baseUrl,
    clientId: 'Chat_App',
    responseType: 'code',
    scope: 'offline_access Chat',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44386',
      rootNamespace: 'Chat',
    },
  },
} as Environment;
