export class SearchModel {
    constructor(
    public titleKeywords: string,
    public descriptionKeywords: string,
    public carMake: string,
    public carModel: string,
    public transmissionType: string,
    public fuelType: string,
    public engineDisplacement: string,
    public color: string,
    public startYearOfProduction: number,
    public endYearOfProduction: number,
    public startMileage: number,
    public endMileage: number,
    public engineLayout: string,
    public location: string,
    public options: string[],
    public startPrice: number,
    public endPrice: number
){}
}