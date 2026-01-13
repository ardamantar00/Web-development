interface Point{
    x:number
    y:number
}
interface Vehicle{
    travelTo(point: Point): void
}
class Taxi implements Vehicle  {
    
     constructor(private location?: Point,private color?: string) { }
     travelTo(point: Point): void {
        console.log(`Taksi X: ${point.x} Y: ${point.y} konuma gidiyor`)
    }
}
let taxi_1 : Taxi = new Taxi({x:5,y:2})
taxi_1.travelTo({x:10,y:4})



