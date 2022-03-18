/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface UpdateProfileResponse {
  profile?: ProfileDto;
  validationErrors?: Array<string>;
}
