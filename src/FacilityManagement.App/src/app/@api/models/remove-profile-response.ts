/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface RemoveProfileResponse {
  profile?: ProfileDto;
  validationErrors?: Array<string>;
}
