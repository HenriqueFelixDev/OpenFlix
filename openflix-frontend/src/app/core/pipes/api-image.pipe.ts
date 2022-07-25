import { Pipe, PipeTransform } from "@angular/core";
import { environment } from "src/environments/environment";

@Pipe({
    name: 'apiImage'
})
export class ApiImagePipe implements PipeTransform {
    transform(imageUrl: string, defaultImage: string = '') {
        if (imageUrl) {
            return environment.apiResourcesUrl + imageUrl
        }

        return defaultImage
    }
}