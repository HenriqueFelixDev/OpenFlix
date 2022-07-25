import { Serie } from "./serie"

export interface CategoryzedVideo {
    categoryId: number
    categoryName: string
    series: Array<Serie>
}