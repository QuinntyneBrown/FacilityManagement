/* tslint:disable */
import { DigitalAssetDto } from './digital-asset-dto';
export interface RemoveDigitalAssetResponse {
  digitalAsset?: DigitalAssetDto;
  validationErrors?: Array<string>;
}
