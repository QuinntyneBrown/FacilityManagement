/* tslint:disable */
import { DigitalAssetDto } from './digital-asset-dto';
export interface GetDigitalAssetsResponse {
  digitalAssets?: Array<DigitalAssetDto>;
  validationErrors?: Array<string>;
}
