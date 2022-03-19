/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface CreateMaintenanceRequestResponse {
  errors?: Array<string>;
  maintenanceRequest?: MaintenanceRequestDto;
}
