function Product(title, description, price, stock) {
  //Properties
  this.title = title;
  this.description = description;
  this.price = price;
  this.stock = stock;
  //Methods

  this.display = function () {
    return `Ürün başlığı: ${this.title} ürün açıklaması: ${this.description} ve fiyat: ${this.price}`;
  };
  this.is_active = function () {
    return this.stock > 0 ? "satışta" : "stok yok";
  };
}

const product1 = new Product("Sansung S25", "Güzel Telefon", 40000, 100);
const product2 = new Product("Samsung S24", "Güzel Telefon", 30000, 0);
const product3 = new Product("Samsung S23", "Güzel Telefon", 20000, 100);

// console.log(
//   product1.title,
//   product1.description,
//   product1.price,
//   product1.stock
// );
console.log(product1.display());
console.log(product2.display());
console.log(product3.display());
console.log(product1.is_active());
console.log(product2.is_active());
console.log(product3.is_active());
