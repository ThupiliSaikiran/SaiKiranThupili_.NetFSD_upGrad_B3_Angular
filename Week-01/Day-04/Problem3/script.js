
function checkFinalAmount(){
  const total_amount=Number(document.getElementById("total").value);

  let final_amount;
  let disc_amount;

 

  if (total_amount >= 5000){
    disc_amount=total_amount*(20/100)
    final_amount=total_amount-disc_amount
  }
  else if(total_amount >= 3000){
    disc_amount=total_amount*(10/100)
    final_amount=total_amount-disc_amount
  }
  else{
    disc_amount=0;
    final_amount=total_amount;
  }

  document.getElementById("discount_amount").innerHTML=`Discount : Rs.${disc_amount.toFixed(2)}`
  document.getElementById("final_amount").innerHTML=`Final Amount : Rs.${final_amount.toFixed(2)}`



}