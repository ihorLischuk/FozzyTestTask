namespace task_1
{
    public class HourlyPaymentEmployee : Employee
    {
        public float HourlyRate { get; set; }

        public HourlyPaymentEmployee() { }

        public HourlyPaymentEmployee(int id, string name, string lastName, string surName, float hourlyRate) : 
            base(id, name, lastName, surName)
        {
            HourlyRate = hourlyRate;
        }

        public override float CalculateAvgMonthSalary()
        {
            return 20.8f * 8f * HourlyRate;
        }

        public override string ToString()
        {
            return string.Format("HourlyPaymentEmployee:\r\n" +
                "\t[Id]: {0};\r\n" + 
                "\t[LastName]: {1}\r\n" +
                "\t[Name]: {2}\r\n" +
                "\t[SurName]: {3}\r\n" +
                "\t[HourlyRate]: {4}\r\n" +
                "\t[Salary]: {5}\r\n",
                Id,
                LastName,
                Name,
                SurName,
                HourlyRate,
                CalculateAvgMonthSalary()
            );
        }
    }
}
