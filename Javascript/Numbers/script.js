//Numbers
let sonuc;
sonuc = "10";
sonuc = Number("10")
sonuc = parseInt("10.34")
sonuc = parseFloat("12.32")
sonuc = parseInt("10012af")

sonuc = parseInt("A13")
sonuc = isNaN("A13")
sonuc = Number.isInteger(12.5)

let sayi = 142.56237;
sonuc = sayi.toPrecision(5);
sonuc = sayi.toFixed(2);
sonuc = Math.round(2.4);
sonuc = Math.round(2.6);
sonuc = Math.ceil(2.4);
sonuc = Math.floor(2.4)
sonuc = Math.sqrt(25);
sonuc = Math.pow(5,3);
sonuc = Math.min(1,2,3,4,5,6,7,8);
sonuc = Math.max(1,2,3,4,5,6,7,8);
sonuc = parseInt(Math.random() * 100 + 50);
console.log(typeof sonuc);
console.log(sonuc)
