const input = document.getElementById("text");

// function onKeyPress() {
//   console.log("keypress");
// }
// function onKeyUp() {
//   console.log("keyUp");
// }

// input.addEventListener("keydown", onKeyPress);
// input.addEventListener("keyup", onKeyUp);

function onKeyDown(e) {
  // console.log(e);
  // console.log(e.key);
  // document.querySelector("h2").innerText += e.key;
  // if (e.key == "Enter") {
  //   alert("Enter a tıklandı");
  // }
  // if (e.keyCode == 13) {
  //   alert("Enter a tıklandı");
  // }
  // if (e.repeat) {
  //   alert(`${e.key} tuşuna basılı kaldı.`);
  // }
  if (e.ctrlKey && e.key == "a") {
    alert("ctrl + a ya basıldı");
  }
}
input.addEventListener("keydown", onKeyDown);
