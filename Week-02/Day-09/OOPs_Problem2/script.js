class Vehicle{
  brand;
  speed;
  constructor(brand,speed){
    this.brand=brand;
    this.speed=speed;

  }
  displayInfo(){
    console.log(`Brand : ${this.brand}`);
    console.log(`Speed : ${this.speed}`)
  }
}

class Car extends Vehicle{
  fuelType;
  constructor(brand,speed,fuelType){
    super(brand,speed);
    this.fuelType=fuelType;
  }
  showCarDetails(){
   console.log(`Brand : ${this.brand}`);
   console.log(`Speed : ${this.speed}`);
   console.log(`Fuel Type : ${this.fuelType}`)
  }
}

c1= new Car("Benz",200,'Diesel')

// c1.displayInfo();
c1.showCarDetails();