let a: number = 5
let b: string = "a"
let c: boolean = true
let d: any;
let e: number[] = [1,2,3,4]
let f: Array<number> = [1,2,3,4]
let g: any[] = [1,"a",false]
let h : [string,number,boolean] = ["a",2,true]

const krediPayment = 0 
const havalePayment = 1
const eftPayment = 2

enum Payment {kredi = 0,havale = 4,kapidaodeme = 3,eft = 2}
let kredi = Payment.kredi
let havale = Payment.havale
let kapidaodeme = Payment.kapidaodeme
let eft = Payment.eft
