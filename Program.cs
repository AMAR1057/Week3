using System;
using System.IO;
using System.Collections.Generic;

using System.Text;

namespace DriverLicence
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array that holds the correct answers
            string[] correctAnswers = new string[] { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B", "C", "D", "A", "D", "C", "C", "B", "D", "A" };
            string[] userAnswers = new string[20];

            int i = 0;

            //File stream object
            FileStream fileStream = new FileStream(@"C:\testResults.txt", FileMode.Open, FileAccess.Read);

            //Reading data from file
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;

                //Itertate till all lines are processed
                while ((line = streamReader.ReadLine()) != null)
                {
                    //Storing user answer
                    userAnswers[i] = line;

                    //Incrementing index
                    i = i + 1;
                }
            }

            int correctAnswerCnt = 0, inCorrectAnswerCnt = 0;

            //List to hold incorrect answers
            List<int> incorrectAnswers = new List<int>();

            //Iterating over each answer
            for (i = 0; i < 20; i++)
            {
                //Comparing answers
                if (userAnswers[i].Equals(correctAnswers[i]))
                {
                    //Updating counters
                    correctAnswerCnt += 1;
                }
                else
                {
                    //Updating counters
                    inCorrectAnswerCnt += 1;

                    //Adding to list
                    incorrectAnswers.Add(i + 1);
                }
            }

            //Prnting results
            if (correctAnswerCnt >= 15)
            {
                Console.WriteLine("\n Test Result: Pass \n");
            }
            else
            {
                Console.WriteLine("\n Test Result: Fail \n");
            }

            //Printing counts
            Console.WriteLine("\n Total Number of correct answers: " + correctAnswerCnt.ToString());
            Console.WriteLine("\n Total Number of incorrect answers: " + inCorrectAnswerCnt.ToString());

            Console.WriteLine("\n\n Question numbers of the incorrectly answered questions: \n");

            //Printing incorrect answers line numbers
            for (i = 0; i < incorrectAnswers.Count; i++)
            {
                Console.Write(" " + incorrectAnswers[i]);
            }

            Console.ReadKey();
        }
    }
}