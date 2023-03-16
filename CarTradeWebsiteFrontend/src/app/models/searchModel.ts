export class SearchModel {
    constructor(
    public titleKeywords: string,
    public descriptionKeywords: string,
    public carMake: string,
    public carModel: string,
    public fuelType: string,
    public engineLayout: string,
    public mileage: number,
    public yearOfProduction: number,
    public color: string,
    public engineDisplacement: string,
    public transmissionType: string,
    public location: string,
){}
}