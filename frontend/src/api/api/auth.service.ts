/**
 * Examich
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 *
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
/* tslint:disable:no-unused-variable member-ordering */
import { HttpClient, HttpEvent, HttpHeaders, HttpParameterCodec, HttpParams, HttpResponse } from '@angular/common/http';
import { Inject, Injectable, Optional } from '@angular/core';
import { Observable } from 'rxjs';

import { Configuration } from '../configuration';
import { CustomHttpParameterCodec } from '../encoder';
import { CreateUserDto, LoginDto } from '../model/models';
import { BASE_PATH } from '../variables';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  protected basePath = 'https://localhost:5001';
  public defaultHeaders = new HttpHeaders();
  public configuration = new Configuration();
  public encoder: HttpParameterCodec;

  constructor(
    protected httpClient: HttpClient,
    @Optional() @Inject(BASE_PATH) basePath: string,
    @Optional() configuration: Configuration
  ) {
    if (configuration) {
      this.configuration = configuration;
    }
    if (typeof this.configuration.basePath !== 'string') {
      if (typeof basePath !== 'string') {
        basePath = this.basePath;
      }
      this.configuration.basePath = basePath;
    }
    this.encoder = this.configuration.encoder || new CustomHttpParameterCodec();
  }

  private addToHttpParams(
    httpParams: HttpParams,
    value: any,
    key?: string
  ): HttpParams {
    if (typeof value === 'object' && value instanceof Date === false) {
      httpParams = this.addToHttpParamsRecursive(httpParams, value);
    } else {
      httpParams = this.addToHttpParamsRecursive(httpParams, value, key);
    }
    return httpParams;
  }

  private addToHttpParamsRecursive(
    httpParams: HttpParams,
    value?: any,
    key?: string
  ): HttpParams {
    if (value == null) {
      return httpParams;
    }

    if (typeof value === 'object') {
      if (Array.isArray(value)) {
        (value as any[]).forEach(
          (elem) =>
            (httpParams = this.addToHttpParamsRecursive(httpParams, elem, key))
        );
      } else if (value instanceof Date) {
        if (key != null) {
          httpParams = httpParams.append(
            key,
            (value as Date).toISOString().substr(0, 10)
          );
        } else {
          throw Error('key may not be null if value is Date');
        }
      } else {
        Object.keys(value).forEach(
          (k) =>
            (httpParams = this.addToHttpParamsRecursive(
              httpParams,
              value[k],
              key != null ? `${key}.${k}` : k
            ))
        );
      }
    } else if (key != null) {
      httpParams = httpParams.append(key, value);
    } else {
      throw Error('key may not be null if value is not object or array');
    }
    return httpParams;
  }

  /**
   * @param loginDto
   * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
   * @param reportProgress flag to report request and response progress.
   */
  public apiAuthLoginPost(
    loginDto?: LoginDto,
    observe?: 'body',
    reportProgress?: boolean,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<any>;
  public apiAuthLoginPost(
    loginDto?: LoginDto,
    observe?: 'response',
    reportProgress?: boolean,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<HttpResponse<any>>;
  public apiAuthLoginPost(
    loginDto?: LoginDto,
    observe?: 'events',
    reportProgress?: boolean,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<HttpEvent<any>>;
  public apiAuthLoginPost(
    loginDto?: LoginDto,
    observe: any = 'body',
    reportProgress: boolean = false,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<any> {
    let localVarHeaders = this.defaultHeaders;

    let localVarCredential: string | undefined;
    // authentication (Bearer) required
    localVarCredential = this.configuration.lookupCredential('Bearer');
    if (localVarCredential) {
      localVarHeaders = localVarHeaders.set(
        'Authorization',
        localVarCredential
      );
    }

    let localVarHttpHeaderAcceptSelected: string | undefined =
      options && options.httpHeaderAccept;
    if (localVarHttpHeaderAcceptSelected === undefined) {
      // to determine the Accept header
      const httpHeaderAccepts: string[] = [];
      localVarHttpHeaderAcceptSelected =
        this.configuration.selectHeaderAccept(httpHeaderAccepts);
    }
    if (localVarHttpHeaderAcceptSelected !== undefined) {
      localVarHeaders = localVarHeaders.set(
        'Accept',
        localVarHttpHeaderAcceptSelected
      );
    }

    // to determine the Content-Type header
    const consumes: string[] = [
      'application/json',
      'text/json',
      'application/_*+json',
    ];
    const httpContentTypeSelected: string | undefined =
      this.configuration.selectHeaderContentType(consumes);
    if (httpContentTypeSelected !== undefined) {
      localVarHeaders = localVarHeaders.set(
        'Content-Type',
        httpContentTypeSelected
      );
    }

    let responseType_: 'text' | 'json' = 'json';
    if (
      localVarHttpHeaderAcceptSelected &&
      localVarHttpHeaderAcceptSelected.startsWith('text')
    ) {
      responseType_ = 'text';
    }

    return this.httpClient.post<any>(
      `${this.configuration.basePath}/api/Auth/Login`,
      loginDto,
      {
        responseType: <any>responseType_,
        withCredentials: this.configuration.withCredentials,
        headers: localVarHeaders,
        observe: observe,
        reportProgress: reportProgress,
      }
    );
  }

  /**
   * @param createUserDto
   * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
   * @param reportProgress flag to report request and response progress.
   */
  public apiAuthRegisterPost(
    createUserDto?: CreateUserDto,
    observe?: 'body',
    reportProgress?: boolean,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<any>;
  public apiAuthRegisterPost(
    createUserDto?: CreateUserDto,
    observe?: 'response',
    reportProgress?: boolean,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<HttpResponse<any>>;
  public apiAuthRegisterPost(
    createUserDto?: CreateUserDto,
    observe?: 'events',
    reportProgress?: boolean,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<HttpEvent<any>>;
  public apiAuthRegisterPost(
    createUserDto?: CreateUserDto,
    observe: any = 'body',
    reportProgress: boolean = false,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<any> {
    let localVarHeaders = this.defaultHeaders;

    let localVarCredential: string | undefined;
    // authentication (Bearer) required
    localVarCredential = this.configuration.lookupCredential('Bearer');
    if (localVarCredential) {
      localVarHeaders = localVarHeaders.set(
        'Authorization',
        localVarCredential
      );
    }

    let localVarHttpHeaderAcceptSelected: string | undefined =
      options && options.httpHeaderAccept;
    if (localVarHttpHeaderAcceptSelected === undefined) {
      // to determine the Accept header
      const httpHeaderAccepts: string[] = [];
      localVarHttpHeaderAcceptSelected =
        this.configuration.selectHeaderAccept(httpHeaderAccepts);
    }
    if (localVarHttpHeaderAcceptSelected !== undefined) {
      localVarHeaders = localVarHeaders.set(
        'Accept',
        localVarHttpHeaderAcceptSelected
      );
    }

    // to determine the Content-Type header
    const consumes: string[] = [
      'application/json',
      'text/json',
      'application/_*+json',
    ];
    const httpContentTypeSelected: string | undefined =
      this.configuration.selectHeaderContentType(consumes);
    if (httpContentTypeSelected !== undefined) {
      localVarHeaders = localVarHeaders.set(
        'Content-Type',
        httpContentTypeSelected
      );
    }

    let responseType_: 'text' | 'json' = 'json';
    if (
      localVarHttpHeaderAcceptSelected &&
      localVarHttpHeaderAcceptSelected.startsWith('text')
    ) {
      responseType_ = 'text';
    }

    return this.httpClient.post<any>(
      `${this.configuration.basePath}/api/Auth/Register`,
      createUserDto,
      {
        responseType: <any>responseType_,
        withCredentials: this.configuration.withCredentials,
        headers: localVarHeaders,
        observe: observe,
        reportProgress: reportProgress,
      }
    );
  }
}
