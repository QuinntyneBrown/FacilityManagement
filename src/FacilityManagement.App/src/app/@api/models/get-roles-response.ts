/* tslint:disable */
import { RoleDto } from './role-dto';
export interface GetRolesResponse {
  errors?: Array<string>;
  roles?: Array<RoleDto>;
}
