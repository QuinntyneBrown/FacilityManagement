/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface CompleteMaintenanceRequestResponse {
  errors?: Array<string>;
  maintenanceRequest?: MaintenanceRequestDto;
}
