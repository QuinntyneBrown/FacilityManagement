/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface GetMaintenanceRequestByIdResponse {
  errors?: Array<string>;
  maintenanceRequest?: MaintenanceRequestDto;
}
