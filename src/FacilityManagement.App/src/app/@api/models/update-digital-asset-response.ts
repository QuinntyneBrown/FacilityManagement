/* tslint:disable */
import { DigitalAssetDto } from './digital-asset-dto';
export interface UpdateDigitalAssetResponse {
  digitalAsset?: DigitalAssetDto;
  validationErrors?: Array<string>;
}
