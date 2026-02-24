const employees = [
  {
    empId: 101,
    name: "Ravi Kumar",
    job: "manager",
    salary: 75000,
    department: "HR",
  },
  {
    empId: 102,
    name: "Sneha Reddy",
    job: "salesman",
    salary: 35000,
    department: "Sales",
  },
  {
    empId: 103,
    name: "Arjun Mehta",
    job: "clerk",
    salary: 25000,
    department: "Accounts",
  },
  {
    empId: 104,
    name: "Priya Sharma",
    job: "manager",
    salary: 82000,
    department: "IT",
  },
  {
    empId: 105,
    name: "Kiran Rao",
    job: "salesman",
    salary: 40000,
    department: "Sales",
  },
  {
    empId: 106,
    name: "Anjali Verma",
    job: "developer",
    salary: 60000,
    department: "IT",
  },
  {
    empId: 107,
    name: "Rahul Singh",
    job: "clerk",
    salary: 27000,
    department: "Admin",
  },
];

let showEmps = () => {
  const empType = document.getElementById("emp-type").value;

  const tbody = document.getElementById("tbody");

  let res;

  switch (empType) {
    case "all":
      res = employees;
      break;
    case "manager":
      res = employees.filter((emp) => emp.job == "manager");
      break;
    case "clerk":
      res = employees.filter((emp) => emp.job == "clerk");
      break;
    case "salesman":
      res = employees.filter((emp) => emp.job == "salesman");
      break;
    case "developer":
      res = employees.filter((emp) => emp.job == "developer");
      break;
    default:
      res = employees;
  }

  tbody.innerHTML = "";

  res.forEach((emp) => {
    let tr = document.createElement("tr");
    tr.innerHTML = `
    <td>${emp.empId}</td>
    <td>${emp.name}</td>
    <td>${emp.job}</td>
    <td>${emp.salary}</td>
    <td>${emp.department}</td>
    `;
    tbody.appendChild(tr);
  });
};
