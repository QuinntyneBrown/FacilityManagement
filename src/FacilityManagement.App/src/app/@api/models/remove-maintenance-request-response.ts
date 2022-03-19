/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface RemoveMaintenanceRequestResponse {
  errors?: Array<string>;
  maintenanceRequest?: MaintenanceRequestDto;
}
