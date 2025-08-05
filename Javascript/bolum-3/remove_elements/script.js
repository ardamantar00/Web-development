function clearHeader() {
  const h1 = document.querySelector("h1");
  h1.remove();
}
// clearHeader();

function removeItem1() {
  // const firstItem = document.querySelector("li:first-child");
  // firstItem.remove();

  const ul = document.querySelector("ul");
  const firstItem = document.querySelector("li:first-child");

  ul.removeChild(firstItem);
}
// removeItem1();

function removeItem(number) {
  const ul = document.querySelector("ul");
  const item = document.querySelector(`li:nth-child(${number})`);

  ul.removeChild(item);
}
// removeItem(3);

function removeAll() {
  // const ul = document.querySelector("ul");

  // ul.innerHTML = "";

  //2.Yöntem

  const ul = document.querySelector("ul");

  while (ul.firstChild) {
    // ul.removeChild(ul.firstChild);

    ul.firstChild.remove();
  }
}
removeAll();
