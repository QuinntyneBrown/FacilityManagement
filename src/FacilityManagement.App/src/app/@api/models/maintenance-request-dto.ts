/* tslint:disable */
import { AddressDto } from './address-dto';
import { MaintenanceRequestCommentDto } from './maintenance-request-comment-dto';
import { MaintenanceRequestDigitalAssetDto } from './maintenance-request-digital-asset-dto';
import { ProfileDto } from './profile-dto';
import { MaintenanceRequestStatus } from './maintenance-request-status';
import { UnitEntered } from './unit-entered';
export interface MaintenanceRequestDto {
  address?: AddressDto;
  comments?: Array<MaintenanceRequestCommentDto>;
  date?: string;
  description?: string;
  digitalAssets?: Array<MaintenanceRequestDigitalAssetDto>;
  maintenanceRequestId?: string;
  phone?: string;
  receivedByName?: string;
  receivedByProfileId?: string;
  receivedDate?: string;
  requestedByName?: string;
  requestedByProfile?: ProfileDto;
  requestedByProfileId?: string;
  status?: MaintenanceRequestStatus;
  unattendedUnitEntryAllowed?: boolean;
  unitEntered?: UnitEntered;
  workCompleted?: string;
  workCompletedByName?: string;
  workDetails?: string;
  workStarted?: string;
}
