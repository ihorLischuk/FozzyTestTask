/* Построить три класса (базовый и 2 потомка), описывающих сотрудников с почасовой оплатой (один из потомков) и 
 * фиксированной оплатой (второй потомок). Описать в базовом классе абстрактный метод для расчета среднемесячной 
 * заработной платы. Для «повременщиков» формула для расчета такова: 
 * «среднемесячная заработная плата = 20.8 * 8 * почасовую ставку»,
 * для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированной месячной оплате».
a) Упорядочить всю последовательность работников по убыванию среднемесячного заработка. При совпадении 
    зарплаты – упорядочивать данные по алфавиту по имени. Вывести идентификатор работника, имя и 
    среднемесячный заработок для всех элементов списка.
b) Вывести первые 5 имен работников из полученного в пункте а) списка.
c) Вывести последние 3 идентификатора работников из полученного в пункте а) списка.
d) Организовать запись и чтение коллекции в/из файл.
e) Организовать обработку некорректного формата входного файла. */

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace task_1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);

            var employeeList = new List<Employee>() { 
                new FixedPaymentEmployee(1, "Name 1", "Last name 1", "Sur name 1", 15000f),
                new HourlyPaymentEmployee(2, "Name 2", "Last name 2", "Sur name 2", 85f),
                new FixedPaymentEmployee(3, "Name 3", "Last name 3", "Sur name 3", 16500f),
                new HourlyPaymentEmployee(4, "Name 4", "Last name 4", "Sur name 4", 110f),
                new HourlyPaymentEmployee(5, "Name 5", "Last name 5", "Sur name 5", 98f),
                new FixedPaymentEmployee(6, "Name 6", "Last name 6", "Sur name 6", 12000f),
                new HourlyPaymentEmployee(7, "Name 7", "Last name 7", "Sur name 7", 112f),
                new HourlyPaymentEmployee(8, "Name 8", "Last name 8", "Sur name 8", 68f),
                new HourlyPaymentEmployee(9, "Name 9", "Last name 9", "Sur name 9", 70f),
                new FixedPaymentEmployee(10, "Name 10", "Last name 10", "Sur name 10", 12300f),
                new HourlyPaymentEmployee(11, "Name 11", "Last name 11", "Sur name 11", 56f),
                new HourlyPaymentEmployee(12, "Name 12", "Last name 12", "Sur name 12", 96f),
                new HourlyPaymentEmployee(13, "Name 13", "Last name 13", "Sur name 13", 57f),
                new FixedPaymentEmployee(14, "Name 14", "Last name 14", "Sur name 14", 10000f),
                new HourlyPaymentEmployee(15, "Name 15", "Last name 15", "Sur name 15", 86f),
                new HourlyPaymentEmployee(16, "Name 16", "Last name 16", "Sur name 16", 72f),
                new FixedPaymentEmployee(17, "Name 17", "Last name 17", "Sur name 17", 19000f),
                new HourlyPaymentEmployee(18, "Name 18", "Last name 18", "Sur name 18", 60f),
                new HourlyPaymentEmployee(19, "Name 19", "Last name 19", "Sur name 19", 75f),
                new HourlyPaymentEmployee(20, "Name 20", "Last name 20", "Sur name 20", 64f),
                new FixedPaymentEmployee(21, "Name 21", "Last name 21", "Sur name 21", 13700f),
                new HourlyPaymentEmployee(22, "Name 22", "Last name 22", "Sur name 22", 82f),
                new FixedPaymentEmployee(23, "Name 23", "Last name 23", "Sur name 23", 26000f),
                new HourlyPaymentEmployee(24, "Name 24", "Last name 24", "Sur name 24", 60f),
                new HourlyPaymentEmployee(25, "Name 25", "Last name 25", "Sur name 25", 95f),
                new HourlyPaymentEmployee(26, "Name 26", "Last name 26", "Sur name 26", 142f),
                new HourlyPaymentEmployee(27, "Name 27", "Last name 27", "Sur name 27", 94f),
                new HourlyPaymentEmployee(28, "Name 28", "Last name 28", "Sur name 28", 63f),
            };

            Console.WriteLine("A:");
            var employeeListSorted =
                from employee in employeeList
                orderby
                    employee.CalculateAvgMonthSalary() descending,
                    employee.LastName,
                    employee.Name,
                    employee.SurName
                select employee;
            foreach (var e in employeeListSorted)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("B: ");
            foreach (var e in employeeListSorted.Take(5))
            {
                Console.WriteLine("\t{0}", e.Name);
            }

            Console.WriteLine("C: ");
            foreach (var e in employeeListSorted.Skip(employeeListSorted.Count() - 3))
            {
                Console.WriteLine("\t{0}", e.Id);
            }

            string path = "employees.collection";

            Console.WriteLine("D: ");
            SaveCollection(path, employeeList);

            Console.WriteLine("E:");

            try
            {
                var employeesFromFile = ReadCollection(path);
                foreach (var e in employeesFromFile)
                {
                    Console.WriteLine(e);
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("Некоректний вхідний файл");
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static List<Employee> ReadCollection(string path)
        {
            var serializer = new XmlSerializer(typeof(List<Employee>));
            using (var reader = new StreamReader(path))
            {
                return (List<Employee>)serializer.Deserialize(reader);
            }
        }

        public static void SaveCollection(string path, List<Employee> data)
        {
            var serializer = new XmlSerializer(typeof(List<Employee>));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, data);
            }
            Console.WriteLine("Колекцію збережено у файл {0}", path);
        }
    }
}
