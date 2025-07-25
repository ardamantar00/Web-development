//String Uygulama

let url = "https://www.sadikturan.com/";
let kursAdi = "Sıfırdan ileri seviyeye Fullstack Web Geliştirme";

//1

console.log(url.length)

//2
console.log(kursAdi.split(" ").length)
//3
console.log(url.startsWith("https"))
//4
console.log(kursAdi.includes("Eğitimi"))
//5
kursAdi = `${url}${kursAdi.toLowerCase().replaceAll(" ","-")}`;
 kursAdi= kursAdi.replaceAll("ş","s").replaceAll("ı","i");

console.log(kursAdi)