/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface UpdateMaintenanceRequestResponse {
  maintenanceRequest?: MaintenanceRequestDto;
  validationErrors?: Array<string>;
}
