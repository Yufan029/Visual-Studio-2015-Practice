using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer speech = new SpeechSynthesizer();
            //speech.Speak("hello, world");

            GradeBook book = new GradeBook();

            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;

            book.Name = "Allen's book";
            
            book.Name = "abc";
            Console.WriteLine($"The name of the book is {(book.Name)}");

            book.AddGrade(91);
            book.AddGrade(81.15f);
            book.AddGrade(49);

            GradeStatistics stats = book.ComputeGradeStatistics();
            Console.WriteLine($"the Average is {stats.AverageGrade}");
            Console.WriteLine($"the Maximum is {stats.HighestGrade}");
            Console.WriteLine($"the Minumum is {stats.LowestGrade}");
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"name changed from \"{args.ExistingName}\" to \"{args.NewName}\"");
        }

        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("--------------------------------------");
        }
    }
}
