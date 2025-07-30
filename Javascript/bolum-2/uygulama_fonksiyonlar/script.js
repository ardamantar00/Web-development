//Uygulama:Fonksiyonlar

//1
function kelimeAdet(isim, adet) {
  for (let i = 0; i < adet; i++) {
    console.log(isim);
  }
}
kelimeAdet("arda", 4);
//2
function alanCevreHesapla(kisaKenar, uzunKenar) {
  let alan = kisaKenar * uzunKenar;
  let cevre = (kisaKenar + uzunKenar) * 2;
  return `alan: ${alan} çevre: ${cevre}`;
}
console.log(alanCevreHesapla(5, 3));
//3
function yaziTuraAt() {
  let random = Math.random();
  if (random < 0.5) {
    console.log("yazı");
  } else {
    console.log("tura");
  }
}
yaziTuraAt();

//4
function bolenler(sayi) {
  let bolenSayilar = [1];
  for (i = 2; i <= sayi; i++) {
    if (sayi % i == 0) {
      bolenSayilar.push(i);
    }
  }
  return bolenSayilar;
}

console.log(bolenler(60));

//5
function toplam() {
  let sonuc = 0;
  for (let i = 0; i < arguments.length; i++) {
    sonuc += arguments[i];
  }
  return sonuc;
}

sonuc = toplam(10, 30, 55, 45);
console.log(sonuc);
