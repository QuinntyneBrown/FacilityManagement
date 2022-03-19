/* tslint:disable */
import { Privilege } from './privilege';
import { RoleId } from './role-id';
export interface Role {
  name?: string;
  privileges?: Array<Privilege>;
  roleId?: RoleId;
}
