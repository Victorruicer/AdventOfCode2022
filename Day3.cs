using System.Text.RegularExpressions;

namespace progTest.adv2024.Day3
{
    public class Day3
    {
        public void day3()
        {
            try
            {
                int totalMultiplications = 0;

                //Absolute route to the file
                string filePath = "C:\\Users\\victor.ruiz\\Downloads\\progTest\\progTest\\adv2024\\Day3\\input.txt";
                string corruptedMemory = File.ReadAllText(filePath);

                string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
                MatchCollection mulMatches = Regex.Matches(corruptedMemory, pattern);

                foreach (Match mul in mulMatches)
                {
                    int number1 = int.Parse(mul.Groups[1].Value);
                    int number2 = int.Parse(mul.Groups[2].Value);

                    int mulResult = number1 * number2;

                    totalMultiplications += mulResult;
                }

                Console.WriteLine("Total multiplications: " + totalMultiplications);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado en el código: '" + ex.Message + "'");
            }
        }
    }
}
