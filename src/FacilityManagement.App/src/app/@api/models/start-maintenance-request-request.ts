/* tslint:disable */
import { UnitEntered } from './unit-entered';
export interface StartMaintenanceRequestRequest {
  maintenanceRequestId?: string;
  unitEntered?: UnitEntered;
  workStarted?: string;
}
