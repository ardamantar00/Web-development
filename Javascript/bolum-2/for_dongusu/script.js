//For döngüsü

for (let i = 0; i <= 100; i++) {
  console.log(i);
}

let sayılar = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 27];
let toplam = 0;

for (let index = 0; index < sayılar.length; index++) {
  console.log(sayılar[index]);
  toplam += sayılar[index];
}
console.log("Sayıların toplamaı ", toplam);
