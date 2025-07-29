//If/Else Koşul ifadeleri-2

//yas>=18
//mezuniyet == "lise" yada mezuniyet =="üniversite"

let yas = 20;
let mezuniyet = "lise";
if (yas >= 18 && (mezuniyet == "lise" || mezuniyet == "üniversite")) {
  console.log("Ehliyet alabilirsiniz");
} else {
  console.log("Ehliyet Alamazsınız");
}

// and --> &&
// true,true --> true
//true.false -->false

//veya --> ||
//true,false --> true
//true,true --> true
//false,false -->false
