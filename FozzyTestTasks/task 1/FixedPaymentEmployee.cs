namespace task_1
{
    public class FixedPaymentEmployee : Employee
    {
        public float Salary { get; set; }

        public FixedPaymentEmployee() { }

        public FixedPaymentEmployee(int id, string name, string lastName, string surName, float salary) :
            base(id, name, lastName, surName)
        {
            Salary = salary;
        }

        public override float CalculateAvgMonthSalary()
        {
            return Salary;
        }

        public override string ToString()
        {
            return string.Format("FixedPaymentEmployee\r\n" +
                "\t[Id]: {0}\r\n" +
                "\t[LastName]: {1}\r\n" +
                "\t[Name]: {2}\r\n" +
                "\t[SurName]: {3}\r\n" +
                "\t[Salary]: {4}\r\n", 
                Id, 
                LastName, 
                Name,
                SurName,
                Salary
            );
        }
    }
}
