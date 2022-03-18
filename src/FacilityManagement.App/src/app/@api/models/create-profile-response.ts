/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface CreateProfileResponse {
  profile?: ProfileDto;
  validationErrors?: Array<string>;
}
