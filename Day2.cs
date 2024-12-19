namespace progTest.adv2024.Day2
{
    public class Day2
    {
        public void day2()
        {
            try
            {
                int safeReportsWithoutProblemDampener = 0;
                int safeReportsWithProblemDampener = 0;

                //Absolute route to the file
                string filePath = "C:\\Users\\victor.ruiz\\Downloads\\progTest\\progTest\\adv2024\\Day2\\input.txt";

                foreach (var reportString in File.ReadLines(filePath))
                {
                    //Divide the line in two by the blank space
                    int[] levelsArray = reportString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    if (CheckReportWithoutProblemDampener(levelsArray)) safeReportsWithoutProblemDampener++;
                    if (CheckReportWithProblemDampener(levelsArray)) safeReportsWithProblemDampener++;
                }

                Console.WriteLine("Number of safe reports without the 'Problem Dampener': " + safeReportsWithoutProblemDampener);
                Console.WriteLine("Number of safe reports with the 'Problem Dampener': " + safeReportsWithProblemDampener);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado en el código: '" + ex.Message + "'");
            }
        }

        private bool CheckReportWithoutProblemDampener(int[] levelsArray)
        {
            //Check if it's ascending or descending
            if (levelsArray[0] > levelsArray[1]) //Descending
            {
                for (int i = 0; i < levelsArray.Length - 1; i++)
                {
                    if (!(levelsArray[i] > levelsArray[i + 1])) return false;
                    if ( Math.Abs(levelsArray[i] - levelsArray[i + 1]) > 3 ) return false;
                }

            }
            else //Ascending
            { 
                for (int i = 0; i < levelsArray.Length - 1; i++)
                {
                    if (!(levelsArray[i] < levelsArray[i + 1])) return false;
                    if (Math.Abs(levelsArray[i] - levelsArray[i + 1]) > 3) return false;
                }
            }

            return true;
        }

        private bool CheckReportWithProblemDampener(int[] levelsArray)
        {
            bool levelRemoved = false;
            bool isAscending = false;
            bool isDescending = false;

            //Check if it's ascending or descending
            //15 12 17 10 9 4 2
            //15 12 10 20 9 4 2

            if (isDescending) //Descending
            {
                for (int i = 0; i < levelsArray.Length - 1; i++)
                {

                    if (!(levelsArray[i] > levelsArray[i + 1]))
                    {
                        if (!levelRemoved)
                        {
                            levelRemoved = true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (Math.Abs(levelsArray[i] - levelsArray[i + 1]) > 3) return false;
                }

            }

            if(isAscending) //Ascending
            {
                for (int i = 0; i < levelsArray.Length - 1; i++)
                {
                    if (!(levelsArray[i] < levelsArray[i + 1]))
                    {
                        if (!levelRemoved)
                        {
                            levelRemoved = true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (Math.Abs(levelsArray[i] - levelsArray[i + 1]) > 3) return false;
                }
            }

            return true;
        }
    }
}
