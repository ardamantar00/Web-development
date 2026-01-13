interface Point{
    x:number
    y:number
}
interface Vehicle{
    currentLocation : Point
    travelTo(point: Point): void
}
class Taxi implements Vehicle  {
    color: string
    currentLocation: Point
    
     constructor(location?: Point,color?: string) {
        this.currentLocation = location
        this.color = color
     }
     travelTo(point: Point): void {
        console.log(`Taksi X: ${point.x} Y: ${point.y} konuma gidiyor`)
        this.currentLocation = point
    }
}
let taxi_1 : Taxi = new Taxi({x:45,y:32})
console.log(taxi_1)
let taxi_2 : Taxi = new Taxi()
console.log(taxi_2)
let taxi_3 : Taxi = new Taxi({x:5,y:4},"blue")
console.log(taxi_3)

