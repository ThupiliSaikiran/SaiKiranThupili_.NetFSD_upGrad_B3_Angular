import cartEvaluation from "./cart.js"

const cart =[
  { name: "Shirt", price: 800, quantity: 2 },
  { name: "Shoes", price: 1500, quantity: 1 },
  { name: "Cap", price: 300, quantity: 3 }
]

let prdList = document.getElementById("prod-lst");
cart.forEach(prod =>{
  let li = document.createElement("li")
  li.innerText=`${prod.name} - ${prod.price} - ${prod.quantity}`

  prdList.appendChild(li);
})

const {itemsTotals,overallTotal}=cartEvaluation(cart);

let res_list = document.getElementById("res-list");

itemsTotals.forEach(prod =>{
  let li= document.createElement("li");
  li.innerText=`${prod.name} - ${prod.total}`
  res_list.appendChild(li);
})

document.getElementById("final-amount").innerText=`Total Cart Value: ${overallTotal}`

