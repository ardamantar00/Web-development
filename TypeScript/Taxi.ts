export class Taxi implements Vehicle  {
    
     constructor(private _location?: Point,private _color?: string) { }
     travelTo(point: Point): void {
        console.log(`Taksi X: ${point.x} Y: ${point.y} konuma gidiyor`)
    }
    get Location(){
        return this._location
    }
    set Location(value:Point){
        if(value.x < 0 || value.y < 0 ){
            throw new Error("Değerler negatif olamaz")
        }
        this._location = value
    }
}