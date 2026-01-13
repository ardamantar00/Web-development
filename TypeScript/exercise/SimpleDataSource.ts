import { Product } from "./Product";

export class SimpleDataSource{
    private products : Array<Product>

    constructor() {
        this.products = new Array<Product>(
            new Product(1,"Samsung S21FE","Telefon",20000),
            new Product(2,"Samsung S22FE","Telefon",25000),
            new Product(3,"Samsung S23FE","Telefon",32000),
            new Product(4,"Samsung S24FE","Telefon",40000),
        )
        
    }
    getProducts(): Product[] {
        return this.products
    } 
}