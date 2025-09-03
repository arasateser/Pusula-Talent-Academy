using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PusulaTalent
{
    public class SecondQuestion
    {
        public static string LongestVowelSubsequenceAsJson(List<string> words)
        {
            if (words == null || words.Count == 0)
            {
                return JsonSerializer.Serialize(new List<string>());
            }
            //sesli harf dizisi
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };

            List<string> currentSubWord = new List<string>(); //stringbuilder da olabilir çalışmazsa değiştir
            List<string> maxSubWord = new List<string>();

            var result = new List<object>();

            //döngü içerisinde gönderilen kelimelere bakılıp foreach içerisinde
            //karakter karakter gezilecek
            for (int i = 0; i < words.Count; i++)
            {
                maxSubWord.Clear();
                foreach (char c in words[i].ToLower()) //sesli harf dizisinde sadece küçük harf olduğu için burada gelen tüm kelimeleri küçük harfe dönüştürüyorum
                {

                    if (vowels.Contains(c))
                    {
                        //gönderilen kelimenin harfi sesli harf dizisindeki harflerden biriyse
                        //bir diziye aktarılacak
                        currentSubWord.Add(c.ToString()); //add yerine baska bir metot kullanmak gerekebilir
                    }
                    else
                    {
                        if (currentSubWord.Count > maxSubWord.Count)
                        {
                            maxSubWord = new List<string>(currentSubWord);
                        }
                        currentSubWord.Clear();
                    }
                }

                if (currentSubWord.Count > maxSubWord.Count)
                {
                    maxSubWord = new List<string>(currentSubWord);
                }
                currentSubWord.Clear();

                result.Add(new
                {
                    word = words[i],
                    sequence = string.Join("", maxSubWord),
                    length = maxSubWord.Count
                });
            }

            return JsonSerializer.Serialize(result);
        }
    }
}
