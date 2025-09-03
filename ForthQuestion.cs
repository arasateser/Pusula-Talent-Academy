using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PusulaTalent
{
    public class ForthQuestion
    {
        public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
        {
            //filteleme
            var filteredEmployees = employees.Where(e =>
            e.Age >= 25 &&
            e.Age <= 40 &&
            (e.Department == "IT" || e.Department == "Finance") &&
            e.HireDate > new DateTime(2017, 1, 1));

            //sıralama ve hesap
            int numberOfEMployees = filteredEmployees.Count();
            decimal totalSalary = 0;
            decimal averageSalary = 0;
            decimal minimumSalary = 0;
            decimal maximumSalary = 0;

            if (numberOfEMployees > 0)
            {
                totalSalary = filteredEmployees.Sum(e => e.Salary);
                averageSalary = filteredEmployees.Average(e => e.Salary);
                minimumSalary = filteredEmployees.Min(e => e.Salary);
                maximumSalary = filteredEmployees.Max(e => e.Salary);
            }

            var names = filteredEmployees.OrderByDescending(n => n.Name.Length).ThenBy(n => n.Name).Select(n => n.Name);
            //json döndür- İsimleri uzunluklarına göre azalan, ardından alfabetik olarak sıralayın

            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                averageSalary = averageSalary,
                MinSalary = minimumSalary,
                MaxSalary = maximumSalary,
                Count = numberOfEMployees
            };

            return JsonSerializer.Serialize(result);

        }
    }
}
