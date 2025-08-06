const mesaj = document.getElementById("mesaj");
const button = document.querySelector("button");
const buttonContainer = document.getElementById("buttons");
function mesajiGoster() {
  console.log(mesaj.value);
  mesaj.value = "";
}
function mesajiGoster2() {
  console.log("mesaj2");
}
button.addEventListener("click", mesajiGoster); // sadece fonks. adı yazılır
button.addEventListener("click", mesajiGoster2);

for (let i = 1; i < 5; i++) {
  let button = document.createElement("button");
  button.id = "btn" + i;
  button.innerText = "btn " + i;
  button.addEventListener("click", mesajiGoster);

  buttonContainer.appendChild(button);
}

document.getElementById("btn1").removeEventListener("click", mesajiGoster);
