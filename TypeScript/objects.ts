interface Point{
    x:number
    y:number
}
interface Vehicle{
    currentLocation : Point
    travelTo(point: Point): void
}
class Taxi implements Vehicle  {
      currentLocation : Point;
        travelTo(point: Point): void {
            console.log(`Taksi X : ${point.x} Y: ${point.y} konuma gidiyor `)
        }
}
class Bus implements Vehicle{
    currentLocation : Point
    travelTo(point: Point): void {
         console.log(`Otobüs X : ${point.x} Y: ${point.y} konuma gidiyor `)
        }
}
let taxi_1 : Taxi = new Taxi()
taxi_1.travelTo({x:45,y:32})
console.log(taxi_1.currentLocation = {x:5,y:10})
let bus_1 = new Bus()
bus_1.travelTo({x:6,y:19})
