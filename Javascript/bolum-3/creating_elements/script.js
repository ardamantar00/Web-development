function createListItem(text) {
  const li = document.createElement("li");
  li.className = "item";
  li.id = "item4";
  li.setAttribute("data-id", "5");
  li.innerText = text;

  const ch = document.createElement("input");
  ch.type = "checkbox";
  ch.className = "ch1";
  li.appendChild(ch);

  document.getElementById("myList").appendChild(li);
}

// createListItem("item4");
// createListItem("item5");

function createListItem2(text) {
  const li = document.createElement("li");
  li.className = "item";
  li.innerHTML = `${text} <input type="checkbox" />`;

  document.getElementById("myList").appendChild(li);
}
createListItem2("item4");
