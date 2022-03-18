/* tslint:disable */
import { DigitalAssetDto } from './digital-asset-dto';
export interface GetDigitalAssetByIdResponse {
  digitalAsset?: DigitalAssetDto;
  validationErrors?: Array<string>;
}
