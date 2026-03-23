using System;

public class Employee
{
	private string _fullName;
	private decimal _salary;
	private int _age;
	private int _employeeId;

    private Random r = new Random();

    public string FullName
	{
		get { return _fullName; }
		set
		{
            if (string.IsNullOrEmpty(value))
			{
                throw new ArgumentException("Employee Name cannot be empty");
            }
			_fullName = value.Trim();
        }

	}

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 18 || value >80)
            {
                throw new ArgumentException("Employee age must between 18 and 80");
            }
            _age = value;
        }

    }

   public decimal Salary
    {
        get { return _salary; }
        private set
        {
            if(value < 1000)
            {
                throw new ArgumentException("Salary must be at least 1000");
            }
            _salary = value;
        }
    }
    public int EmployeeId
    {
        get { return _employeeId; }
    }
   
    public Employee(string fullName, decimal salary, int age, int employeeId=0 )
    {
        FullName = fullName;
        Salary = salary;
        Age = age;
        _employeeId = employeeId == 0 ? r.Next(1000,9999):employeeId;
    }

    public void GiveRaise(decimal percentage)
    {
        if(percentage <= 0 || percentage > 30)
        {
            throw new ArgumentException("Invalid Raise, Percentage must be > 0 and ≤ 30 ");
        }
        Salary = Salary * (1 + percentage / 100);
        Console.WriteLine($"Salary increased by {percentage}% => New Salary: {Salary}");

    }

    public bool DeductPenalty(decimal amount)
    {
        if(amount < 0 || _salary - amount < 1000)
        {
            return false;
        }
        Salary -= amount;
        return true;
    }

}
