const div = document.querySelector("div");
const img = document.querySelector("img");

function onClick() {
  console.log("onclick");
}

function doubleClick() {
  console.log("dbclick");
}

function onContextmenu() {
  console.log("onContextmenu");
}
function onMouseDown() {
  console.log("onMouseDown");
}
function onMouseEnter() {
  console.log("onMouseEnter");
}

function onMouseMove() {
  console.log("onMouseMove");
}
function onDrag() {
  console.log("onDrag");
}
function dragStart() {
  console.log("dragStart");
}
function dragEnd() {
  console.log("dragEnd");
}
div.addEventListener("click", onClick);
div.addEventListener("dblclick", doubleClick);
div.addEventListener("contextmenu", onContextmenu);
div.addEventListener("mousedown", onMouseDown);
div.addEventListener("mouseenter", onMouseEnter);
div.addEventListener("mousemove", onMouseMove);
img.addEventListener("drag", onDrag);
img.addEventListener("dragstart", dragStart);
img.addEventListener("dragend", dragEnd);
