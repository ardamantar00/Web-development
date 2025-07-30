//While Döngüsü
let i = 1;
while (i <= 10) {
  i++;

  if (i % 2 == 0) {
    break;
  }
  console.log("Döngü bitti");
}

let a = 1;
do {
  console.log(a);
  a++;
} while (a <= 10);
