/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface GetProfilesResponse {
  profiles?: Array<ProfileDto>;
  validationErrors?: Array<string>;
}
