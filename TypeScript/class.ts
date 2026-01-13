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
            console.log(`Taksi X : ${point.x} Y: ${point.y} konuma gitti `)
        }
}
class Bus implements Vehicle{
    currentLocation : Point
    travelTo(point: Point): void {
         console.log(`Otobüs X : ${point.x} Y: ${point.y} konuma gitti `)
        }
}

