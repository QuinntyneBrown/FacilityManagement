/* tslint:disable */
import { MaintenanceRequestDto } from './maintenance-request-dto';
export interface GetMaintenanceRequestsPageResponse {
  entities?: Array<MaintenanceRequestDto>;
  length?: number;
  validationErrors?: Array<string>;
}
