class Student{
  name;
  rollNumber;
  marks;

  constructor(name,rollNumber,marks){
    this.name=name;
    this.rollNumber=rollNumber;
    this.marks=marks;

  }

  getDetails(){
    console.log(`Name : ${this.name}`)
    console.log(`Roll No. : ${this.rollNumber}`)
    console.log(`Marks : ${this.marks}`)
  }
  getGrade(){
    let grade;
    switch(true){
      case this.marks >= 90:
        grade="A"
        break;
      
      case this.marks >= 75 && this.marks <= 89:
        grade="B";
        break;

      case this.marks >= 50 && this.marks <= 74:
        grade="B";
        break;
      
      case this.marks <50:
        grade='Fail';
        break;

      default:
        grade='Not Applicable'
    }
    console.log(`Grade is ${grade}`)



  }
}

obj1=new Student('sai',12,30);
obj1.getDetails()
obj1.getGrade()

