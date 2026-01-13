import { IProductService } from "./IProductService";
import { Product } from "./Product";
import { ProductService } from "./ProductService";

let _productService = new ProductService()
let result;
// result = _productService.getProducts()
// result = _productService.getById(2)
let p = new Product()
p.id = 2
p.name = "Iphone 15"
p.category = "Telefon"
p.price = 90000
_productService.saveProduct(p)

// _productService.deleteProduct(p)
result = _productService.getProducts()
console.log(result)