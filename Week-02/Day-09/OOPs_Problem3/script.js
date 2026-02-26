let res = document.getElementById("res");
let creditBtn = document.getElementById("credit");
let upiBtn = document.getElementById("upi");
let cashBtn = document.getElementById("cash");

class Payment{
  pay(){
    return "Processing payment"
  }
}
class CreditCardPayment extends Payment{
  pay(){
    return "Paid ₹500 using Credit Card"
  }
}
class UPIPayment extends Payment{
  pay(){
    return "Paid ₹500 using UPI"
  }
}
class CashPayment extends Payment{
  pay(){
    return "Paid ₹500 By Cash"
  }
}

pay =  new Payment()
creditCard = new CreditCardPayment();
upi = new UPIPayment();
cash = new CashPayment();





creditBtn.addEventListener('click',()=>{
  console.log("Hi")
  let load = pay.pay()
  console.log(load)
  res.innerText=load;

  setTimeout(()=>{
    
    let message = creditCard.pay();
    res.innerText=message;
    

  },2000)

})


upiBtn.addEventListener('click',()=>{
  console.log("Hi")
  let load = pay.pay()
  console.log(load)
  res.innerText=load;

  setTimeout(()=>{
    
    let message = upi.pay();
    res.innerText=message;
    

  },2000)

})

cashBtn.addEventListener('click',()=>{
  console.log("Hi")
  let load = pay.pay()
  console.log(load)
  res.innerText=load;

  setTimeout(()=>{
    
    let message = cash.pay();
    res.innerText=message;
    

  },2000)

})