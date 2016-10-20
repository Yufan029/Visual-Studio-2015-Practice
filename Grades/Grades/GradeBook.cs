using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook()
        {
            name = "Original";
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeGradeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (var grade in grades)
            {
                sum += grade;
                stats.HighestGrade = Math.Max(stats.HighestGrade, grade);
                stats.LowestGrade = Math.Min(stats.LowestGrade, grade);
            }

            stats.AverageGrade = sum/grades.Count;
            
            return stats;
        }

        private String name;

        private List<float> grades;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = name;
                        args.NewName = value;

                        NameChanged?.Invoke(this, args);
                    }
                    name = value;
                }
                else
                {
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.Speak("You cannot use a null string for book's name!");
                }
            }
        }

        public event NameChangedDelegate NameChanged;
    }
}
