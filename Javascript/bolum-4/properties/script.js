//Prototypes
console.log([]);
console.log(new Array());

function Comment(title, body, username) {
  this.title = title;
  this.body = body;
  this.username = username;

  console.log(this);
}
Comment.prototype.display = function () {
  return this.title;
};
Comment.prototype.get_username = function () {
  return this.username;
};

const c1 = new Comment("Güzel kurs", "Kursu çok beğendim", "Arda");
const c2 = new Comment("İdare eder kurs", "idare eder", "Arda");

Array.prototype.get_number = function () {
  return this.length;
};

const arr = ["item1", "item2"];
console.log(err.get_number);
