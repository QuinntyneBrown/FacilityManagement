/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface ReceiveMaintenanceRequestResponse {
  errors?: Array<string>;
  maintenanceRequest?: MaintenanceRequestDto;
}
