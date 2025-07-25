//1
let meyveler = ["Kiraz","Karpuz","Kavun","Erik"];
//2
console.log(meyveler.length);
//3
console.log("İlk eleman " + meyveler[0]);
console.log("Son eleman "+ meyveler[meyveler.length-1]);
//4
console.log(meyveler.includes("kavun"));
console.log(meyveler.indexOf("kavun"));
//5
meyveler.push("Çilek");
console.log(meyveler);
//6
// meyveler.pop();
// meyveler.pop();
meyveler.splice(meyveler.length-2,2);
console.log(meyveler);

//7
let ogr1Ort = (60+90+80)/3;
let ogr1Yas = 2025 -2010;
let ogrenci1 = ["Yiğit Bilgi",2010,ogr1Ort,ogr1Yas];

let ogr2Ort = (70+80+80)/3;
let ogr2Yas = 2025 -2012;
let ogrenci2 = ["Ada Bilgi",2012,ogr2Ort,ogr2Yas];

let ogr3Ort = (60+50+80)/3;
let ogr3Yas = 2025 -2017;
let ogrenci3 = ["Çınar Turan",2010,ogr3Ort,ogr3Yas];

console.log("Öğrenci 1 " + ogrenci1)
console.log("Öğrenci 2 " + ogrenci2)
console.log("Öğrenci 3 " + ogrenci3)