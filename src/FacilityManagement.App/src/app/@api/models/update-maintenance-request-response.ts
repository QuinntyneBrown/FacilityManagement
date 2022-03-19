/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface UpdateMaintenanceRequestResponse {
  errors?: Array<string>;
  maintenanceRequest?: MaintenanceRequestDto;
}
