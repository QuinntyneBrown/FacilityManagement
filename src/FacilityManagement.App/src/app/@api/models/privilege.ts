/* tslint:disable */
import { AccessRight } from './access-right';
import { PrivilegeId } from './privilege-id';
import { RoleId } from './role-id';
export interface Privilege {
  accessRight?: AccessRight;
  aggregate?: string;
  privilegeId?: PrivilegeId;
  roleId?: RoleId;
}
