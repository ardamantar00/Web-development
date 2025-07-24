//Dizi Methodları
let ogrenciler = ["Ahmet","Arda","Fuat"]

let sonuc;
sonuc = ogrenciler.length;
sonuc = ogrenciler.toString();
sonuc = ogrenciler.join("-")

//Elaman Silme
// sonuc = ogrenciler.pop();
// sonuc= ogrenciler.shift();

//Eleman Ekleme
// sonuc = ogrenciler.push("Sena");
// sonuc = ogrenciler.unshift("Sena");

//Elaman Arama
// sonuc = ogrenciler.indexOf("Arda");
// sonuc = ogrenciler.lastIndexOf("Fuat");
// sonuc = ogrenciler.includes("Yiğit");

//Eleman Silme, Ekleme
sonuc = ogrenciler.splice(0,0,"Ali","Canan"); //array.splice(başlangıçIndex, silinecekAdet, ekle1, ekle2, ...)
console.log(sonuc);
console.log(ogrenciler);
