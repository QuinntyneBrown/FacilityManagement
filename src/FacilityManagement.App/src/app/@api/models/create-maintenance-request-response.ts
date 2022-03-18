/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface CreateMaintenanceRequestResponse {
  maintenanceRequest?: MaintenanceRequestDto;
  validationErrors?: Array<string>;
}
