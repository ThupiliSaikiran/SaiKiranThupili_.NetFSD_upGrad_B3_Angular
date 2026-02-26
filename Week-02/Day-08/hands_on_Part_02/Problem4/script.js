let products = [
  "Wireless Mouse",
  "Bluetooth Headphones",
  "Gaming Keyboard",
  "USB-C Charger",
  "Smartphone Stand",
  "Laptop Backpack",
  "LED Desk Lamp",
  "Portable Power Bank",
  "Smart Watch",
  "Water Bottle",
  "Office Chair",
  "Mechanical Pencil",
  "External Hard Drive",
  "HD Webcam",
  "Noise Cancelling Earbuds",
  "Tablet Cover",
  "Fitness Band",
  "Digital Alarm Clock",
  "Coffee Mug",
  "Wireless Speaker"
];

let prodCon = document.getElementById("prod-con");
let btn = document.getElementById('btn');

function showProducts(products){
  prodCon.innerHTML=""
  products.forEach(product =>{
    prodCon.innerHTML+=`
    <div class="prod-card">
      <h3>${product}</h3>
    </div>
    `
  })
}



btn.addEventListener('click',()=>{
  let input = document.getElementById('search-prod').value.trim().toLowerCase()

  if(!input){
    showProducts(products);
    return;

  }

  let prod_list = products.filter(product=>{

    return product.toLowerCase().includes(input)
  })

  console.log("Hi")

  showProducts(prod_list)

  document.getElementById('search-prod').value=""
 
 
})

showProducts(products)
