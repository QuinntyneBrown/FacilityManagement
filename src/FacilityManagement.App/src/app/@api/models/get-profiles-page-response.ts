/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface GetProfilesPageResponse {
  entities?: Array<ProfileDto>;
  length?: number;
  validationErrors?: Array<string>;
}
