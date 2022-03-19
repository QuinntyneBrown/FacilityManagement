/* tslint:disable */
import { AddressDto } from './address-dto';
export interface CreateMaintenanceRequestRequest {
  address?: AddressDto;
  description?: string;
  phone?: string;
  requestedByName?: string;
  requestedByProfileId?: string;
  unattendedUnitEntryAllowed?: boolean;
}
