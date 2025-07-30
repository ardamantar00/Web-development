//Uygulama Döngüler

//1
let sayilar = [3, 5, 7, 8, 12, 23, 45, 66];

for (let i = 0; i < sayilar.length; i++) {
  console.log(sayilar[i] ** 2);
}
//2
for (let i = 0; i < sayilar.length; i++) {
  if (sayilar[i] % 5 == 0) {
    console.log(sayilar[i]);
  }
}
//3
let sayi = 100;
while (sayi >= 50) {
  console.log(sayi);
  sayi--;
}
//4
let urunler = ["iphone 16", "samsung s24", "samsung s25", "iphone 15"];
for (let i = 0; i < urunler.length; i++) {
  console.log(urunler[i].toUpperCase());
}
//5
let sayac = 0;
for (let i = 0; i < urunler.length; i++) {
  if (urunler[i].includes("samsung")) {
    sayac++;
  }
}
console.log(sayac);

//6

let ogrenciler = [
  { ad: "Yiğit", soyad: "Bilgi", notlar: [60, 70, 80, 90] },
  { ad: "Ada", soyad: "Bilgi", notlar: [80, 50, 75] },
  { ad: "Çınar", soyad: "Turan", notlar: [70, 70, 80] },
];
let sinif_toplam = 0;
for (let i = 0; i < ogrenciler.length; i++) {
  let not_toplam = 0;
  let adet = 0;
  let ortalama = 0;
  let basari = "";
  for (x = 0; x < ogrenciler[i].notlar.length; x++) {
    not_toplam += ogrenciler[i].notlar[x];
    adet++;
  }

  ortalama = not_toplam / adet;
  sinif_toplam += ortalama;
  if (ortalama >= 50) {
    basari = "başarılı";
  } else {
    basari = "başarısız";
  }
  console.log(
    ` ${basari}  ${ogrenciler[i].ad} ${ogrenciler[i].soyad} ${ortalama}`
  );
}
console.log("Sınıf Ortalaması", sinif_toplam / ogrenciler.length);
