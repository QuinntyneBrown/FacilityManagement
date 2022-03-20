/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface StartMaintenanceRequestResponse {
  errors?: Array<string>;
  maintenanceRequest?: MaintenanceRequestDto;
}
