//Strings
var ad = "Arda";
var soyad = "Mantar";
var yas = 19;
var sehir = "Gaziantep";

var mesaj =
  "Benim adım " +
  ad +
  " ve soyadım " +
  soyad +
  "_ " +
  sehir +
  "'de yaşıyorum " +
  
  " emekliliğime " + (65 - yas) + " yıl kaldı";
console.log(mesaj);
//Template Stirngs
mesaj = `Benim adım ${ad} ve soyadım ${soyad} ${sehir}'de yaşıyorum emekliliğime ${65-yas} yıl kaldı`;
console.log(mesaj);