const getAverage = (...a:number[]) : string =>{
    let count = 0 
    let total = 0 

    a.forEach(item => {
        total+=item
        count++
    });
    const result = total / count
    return "result " + result
}
const newResult = getAverage(10,20,30,40)
