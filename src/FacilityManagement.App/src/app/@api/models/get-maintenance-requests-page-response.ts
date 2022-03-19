/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface GetMaintenanceRequestsPageResponse {
  entities?: Array<MaintenanceRequestDto>;
  errors?: Array<string>;
  length?: number;
}
