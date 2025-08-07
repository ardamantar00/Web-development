//Objects

const product = {
  //Properties
  title: "Samsung S24FE",
  description: "Güzel bir telefon",
  price: 40000,
  stock: 20,

  //methods

  display: function () {
    return `Ürün başlığı: ${this.title} ürün açıklaması: ${this.description} ve fiyat: ${this.price}`;
  },
  is_active: function () {
    return this.stock > 0 ? "satışta" : "stok yok";
  },
};

const person = {
  name: "Ahmet",
  surname: "Uçar",
  dogum_yili: 1987,

  yas_hesapla: function () {
    const mevcut_yil = new Date();
    let yas = mevcut_yil.getFullYear() - this.dogum_yili;
    return yas;
  },

  display: function () {
    return `Personel Adı: ${this.name} Personel Soyadı: ${
      this.surname
    } Personel Yaşı: ${this.yas_hesapla()}`;
  },
};

console.log(product.description);
console.log(product.title);
console.log(product.price);
console.log(product.display());
console.log(product.is_active());
console.log(person.display());
