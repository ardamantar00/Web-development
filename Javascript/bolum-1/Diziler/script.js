//Diziler
let urunler = ["Iphone-14","Iphone-15","Iphone-16"];
let fiyatlar = [40000,50000,60000];
let renkler = ["Rose","Black","Gold","Silver"]
let sonuc;

sonuc = `${urunler[1]}-${fiyatlar[1]}-${renkler[1]}`;
sonuc = `${urunler[0]}-${fiyatlar[0]}-${renkler[0]}`;
sonuc = `${urunler[2]}-${fiyatlar[2]}-${renkler[3]}`;

let urun1 = ["Iphone 15",
    50000,
    "Gold"
];

let urun2 = ["Iphone 16",
    60000,
    ["Rose","Black","Gold","Silver"]
]
sonuc = `${urun2[0]}- ${urun2[1]}-${urun2[2][1]}`;

//Güncelleme 
urun2[0] = "Iphone 15 Pro";
sonuc = `${urun2[0]}- ${urun2[1]}-${urun2[2][1]}`;

console.log(sonuc)