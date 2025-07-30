//Scopes

//Global Scope
var isim = "Ahmet";
const tc = "11111111111";

function yazdir() {
  // Function Scope
  var isim = "Mehmet";
  var yas = "19";
  console.log(yas);
  console.log(isim);
}

if (true) {
  let isim = "Canan"; //let ile block scope oluşturmuş olduk.
  let cinsiyet = "Kadın";
  console.log(isim);
  console.log(cinsiyet);
}

//Fonksiyonlar kendi scope alanlarını oluşturur
//Block içerisinde yeni scope oluşmaz (let,const)

//console.log(cinsiyet);

console.log(isim);
console.log(yazdir());
