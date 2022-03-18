/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetMaintenanceRequestByIdResponse } from '../models/get-maintenance-request-by-id-response';
import { RemoveMaintenanceRequestResponse } from '../models/remove-maintenance-request-response';
import { GetMaintenanceRequestsResponse } from '../models/get-maintenance-requests-response';
import { CreateMaintenanceRequestResponse } from '../models/create-maintenance-request-response';
import { CreateMaintenanceRequestRequest } from '../models/create-maintenance-request-request';
import { UpdateMaintenanceRequestResponse } from '../models/update-maintenance-request-response';
import { UpdateMaintenanceRequestRequest } from '../models/update-maintenance-request-request';
import { GetMaintenanceRequestsPageResponse } from '../models/get-maintenance-requests-page-response';
@Injectable({
  providedIn: 'root',
})
class MaintenanceRequestService extends __BaseService {
  static readonly getMaintenanceRequestByIdPath = '/api/MaintenanceRequest/{maintenanceRequestId}';
  static readonly removeMaintenanceRequestPath = '/api/MaintenanceRequest/{maintenanceRequestId}';
  static readonly getMaintenanceRequestsPath = '/api/MaintenanceRequest';
  static readonly createMaintenanceRequestPath = '/api/MaintenanceRequest';
  static readonly updateMaintenanceRequestPath = '/api/MaintenanceRequest';
  static readonly getMaintenanceRequestsPagePath = '/api/MaintenanceRequest/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Get MaintenanceRequest by id.
   *
   * Get MaintenanceRequest by id.
   * @param maintenanceRequestId undefined
   * @return Success
   */
  getMaintenanceRequestByIdResponse(maintenanceRequestId: string): __Observable<__StrictHttpResponse<GetMaintenanceRequestByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/MaintenanceRequest/${encodeURIComponent(String(maintenanceRequestId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetMaintenanceRequestByIdResponse>;
      })
    );
  }
  /**
   * Get MaintenanceRequest by id.
   *
   * Get MaintenanceRequest by id.
   * @param maintenanceRequestId undefined
   * @return Success
   */
  getMaintenanceRequestById(maintenanceRequestId: string): __Observable<GetMaintenanceRequestByIdResponse> {
    return this.getMaintenanceRequestByIdResponse(maintenanceRequestId).pipe(
      __map(_r => _r.body as GetMaintenanceRequestByIdResponse)
    );
  }

  /**
   * Delete MaintenanceRequest.
   *
   * Delete MaintenanceRequest.
   * @param maintenanceRequestId undefined
   * @return Success
   */
  removeMaintenanceRequestResponse(maintenanceRequestId: string): __Observable<__StrictHttpResponse<RemoveMaintenanceRequestResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/MaintenanceRequest/${encodeURIComponent(String(maintenanceRequestId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveMaintenanceRequestResponse>;
      })
    );
  }
  /**
   * Delete MaintenanceRequest.
   *
   * Delete MaintenanceRequest.
   * @param maintenanceRequestId undefined
   * @return Success
   */
  removeMaintenanceRequest(maintenanceRequestId: string): __Observable<RemoveMaintenanceRequestResponse> {
    return this.removeMaintenanceRequestResponse(maintenanceRequestId).pipe(
      __map(_r => _r.body as RemoveMaintenanceRequestResponse)
    );
  }

  /**
   * Get MaintenanceRequests.
   *
   * Get MaintenanceRequests.
   * @return Success
   */
  getMaintenanceRequestsResponse(): __Observable<__StrictHttpResponse<GetMaintenanceRequestsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/MaintenanceRequest`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetMaintenanceRequestsResponse>;
      })
    );
  }
  /**
   * Get MaintenanceRequests.
   *
   * Get MaintenanceRequests.
   * @return Success
   */
  getMaintenanceRequests(): __Observable<GetMaintenanceRequestsResponse> {
    return this.getMaintenanceRequestsResponse().pipe(
      __map(_r => _r.body as GetMaintenanceRequestsResponse)
    );
  }

  /**
   * Create MaintenanceRequest.
   *
   * Create MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  createMaintenanceRequestResponse(body?: CreateMaintenanceRequestRequest): __Observable<__StrictHttpResponse<CreateMaintenanceRequestResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/MaintenanceRequest`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateMaintenanceRequestResponse>;
      })
    );
  }
  /**
   * Create MaintenanceRequest.
   *
   * Create MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  createMaintenanceRequest(body?: CreateMaintenanceRequestRequest): __Observable<CreateMaintenanceRequestResponse> {
    return this.createMaintenanceRequestResponse(body).pipe(
      __map(_r => _r.body as CreateMaintenanceRequestResponse)
    );
  }

  /**
   * Update MaintenanceRequest.
   *
   * Update MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  updateMaintenanceRequestResponse(body?: UpdateMaintenanceRequestRequest): __Observable<__StrictHttpResponse<UpdateMaintenanceRequestResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/MaintenanceRequest`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateMaintenanceRequestResponse>;
      })
    );
  }
  /**
   * Update MaintenanceRequest.
   *
   * Update MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  updateMaintenanceRequest(body?: UpdateMaintenanceRequestRequest): __Observable<UpdateMaintenanceRequestResponse> {
    return this.updateMaintenanceRequestResponse(body).pipe(
      __map(_r => _r.body as UpdateMaintenanceRequestResponse)
    );
  }

  /**
   * Get MaintenanceRequest Page.
   *
   * Get MaintenanceRequest Page.
   * @param params The `MaintenanceRequestService.GetMaintenanceRequestsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getMaintenanceRequestsPageResponse(params: MaintenanceRequestService.GetMaintenanceRequestsPageParams): __Observable<__StrictHttpResponse<GetMaintenanceRequestsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/MaintenanceRequest/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetMaintenanceRequestsPageResponse>;
      })
    );
  }
  /**
   * Get MaintenanceRequest Page.
   *
   * Get MaintenanceRequest Page.
   * @param params The `MaintenanceRequestService.GetMaintenanceRequestsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getMaintenanceRequestsPage(params: MaintenanceRequestService.GetMaintenanceRequestsPageParams): __Observable<GetMaintenanceRequestsPageResponse> {
    return this.getMaintenanceRequestsPageResponse(params).pipe(
      __map(_r => _r.body as GetMaintenanceRequestsPageResponse)
    );
  }
}

module MaintenanceRequestService {

  /**
   * Parameters for getMaintenanceRequestsPage
   */
  export interface GetMaintenanceRequestsPageParams {
    pageSize: number;
    index: number;
  }
}

export { MaintenanceRequestService }
