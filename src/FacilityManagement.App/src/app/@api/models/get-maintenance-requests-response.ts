/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface GetMaintenanceRequestsResponse {
  errors?: Array<string>;
  maintenanceRequests?: Array<MaintenanceRequestDto>;
}
