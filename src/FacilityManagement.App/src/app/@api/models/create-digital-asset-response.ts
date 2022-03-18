/* tslint:disable */
import { DigitalAssetDto } from './digital-asset-dto';
export interface CreateDigitalAssetResponse {
  digitalAsset?: DigitalAssetDto;
  validationErrors?: Array<string>;
}
