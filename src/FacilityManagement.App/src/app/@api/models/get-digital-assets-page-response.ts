/* tslint:disable */
import { DigitalAssetDto } from './digital-asset-dto';
export interface GetDigitalAssetsPageResponse {
  entities?: Array<DigitalAssetDto>;
  length?: number;
  validationErrors?: Array<string>;
}
