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
import { GetMaintenanceRequestsPageResponse } from '../models/get-maintenance-requests-page-response';
import { ReceiveMaintenanceRequestResponse } from '../models/receive-maintenance-request-response';
import { ReceiveMaintenanceRequestRequest } from '../models/receive-maintenance-request-request';
import { CompleteMaintenanceRequestResponse } from '../models/complete-maintenance-request-response';
import { CompleteMaintenanceRequestRequest } from '../models/complete-maintenance-request-request';
import { StartMaintenanceRequestResponse } from '../models/start-maintenance-request-response';
import { StartMaintenanceRequestRequest } from '../models/start-maintenance-request-request';
import { UpdateMaintenanceRequestDescriptionResponse } from '../models/update-maintenance-request-description-response';
import { UpdateMaintenanceRequestDescriptionRequest } from '../models/update-maintenance-request-description-request';
import { UpdateMaintenanceRequestWorkDetailsResponse } from '../models/update-maintenance-request-work-details-response';
import { UpdateMaintenanceRequestWorkDetailsRequest } from '../models/update-maintenance-request-work-details-request';
@Injectable({
  providedIn: 'root',
})
class MaintenanceRequestService extends __BaseService {
  static readonly getMaintenanceRequestByIdPath = '/api/MaintenanceRequest/{maintenanceRequestId}';
  static readonly removeMaintenanceRequestPath = '/api/MaintenanceRequest/{maintenanceRequestId}';
  static readonly getMaintenanceRequestsPath = '/api/MaintenanceRequest';
  static readonly createMaintenanceRequestPath = '/api/MaintenanceRequest';
  static readonly getMaintenanceRequestsPagePath = '/api/MaintenanceRequest/page/{pageSize}/{index}';
  static readonly receiveMaintenanceRequestPath = '/api/MaintenanceRequest/receive';
  static readonly completeMaintenanceRequestPath = '/api/MaintenanceRequest/complete';
  static readonly startMaintenanceRequestPath = '/api/MaintenanceRequest/start';
  static readonly updateMaintenanceRequestDescriptionPath = '/api/MaintenanceRequest/description';
  static readonly updateMaintenanceRequestWorkDetailsPath = '/api/MaintenanceRequest/work-details';

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

  /**
   * Receive MaintenanceRequest.
   *
   * Receive MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  receiveMaintenanceRequestResponse(body?: ReceiveMaintenanceRequestRequest): __Observable<__StrictHttpResponse<ReceiveMaintenanceRequestResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/MaintenanceRequest/receive`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<ReceiveMaintenanceRequestResponse>;
      })
    );
  }
  /**
   * Receive MaintenanceRequest.
   *
   * Receive MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  receiveMaintenanceRequest(body?: ReceiveMaintenanceRequestRequest): __Observable<ReceiveMaintenanceRequestResponse> {
    return this.receiveMaintenanceRequestResponse(body).pipe(
      __map(_r => _r.body as ReceiveMaintenanceRequestResponse)
    );
  }

  /**
   * Complete MaintenanceRequest.
   *
   * Complete MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  completeMaintenanceRequestResponse(body?: CompleteMaintenanceRequestRequest): __Observable<__StrictHttpResponse<CompleteMaintenanceRequestResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/MaintenanceRequest/complete`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CompleteMaintenanceRequestResponse>;
      })
    );
  }
  /**
   * Complete MaintenanceRequest.
   *
   * Complete MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  completeMaintenanceRequest(body?: CompleteMaintenanceRequestRequest): __Observable<CompleteMaintenanceRequestResponse> {
    return this.completeMaintenanceRequestResponse(body).pipe(
      __map(_r => _r.body as CompleteMaintenanceRequestResponse)
    );
  }

  /**
   * Start MaintenanceRequest.
   *
   * Start MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  startMaintenanceRequestResponse(body?: StartMaintenanceRequestRequest): __Observable<__StrictHttpResponse<StartMaintenanceRequestResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/MaintenanceRequest/start`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<StartMaintenanceRequestResponse>;
      })
    );
  }
  /**
   * Start MaintenanceRequest.
   *
   * Start MaintenanceRequest.
   * @param body undefined
   * @return Success
   */
  startMaintenanceRequest(body?: StartMaintenanceRequestRequest): __Observable<StartMaintenanceRequestResponse> {
    return this.startMaintenanceRequestResponse(body).pipe(
      __map(_r => _r.body as StartMaintenanceRequestResponse)
    );
  }

  /**
   * Update MaintenanceRequest description.
   *
   * Update MaintenanceRequest description.
   * @param body undefined
   * @return Success
   */
  updateMaintenanceRequestDescriptionResponse(body?: UpdateMaintenanceRequestDescriptionRequest): __Observable<__StrictHttpResponse<UpdateMaintenanceRequestDescriptionResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/MaintenanceRequest/description`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateMaintenanceRequestDescriptionResponse>;
      })
    );
  }
  /**
   * Update MaintenanceRequest description.
   *
   * Update MaintenanceRequest description.
   * @param body undefined
   * @return Success
   */
  updateMaintenanceRequestDescription(body?: UpdateMaintenanceRequestDescriptionRequest): __Observable<UpdateMaintenanceRequestDescriptionResponse> {
    return this.updateMaintenanceRequestDescriptionResponse(body).pipe(
      __map(_r => _r.body as UpdateMaintenanceRequestDescriptionResponse)
    );
  }

  /**
   * Update MaintenanceRequest WorkDetails.
   *
   * Update MaintenanceRequest WorkDetails.
   * @param body undefined
   * @return Success
   */
  updateMaintenanceRequestWorkDetailsResponse(body?: UpdateMaintenanceRequestWorkDetailsRequest): __Observable<__StrictHttpResponse<UpdateMaintenanceRequestWorkDetailsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/MaintenanceRequest/work-details`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateMaintenanceRequestWorkDetailsResponse>;
      })
    );
  }
  /**
   * Update MaintenanceRequest WorkDetails.
   *
   * Update MaintenanceRequest WorkDetails.
   * @param body undefined
   * @return Success
   */
  updateMaintenanceRequestWorkDetails(body?: UpdateMaintenanceRequestWorkDetailsRequest): __Observable<UpdateMaintenanceRequestWorkDetailsResponse> {
    return this.updateMaintenanceRequestWorkDetailsResponse(body).pipe(
      __map(_r => _r.body as UpdateMaintenanceRequestWorkDetailsResponse)
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
