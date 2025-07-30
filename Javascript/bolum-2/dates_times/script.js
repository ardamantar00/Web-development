//Dates ve Times

let simdi = new Date();

// get methods

let sonuc = simdi;
sonuc = simdi.getDate(); //Gün
sonuc = simdi.getDay(); // 0 -6 0:pazar, 6:C.tesi
sonuc = simdi.getFullYear(); //Yıl

//Set methods

simdi.setFullYear(2026);
simdi.setMonth(1);
simdi.setDate(20);
console.log(simdi);

let dogumTarihi = new Date(2024, 6, 15);
sonuc = dogumTarihi;
sonuc = simdi.getFullYear() - dogumTarihi.getFullYear();
console.log(sonuc);

let milisecond = simdi - dogumTarihi;

let saniye = milisecond / 1000;
let dakika = saniye / 60;
let saat = dakika / 60;
let gun = saat / 24;
console.log(gun);
