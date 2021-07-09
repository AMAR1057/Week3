using System;
using System.Collections.Generic;
using System.IO;

namespace DriverLicence{
class Program{
    static void Main(string[] args){

        //Store answers in an array
        char[] answers = new char[]{'B','D','A','A','C','A','B','A','C','D','B','C','D','A','D','C','C','B','D','A'};
        //Required variables
        char[] studentAnswers = new char[20];
        List<int> incorrectQtsns = new List<int>();
        int correctAnswers = 0,wrongAnswers = 0;
        //Open file using StreamReader
         using (StreamReader reader = new StreamReader(@"C:\testResults.txt")){
            String line;
            int i = 0;
            //Loop through each line of file
            while((line = reader.ReadLine()) != null){
                //Convert line to char and store it in array
                studentAnswers[i] = Convert.ToChar(line);
                //Count correct and wrong answers
                //and store question number of wrong answers
                if (studentAnswers[i] == answers[i])
                    correctAnswers++;
                else{
                    wrongAnswers++;
                    incorrectQtsns.Add(i + 1);
                 }
                i++;                             
            }
        }
        //Display results
        if (correctAnswers >= 15){
            Console.WriteLine("Test Result: Pass \n");
        }
        else{
            Console.WriteLine("Test Result: Fail \n");
        }

        //Printing counts
        Console.WriteLine("\nTotal Number of correct answers: " + correctAnswers.ToString());
        Console.WriteLine("\nTotal Number of incorrect answers: " + wrongAnswers.ToString());
        Console.WriteLine("\n\nQuestion numbers of the incorrectly answered questions:\n");

        //Printing incorrect answers line numbers
        foreach (int qstNumber in incorrectQtsns){
            Console.Write(" " + qstNumber);
        }
        Console.ReadKey();
    }                 
}}