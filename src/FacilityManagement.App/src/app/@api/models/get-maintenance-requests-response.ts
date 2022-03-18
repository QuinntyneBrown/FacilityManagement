/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface GetMaintenanceRequestsResponse {
  maintenanceRequests?: Array<MaintenanceRequestDto>;
  validationErrors?: Array<string>;
}
