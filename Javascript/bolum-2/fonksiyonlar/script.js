//Fonksiyonlar

function selamla(mesaj) {
  console.log(mesaj);
}
selamla("merhaba");
selamla("selam");

function yasHesapla(dogumYili) {
  let mevcutYil = new Date().getFullYear();
  return mevcutYil - dogumYili;
}

console.log(yasHesapla(2005));
console.log(yasHesapla(1990));

function emekliliğeKalanYıl(dogumYili, isim) {
  let yas = yasHesapla(dogumYili);
  let kalanYil = 65 - yas;

  if (kalanYil > 0) {
    console.log(`${isim} emekli olmanıza ${kalanYil} yıl kaldı`);
  } else {
    console.log("Zaten emekli oldunuz");
  }
}
emekliliğeKalanYıl(2005, "arda");
emekliliğeKalanYıl(1980, "mesut");
