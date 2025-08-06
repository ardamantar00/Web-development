const div = document.querySelectorAll("div");

function onClick(e) {
  // console.log(e);
  // console.log(e.target);
  // console.log(e.timeStamp);
  // console.log(e.clientX);
  // console.log(e.clientY);
  console.log(e.offsetX);
  console.log(e.offsetY);
}

for (let i = 0; i < 3; i++) {
  div[i].addEventListener("click", onClick);
}
document.querySelector("a").addEventListener("click", function (e) {
  e.preventDefault();
  console.log("linke tıklandı");
});
