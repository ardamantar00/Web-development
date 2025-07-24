//Nesneler {}

//key-value
let kullanici = {"ad": "Arda",
                "soyad":"Mantar",
                "yas":19,
                "adres":{
                    "sehir": "gaziantep",
                    "ilce": "Şahinbey",
                },
                "hobiler": ["sinema","kitap"]
}; 
let kullanici2 = {"ad": "Arda",
                "soyad":"Mantar",
                "yas":9,
                "adres":{
                    "sehir": "gaziantep",
                    "ilce": "Şahinbey",
                },
                "hobiler": ["sinema","kitap"]
}; 
let kullanicilar = [kullanici,kullanici2]
let sonuc;

sonuc= kullanici;
sonuc=kullanici["ad"];
sonuc=kullanici["soyad"];
sonuc=kullanici["adres"];
sonuc=kullanici["adres"]["ilce"];
sonuc= kullanici.adres.sehir
sonuc=kullanici.hobiler[0];
sonuc = kullanicilar[1].yas


console.log(sonuc);