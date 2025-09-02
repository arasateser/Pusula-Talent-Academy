using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PusulaTalent
{
    public class MaxIncreasingSubArrayAsJson
    {
        public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
        {
            //liste boş mu
            if (numbers == null || numbers.Count == 0)
            {
                return JsonSerializer.Serialize(new List<int>());
            }
            //liste tek elemanlı mı
            else if (numbers.Count == 1)
            {
                return JsonSerializer.Serialize(numbers);
            }

            //artan dizinin nasıl bulacağımızın hesabı
            //toplamların karşılaştırılması

            List<int> maxArray = new List<int>();
            List<int> currentArray = new List<int>();

            currentArray.Add(numbers[0]);

            for (int i = 1; i < numbers.Count(); i++)
            {
                if (numbers[i - 1] < numbers[i])
                {
                    currentArray.Add(numbers[i]);
                }
                else
                {
                    if (currentArray.Sum() > maxArray.Sum())
                    {
                        maxArray = new List<int>(currentArray);
                    }
                    currentArray.Clear();
                    currentArray.Add(numbers[i]);
                }
            }

            if (currentArray.Sum() > maxArray.Sum())
            {
                maxArray = new List<int>(currentArray);
            }



            return JsonSerializer.Serialize(maxArray);
        }
    }
}
