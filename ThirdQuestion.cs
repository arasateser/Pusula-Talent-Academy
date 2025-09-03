using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using System.Numerics;
using System.Net.Cache;

namespace PusulaTalent
{
    public class ThirdQuestion
    {
        public static string FilterPeopleFromXml(string xmlData)
        {
            //XML parse et
            XDocument document = XDocument.Parse(xmlData);

            var people = document.Descendants("Person")
                .Select(p => new
                {
                    Name = (string)p.Element("Name"),
                    Age = (int)p.Element("Age"),
                    Department = (string)p.Element("Department"),
                    Salary = (int)p.Element("Salary"),
                    HireDate = (DateTime)p.Element("HireDate")
                });

            //filtrele
            var filteredPersons = people.Where(p =>
            p.Age > 30 &&
            p.Department == "IT" &&
            p.Salary > 5000 &&
            p.HireDate.Year < 2019);

            //sırala
            double highestSalary = 0;
            double averageSalary = 0;
            double totalSalary = 0;
            var names = filteredPersons.OrderBy(p => p.Name).Select(p => p.Name);

            var count = filteredPersons.Count();

            if (count > 0)
            {
                highestSalary = filteredPersons.Max(p => p.Salary);
                averageSalary = filteredPersons.Average(p => p.Salary);
                totalSalary = filteredPersons.Sum(p => p.Salary);
            }

            //json olarak geri döndür
            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                AverageSalary = averageSalary,
                MaxSalary = highestSalary,
                Count = count

            };

            return JsonSerializer.Serialize(result);
        }
    }
}
