function checkAnalysis() {
  let num = Number(document.getElementById("num").value);

  num_status = num >= 0 ? "Positive" : "Negative";
  console.log(num_status);

  if (num % 2 === 0) {
    console.log("even");
  } else {
    console.log("odd");
  }

  for (let i = 1; i <= num; i++) {
    console.log(i);
  }
}
