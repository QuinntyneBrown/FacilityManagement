/* tslint:disable */
import { ProfileDto } from './profile-dto';
import { RoleDto } from './role-dto';
export interface UserDto {
  password?: string;
  profiles?: Array<ProfileDto>;
  roles?: Array<RoleDto>;
  salt?: ArrayBuffer;
  userId?: string;
  userName?: string;
}
