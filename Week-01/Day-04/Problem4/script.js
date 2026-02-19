function checkAction(color) {
  let res = document.getElementById("res");
  let res_instruct;
  let res_color;
  switch (color) {
    case "red":
      res_instruct = "Stop!";
      res_color = "red";
      
      break;
    case "yellow":
      res_instruct = "Get Ready!";
      res_color = "yellow";
      break;
    case "green":
      res_instruct = "Go!";
      res_color = "green";
      break;
    default:
      res_instruct = "Invalid";
      res_color = "white";
  }
  console.log(res_instruct);
  console.log(res_color)
  res.innerText = res_instruct;
  res.style.color = res_color;
}
