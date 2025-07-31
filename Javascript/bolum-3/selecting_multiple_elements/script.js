let sonuc;
sonuc = document.getElementsByClassName("item")[0];
sonuc = document.getElementsByClassName("item")[1];
sonuc = document.getElementsByClassName("item")[2];

// const items = document.getElementsByClassName("item");

// const group1 = document.getElementById("group1");
// const items = group1.getElementsByTagName("li");

// const items = document.querySelectorAll("li");
const items = document.querySelectorAll("#group1 .item");

// for (let i = 0; i < items.length; i++) {
//   console.log(items[i]);
//

for (let item of items) {
  item.style.color = "red";
  item.style.fontSize = "20px";
  item.innerText = "Elaman";
}

// console.log(sonuc);
