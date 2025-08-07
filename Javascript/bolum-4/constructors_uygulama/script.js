function Player(name) {
  this.name = name;
  this.score = 0;
  this.start = function () {
    return `${this.name} oyuna başladı`;
  };
  this.stop = function () {
    return `${this.name} oyundan çıktı`;
  };
  this.pause = function () {
    return `${this.name} oyunu durdu`;
  };
  this.add_score = function (addscr) {
    this.score += addscr;
  };
  this.show_score = function () {
    return `${this.name} kişisinin score değeri: ${this.score} `;
  };
}
const oyuncu1 = new Player("Ahmet");
const oyuncu2 = new Player("Çınar");
const oyuncu3 = new Player("Yeliz");
console.log(oyuncu1.score);
oyuncu1.add_score(120);
console.log(oyuncu1.score);
console.log(oyuncu1.show_score());
