/* tslint:disable */
import { Profile } from './profile';
import { Role } from './role';
export interface UserDto {
  password?: string;
  profiles?: Array<Profile>;
  roles?: Array<Role>;
  salt?: ArrayBuffer;
  userId?: string;
  userName?: string;
}
