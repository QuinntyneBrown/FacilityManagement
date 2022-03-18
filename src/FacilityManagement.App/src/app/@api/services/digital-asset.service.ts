/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetDigitalAssetByIdResponse } from '../models/get-digital-asset-by-id-response';
import { RemoveDigitalAssetResponse } from '../models/remove-digital-asset-response';
import { GetDigitalAssetsResponse } from '../models/get-digital-assets-response';
import { CreateDigitalAssetResponse } from '../models/create-digital-asset-response';
import { CreateDigitalAssetRequest } from '../models/create-digital-asset-request';
import { UpdateDigitalAssetResponse } from '../models/update-digital-asset-response';
import { UpdateDigitalAssetRequest } from '../models/update-digital-asset-request';
import { GetDigitalAssetsPageResponse } from '../models/get-digital-assets-page-response';
@Injectable({
  providedIn: 'root',
})
class DigitalAssetService extends __BaseService {
  static readonly getDigitalAssetByIdPath = '/api/DigitalAsset/{digitalAssetId}';
  static readonly removeDigitalAssetPath = '/api/DigitalAsset/{digitalAssetId}';
  static readonly getDigitalAssetsPath = '/api/DigitalAsset';
  static readonly createDigitalAssetPath = '/api/DigitalAsset';
  static readonly updateDigitalAssetPath = '/api/DigitalAsset';
  static readonly getDigitalAssetsPagePath = '/api/DigitalAsset/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Get DigitalAsset by id.
   *
   * Get DigitalAsset by id.
   * @param digitalAssetId undefined
   * @return Success
   */
  getDigitalAssetByIdResponse(digitalAssetId: string): __Observable<__StrictHttpResponse<GetDigitalAssetByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/DigitalAsset/${encodeURIComponent(String(digitalAssetId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetDigitalAssetByIdResponse>;
      })
    );
  }
  /**
   * Get DigitalAsset by id.
   *
   * Get DigitalAsset by id.
   * @param digitalAssetId undefined
   * @return Success
   */
  getDigitalAssetById(digitalAssetId: string): __Observable<GetDigitalAssetByIdResponse> {
    return this.getDigitalAssetByIdResponse(digitalAssetId).pipe(
      __map(_r => _r.body as GetDigitalAssetByIdResponse)
    );
  }

  /**
   * Delete DigitalAsset.
   *
   * Delete DigitalAsset.
   * @param digitalAssetId undefined
   * @return Success
   */
  removeDigitalAssetResponse(digitalAssetId: string): __Observable<__StrictHttpResponse<RemoveDigitalAssetResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/DigitalAsset/${encodeURIComponent(String(digitalAssetId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveDigitalAssetResponse>;
      })
    );
  }
  /**
   * Delete DigitalAsset.
   *
   * Delete DigitalAsset.
   * @param digitalAssetId undefined
   * @return Success
   */
  removeDigitalAsset(digitalAssetId: string): __Observable<RemoveDigitalAssetResponse> {
    return this.removeDigitalAssetResponse(digitalAssetId).pipe(
      __map(_r => _r.body as RemoveDigitalAssetResponse)
    );
  }

  /**
   * Get DigitalAssets.
   *
   * Get DigitalAssets.
   * @return Success
   */
  getDigitalAssetsResponse(): __Observable<__StrictHttpResponse<GetDigitalAssetsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/DigitalAsset`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetDigitalAssetsResponse>;
      })
    );
  }
  /**
   * Get DigitalAssets.
   *
   * Get DigitalAssets.
   * @return Success
   */
  getDigitalAssets(): __Observable<GetDigitalAssetsResponse> {
    return this.getDigitalAssetsResponse().pipe(
      __map(_r => _r.body as GetDigitalAssetsResponse)
    );
  }

  /**
   * Create DigitalAsset.
   *
   * Create DigitalAsset.
   * @param body undefined
   * @return Success
   */
  createDigitalAssetResponse(body?: CreateDigitalAssetRequest): __Observable<__StrictHttpResponse<CreateDigitalAssetResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/DigitalAsset`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateDigitalAssetResponse>;
      })
    );
  }
  /**
   * Create DigitalAsset.
   *
   * Create DigitalAsset.
   * @param body undefined
   * @return Success
   */
  createDigitalAsset(body?: CreateDigitalAssetRequest): __Observable<CreateDigitalAssetResponse> {
    return this.createDigitalAssetResponse(body).pipe(
      __map(_r => _r.body as CreateDigitalAssetResponse)
    );
  }

  /**
   * Update DigitalAsset.
   *
   * Update DigitalAsset.
   * @param body undefined
   * @return Success
   */
  updateDigitalAssetResponse(body?: UpdateDigitalAssetRequest): __Observable<__StrictHttpResponse<UpdateDigitalAssetResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/DigitalAsset`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateDigitalAssetResponse>;
      })
    );
  }
  /**
   * Update DigitalAsset.
   *
   * Update DigitalAsset.
   * @param body undefined
   * @return Success
   */
  updateDigitalAsset(body?: UpdateDigitalAssetRequest): __Observable<UpdateDigitalAssetResponse> {
    return this.updateDigitalAssetResponse(body).pipe(
      __map(_r => _r.body as UpdateDigitalAssetResponse)
    );
  }

  /**
   * Get DigitalAsset Page.
   *
   * Get DigitalAsset Page.
   * @param params The `DigitalAssetService.GetDigitalAssetsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getDigitalAssetsPageResponse(params: DigitalAssetService.GetDigitalAssetsPageParams): __Observable<__StrictHttpResponse<GetDigitalAssetsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/DigitalAsset/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetDigitalAssetsPageResponse>;
      })
    );
  }
  /**
   * Get DigitalAsset Page.
   *
   * Get DigitalAsset Page.
   * @param params The `DigitalAssetService.GetDigitalAssetsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getDigitalAssetsPage(params: DigitalAssetService.GetDigitalAssetsPageParams): __Observable<GetDigitalAssetsPageResponse> {
    return this.getDigitalAssetsPageResponse(params).pipe(
      __map(_r => _r.body as GetDigitalAssetsPageResponse)
    );
  }
}

module DigitalAssetService {

  /**
   * Parameters for getDigitalAssetsPage
   */
  export interface GetDigitalAssetsPageParams {
    pageSize: number;
    index: number;
  }
}

export { DigitalAssetService }
