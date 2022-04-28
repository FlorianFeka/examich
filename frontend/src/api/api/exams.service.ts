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
import { CreateExamDto, GetExamDto, UpdateExamDto } from '../model/models';
import { BASE_PATH } from '../variables';

@Injectable({
  providedIn: 'root',
})
export class ExamsService {
  protected basePath = 'http://localhost:5001';
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
   * @param examId
   * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
   * @param reportProgress flag to report request and response progress.
   */
  public apiExamsDuplicateExamIdPost(
    examId: string,
    observe?: 'body',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<any>;
  public apiExamsDuplicateExamIdPost(
    examId: string,
    observe?: 'response',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpResponse<any>>;
  public apiExamsDuplicateExamIdPost(
    examId: string,
    observe?: 'events',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpEvent<any>>;
  public apiExamsDuplicateExamIdPost(
    examId: string,
    observe: any = 'body',
    reportProgress: boolean = false,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<any> {
    if (examId === null || examId === undefined) {
      throw new Error(
        'Required parameter examId was null or undefined when calling apiExamsDuplicateExamIdPost.'
      );
    }

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
      const httpHeaderAccepts: string[] = [
        'text/plain',
        'application/json',
        'text/json',
      ];
      localVarHttpHeaderAcceptSelected =
        this.configuration.selectHeaderAccept(httpHeaderAccepts);
    }
    if (localVarHttpHeaderAcceptSelected !== undefined) {
      localVarHeaders = localVarHeaders.set(
        'Accept',
        localVarHttpHeaderAcceptSelected
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
      `${this.configuration.basePath}/api/Exams/Duplicate/${encodeURIComponent(
        String(examId)
      )}`,
      null,
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
   * @param examId
   * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
   * @param reportProgress flag to report request and response progress.
   */
  public apiExamsExamIdDelete(
    examId: string,
    observe?: 'body',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<any>;
  public apiExamsExamIdDelete(
    examId: string,
    observe?: 'response',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpResponse<any>>;
  public apiExamsExamIdDelete(
    examId: string,
    observe?: 'events',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpEvent<any>>;
  public apiExamsExamIdDelete(
    examId: string,
    observe: any = 'body',
    reportProgress: boolean = false,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<any> {
    if (examId === null || examId === undefined) {
      throw new Error(
        'Required parameter examId was null or undefined when calling apiExamsExamIdDelete.'
      );
    }

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
      const httpHeaderAccepts: string[] = [
        'text/plain',
        'application/json',
        'text/json',
      ];
      localVarHttpHeaderAcceptSelected =
        this.configuration.selectHeaderAccept(httpHeaderAccepts);
    }
    if (localVarHttpHeaderAcceptSelected !== undefined) {
      localVarHeaders = localVarHeaders.set(
        'Accept',
        localVarHttpHeaderAcceptSelected
      );
    }

    let responseType_: 'text' | 'json' = 'json';
    if (
      localVarHttpHeaderAcceptSelected &&
      localVarHttpHeaderAcceptSelected.startsWith('text')
    ) {
      responseType_ = 'text';
    }

    return this.httpClient.delete<any>(
      `${this.configuration.basePath}/api/Exams/${encodeURIComponent(
        String(examId)
      )}`,
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
   * @param examId
   * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
   * @param reportProgress flag to report request and response progress.
   */
  public apiExamsExamIdGet(
    examId: string,
    observe?: 'body',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<GetExamDto>;
  public apiExamsExamIdGet(
    examId: string,
    observe?: 'response',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpResponse<GetExamDto>>;
  public apiExamsExamIdGet(
    examId: string,
    observe?: 'events',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpEvent<GetExamDto>>;
  public apiExamsExamIdGet(
    examId: string,
    observe: any = 'body',
    reportProgress: boolean = false,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<any> {
    if (examId === null || examId === undefined) {
      throw new Error(
        'Required parameter examId was null or undefined when calling apiExamsExamIdGet.'
      );
    }

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
      const httpHeaderAccepts: string[] = [
        'text/plain',
        'application/json',
        'text/json',
      ];
      localVarHttpHeaderAcceptSelected =
        this.configuration.selectHeaderAccept(httpHeaderAccepts);
    }
    if (localVarHttpHeaderAcceptSelected !== undefined) {
      localVarHeaders = localVarHeaders.set(
        'Accept',
        localVarHttpHeaderAcceptSelected
      );
    }

    let responseType_: 'text' | 'json' = 'json';
    if (
      localVarHttpHeaderAcceptSelected &&
      localVarHttpHeaderAcceptSelected.startsWith('text')
    ) {
      responseType_ = 'text';
    }

    return this.httpClient.get<GetExamDto>(
      `${this.configuration.basePath}/api/Exams/${encodeURIComponent(
        String(examId)
      )}`,
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
   * @param examId
   * @param updateExamDto
   * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
   * @param reportProgress flag to report request and response progress.
   */
  public apiExamsExamIdPut(
    examId: string,
    updateExamDto?: UpdateExamDto,
    observe?: 'body',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<any>;
  public apiExamsExamIdPut(
    examId: string,
    updateExamDto?: UpdateExamDto,
    observe?: 'response',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpResponse<any>>;
  public apiExamsExamIdPut(
    examId: string,
    updateExamDto?: UpdateExamDto,
    observe?: 'events',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpEvent<any>>;
  public apiExamsExamIdPut(
    examId: string,
    updateExamDto?: UpdateExamDto,
    observe: any = 'body',
    reportProgress: boolean = false,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<any> {
    if (examId === null || examId === undefined) {
      throw new Error(
        'Required parameter examId was null or undefined when calling apiExamsExamIdPut.'
      );
    }

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
      const httpHeaderAccepts: string[] = [
        'text/plain',
        'application/json',
        'text/json',
      ];
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

    return this.httpClient.put<any>(
      `${this.configuration.basePath}/api/Exams/${encodeURIComponent(
        String(examId)
      )}`,
      updateExamDto,
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
   * @param createExamDto
   * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
   * @param reportProgress flag to report request and response progress.
   */
  public apiExamsPost(
    createExamDto?: CreateExamDto,
    observe?: 'body',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<any>;
  public apiExamsPost(
    createExamDto?: CreateExamDto,
    observe?: 'response',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpResponse<any>>;
  public apiExamsPost(
    createExamDto?: CreateExamDto,
    observe?: 'events',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpEvent<any>>;
  public apiExamsPost(
    createExamDto?: CreateExamDto,
    observe: any = 'body',
    reportProgress: boolean = false,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
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
      const httpHeaderAccepts: string[] = [
        'text/plain',
        'application/json',
        'text/json',
      ];
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
      `${this.configuration.basePath}/api/Exams`,
      createExamDto,
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
   * @param name
   * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
   * @param reportProgress flag to report request and response progress.
   */
  public apiExamsSearchGet(
    name?: string,
    observe?: 'body',
    reportProgress?: boolean,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<any>;
  public apiExamsSearchGet(
    name?: string,
    observe?: 'response',
    reportProgress?: boolean,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<HttpResponse<any>>;
  public apiExamsSearchGet(
    name?: string,
    observe?: 'events',
    reportProgress?: boolean,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<HttpEvent<any>>;
  public apiExamsSearchGet(
    name?: string,
    observe: any = 'body',
    reportProgress: boolean = false,
    options?: { httpHeaderAccept?: undefined }
  ): Observable<any> {
    let localVarQueryParameters = new HttpParams({ encoder: this.encoder });
    if (name !== undefined && name !== null) {
      localVarQueryParameters = this.addToHttpParams(
        localVarQueryParameters,
        <any>name,
        'name'
      );
    }

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

    let responseType_: 'text' | 'json' = 'json';
    if (
      localVarHttpHeaderAcceptSelected &&
      localVarHttpHeaderAcceptSelected.startsWith('text')
    ) {
      responseType_ = 'text';
    }

    return this.httpClient.get<any>(
      `${this.configuration.basePath}/api/Exams/Search`,
      {
        params: localVarQueryParameters,
        responseType: <any>responseType_,
        withCredentials: this.configuration.withCredentials,
        headers: localVarHeaders,
        observe: observe,
        reportProgress: reportProgress,
      }
    );
  }

  /**
   * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
   * @param reportProgress flag to report request and response progress.
   */
  public apiExamsUserGet(
    observe?: 'body',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<Array<GetExamDto>>;
  public apiExamsUserGet(
    observe?: 'response',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpResponse<Array<GetExamDto>>>;
  public apiExamsUserGet(
    observe?: 'events',
    reportProgress?: boolean,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
  ): Observable<HttpEvent<Array<GetExamDto>>>;
  public apiExamsUserGet(
    observe: any = 'body',
    reportProgress: boolean = false,
    options?: {
      httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json';
    }
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
      const httpHeaderAccepts: string[] = [
        'text/plain',
        'application/json',
        'text/json',
      ];
      localVarHttpHeaderAcceptSelected =
        this.configuration.selectHeaderAccept(httpHeaderAccepts);
    }
    if (localVarHttpHeaderAcceptSelected !== undefined) {
      localVarHeaders = localVarHeaders.set(
        'Accept',
        localVarHttpHeaderAcceptSelected
      );
    }

    let responseType_: 'text' | 'json' = 'json';
    if (
      localVarHttpHeaderAcceptSelected &&
      localVarHttpHeaderAcceptSelected.startsWith('text')
    ) {
      responseType_ = 'text';
    }

    return this.httpClient.get<Array<GetExamDto>>(
      `${this.configuration.basePath}/api/Exams/User`,
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
