import { Serie } from "../videos/serie";

export class Favorite {
    public series: Array<Serie>

    constructor(series: Array<Serie> = []) {
        this.series = series
    }

    checkIfIsFavorite(serie: Serie): boolean {
        const index = this.series.findIndex(findSerie => findSerie.id === serie.id)
        return index >= 0
    }
}