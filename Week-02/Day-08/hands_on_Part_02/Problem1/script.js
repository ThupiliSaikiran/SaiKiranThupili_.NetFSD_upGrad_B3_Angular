
let feedbacks = JSON.parse(localStorage.getItem('feedbacks')) || [];

// console.log(typeof feedbacks)

let res = document.getElementById("res");
let inputFeedback = document.getElementById("input-feedback");
let btn = document.getElementById("submit");

function showFeedbacks(){
  res.innerHTML=""

  feedbacks.forEach(feedback =>{
    let li = document.createElement('li');
    li.innerText=feedback;

    res.appendChild(li)

  })
}

btn.addEventListener('click',()=>{
  
  let inputFeed = inputFeedback.value.trim();
  
  if(!inputFeed){
    alert("Enter feedback");
    return;
  }
  
  feedbacks.unshift(inputFeed);
  showFeedbacks();
 
  localStorage.setItem('feedbacks',JSON.stringify(feedbacks))
  inputFeedback.value = "";
})

showFeedbacks()