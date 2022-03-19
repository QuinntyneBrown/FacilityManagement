/* tslint:disable */
import { RoleDto } from './role-dto';
export interface GetRolesPageResponse {
  entities?: Array<RoleDto>;
  errors?: Array<string>;
  length?: number;
}
