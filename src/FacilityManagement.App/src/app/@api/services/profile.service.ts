/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetProfileByIdResponse } from '../models/get-profile-by-id-response';
import { RemoveProfileResponse } from '../models/remove-profile-response';
import { GetProfilesResponse } from '../models/get-profiles-response';
import { CreateProfileResponse } from '../models/create-profile-response';
import { CreateProfileRequest } from '../models/create-profile-request';
import { UpdateProfileResponse } from '../models/update-profile-response';
import { UpdateProfileRequest } from '../models/update-profile-request';
import { GetProfilesPageResponse } from '../models/get-profiles-page-response';
@Injectable({
  providedIn: 'root',
})
class ProfileService extends __BaseService {
  static readonly getProfileByIdPath = '/api/Profile/{profileId}';
  static readonly removeProfilePath = '/api/Profile/{profileId}';
  static readonly getProfilesPath = '/api/Profile';
  static readonly createProfilePath = '/api/Profile';
  static readonly updateProfilePath = '/api/Profile';
  static readonly getProfilesPagePath = '/api/Profile/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Get Profile by id.
   *
   * Get Profile by id.
   * @param profileId undefined
   * @return Success
   */
  getProfileByIdResponse(profileId: string): __Observable<__StrictHttpResponse<GetProfileByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Profile/${encodeURIComponent(String(profileId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetProfileByIdResponse>;
      })
    );
  }
  /**
   * Get Profile by id.
   *
   * Get Profile by id.
   * @param profileId undefined
   * @return Success
   */
  getProfileById(profileId: string): __Observable<GetProfileByIdResponse> {
    return this.getProfileByIdResponse(profileId).pipe(
      __map(_r => _r.body as GetProfileByIdResponse)
    );
  }

  /**
   * Delete Profile.
   *
   * Delete Profile.
   * @param profileId undefined
   * @return Success
   */
  removeProfileResponse(profileId: string): __Observable<__StrictHttpResponse<RemoveProfileResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Profile/${encodeURIComponent(String(profileId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveProfileResponse>;
      })
    );
  }
  /**
   * Delete Profile.
   *
   * Delete Profile.
   * @param profileId undefined
   * @return Success
   */
  removeProfile(profileId: string): __Observable<RemoveProfileResponse> {
    return this.removeProfileResponse(profileId).pipe(
      __map(_r => _r.body as RemoveProfileResponse)
    );
  }

  /**
   * Get Profiles.
   *
   * Get Profiles.
   * @return Success
   */
  getProfilesResponse(): __Observable<__StrictHttpResponse<GetProfilesResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Profile`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetProfilesResponse>;
      })
    );
  }
  /**
   * Get Profiles.
   *
   * Get Profiles.
   * @return Success
   */
  getProfiles(): __Observable<GetProfilesResponse> {
    return this.getProfilesResponse().pipe(
      __map(_r => _r.body as GetProfilesResponse)
    );
  }

  /**
   * Create Profile.
   *
   * Create Profile.
   * @param body undefined
   * @return Success
   */
  createProfileResponse(body?: CreateProfileRequest): __Observable<__StrictHttpResponse<CreateProfileResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Profile`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateProfileResponse>;
      })
    );
  }
  /**
   * Create Profile.
   *
   * Create Profile.
   * @param body undefined
   * @return Success
   */
  createProfile(body?: CreateProfileRequest): __Observable<CreateProfileResponse> {
    return this.createProfileResponse(body).pipe(
      __map(_r => _r.body as CreateProfileResponse)
    );
  }

  /**
   * Update Profile.
   *
   * Update Profile.
   * @param body undefined
   * @return Success
   */
  updateProfileResponse(body?: UpdateProfileRequest): __Observable<__StrictHttpResponse<UpdateProfileResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Profile`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateProfileResponse>;
      })
    );
  }
  /**
   * Update Profile.
   *
   * Update Profile.
   * @param body undefined
   * @return Success
   */
  updateProfile(body?: UpdateProfileRequest): __Observable<UpdateProfileResponse> {
    return this.updateProfileResponse(body).pipe(
      __map(_r => _r.body as UpdateProfileResponse)
    );
  }

  /**
   * Get Profile Page.
   *
   * Get Profile Page.
   * @param params The `ProfileService.GetProfilesPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getProfilesPageResponse(params: ProfileService.GetProfilesPageParams): __Observable<__StrictHttpResponse<GetProfilesPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Profile/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetProfilesPageResponse>;
      })
    );
  }
  /**
   * Get Profile Page.
   *
   * Get Profile Page.
   * @param params The `ProfileService.GetProfilesPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getProfilesPage(params: ProfileService.GetProfilesPageParams): __Observable<GetProfilesPageResponse> {
    return this.getProfilesPageResponse(params).pipe(
      __map(_r => _r.body as GetProfilesPageResponse)
    );
  }
}

module ProfileService {

  /**
   * Parameters for getProfilesPage
   */
  export interface GetProfilesPageParams {
    pageSize: number;
    index: number;
  }
}

export { ProfileService }
