//If/Else Uygulama

//1
let sayi = 55;

if (sayi >= 50 && sayi <= 100) {
  console.log("Sayı 50 ile 100 arasında");
}

// 2

let sayi2 = 12;

if (sayi2 > 0 && sayi2 % 2 == 0) {
  console.log("Sayı Pozitif Çift Sayıdır");
}

// //3
// (x = 4), (y = 30), (z = 10);

// if(x > y && y > z){

// }

//3

let x = 40, y =50,z=30;
if(x>y && x>z){
  console.log("x en büyük");
}
else if(y>x && y>z){
  console.log("y en büyük");
}
else if (z>x && z>y){
  console.log("z en büyük");
}
else{
  console.log("Hatalı bilgi");
}

//4

let vize1 = 100,
  vize2 = 70,
  final = 40;

let ortalama = ((vize1 + vize2)/2) * 0.4 + final * 0.6;

  if (ortalama >= 50 && final >= 50) {
    console.log("Geçti");
  } else if (ortalama<=50 && final >= 70) {
    console.log("Şartlı Geçti");
  } else {
    console.log("Kaldı");
  }
