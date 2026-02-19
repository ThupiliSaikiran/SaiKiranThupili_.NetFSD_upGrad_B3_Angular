function gradeEvaluator() {
  const name = document.getElementById("name").value;
  const marks = Number(document.getElementById("marks").value);

  const res = document.getElementById("res");

  res.style.display="block";

   if (marks >= 75) {
    res.innerText = `${name}, You got A Grade`;
    res.style.color='green'
    
  }
  else if (marks >= 60) {
    res.innerText = `${name}, You got B Grade`;
  }
  else if (marks >= 40) {
    res.innerText = `${name}, You got B Grade`;
    res.style.display=block;
  }
  else {
    res.innerText = `${name}, Fail`;
    res.style.color="tomato"
  }
}
