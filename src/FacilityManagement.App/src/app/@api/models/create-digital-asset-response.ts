/* tslint:disable */
import { DigitalAssetDto } from './digital-asset-dto';
export interface CreateDigitalAssetResponse {
  digitalAsset?: DigitalAssetDto;
  errors?: Array<string>;
}
