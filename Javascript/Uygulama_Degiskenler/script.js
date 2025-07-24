var mevcutYıl = 2025;
//Öğrenci 1
var ogrenci1Adi = "Ada Bilgi";
var ogrenci1DogumT = 2015;
var ogrenci1MatNot1 = 50;
var ogrenci1MatNot2 = 70;
var ogrenci1MatNot3 = 90;
var ogrenci1Ort = (ogrenci1MatNot1 + ogrenci1MatNot2 + ogrenci1MatNot3) / 3;
var ogrenci1Yas = mevcutYıl - ogrenci1DogumT;

console.log(ogrenci1Adi);
console.log(ogrenci1DogumT);
console.log(ogrenci1Ort);
console.log(ogrenci1Yas);

//Öğrenci 2

var ogrenci2Adi = "Yiğit Bilgi";
var ogrenci2DogumT = 2010;
var ogrenci2MatNot1 = 40;
var ogrenci2MatNot2 = 45;
var ogrenci2MatNot3 = 30;
var ogrenci2Ort =
  parseInt(ogrenci2MatNot1 + ogrenci2MatNot2 + ogrenci2MatNot3) / 3;
var ogrenci2Yas = mevcutYıl - ogrenci2DogumT;

//Başarı Durumu
var basariDurumuOgr1 = ogrenci1Ort >= 50;
var basariDurumuOgr2 = ogrenci2Ort >= 50;
console.log(basariDurumuOgr1);
console.log(basariDurumuOgr2);
