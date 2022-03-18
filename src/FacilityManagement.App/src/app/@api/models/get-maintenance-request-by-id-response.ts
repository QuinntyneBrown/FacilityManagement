/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface GetMaintenanceRequestByIdResponse {
  maintenanceRequest?: MaintenanceRequestDto;
  validationErrors?: Array<string>;
}
