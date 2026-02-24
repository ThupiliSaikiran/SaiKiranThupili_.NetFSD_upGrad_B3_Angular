const marks = [85, 70, 90, 60, 40];

console.log(`Mark List: ${marks}`);

let subs = document.getElementById("subjects");

marks.forEach((mark) => {
  let li = document.createElement("li");
  li.innerText = `Sub Mark :${mark}`;
  subs.appendChild(li);
});

const calculateTotal = (marks) => marks.reduce((acc, cur) => acc + cur, 0);

const calculateAverage = (marks) => calculateTotal(marks) / marks.length;

const checkResult = (marks) =>
  calculateAverage(marks) >= 50 ? "You Passed" : "You Failed";

let getTotal = () => {
  const total = document.getElementById("total");
  total.innerText = `Total Marks : ${calculateTotal(marks)}`;
};
let getAverage = () => {
  const avg = document.getElementById("avg");
  avg.innerText = `Average Marks : ${calculateAverage(marks)}`;
};

let getResult = () => {
  const res = document.getElementById("res");
  res.innerText = `Result : ${checkResult(marks)}`;
};
