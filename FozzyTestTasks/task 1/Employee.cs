using System.Xml.Serialization;

namespace task_1
{
    [XmlInclude(typeof(HourlyPaymentEmployee))]
    [XmlInclude(typeof(FixedPaymentEmployee))]
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }

        public Employee() { }

        public Employee (int id, string name, string lastNmae, string surName)
        {
            Id = id;
            Name = name;
            LastName = lastNmae;
            SurName = surName;
        }

        public abstract float CalculateAvgMonthSalary();
        public abstract override string ToString();
    }
}
