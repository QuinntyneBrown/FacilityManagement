/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface RemoveMaintenanceRequestResponse {
  maintenanceRequest?: MaintenanceRequestDto;
  validationErrors?: Array<string>;
}
