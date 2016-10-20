using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Test
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputeHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(40);

            GradeStatistics stats = book.ComputeGradeStatistics();
            Assert.AreEqual(91, stats.HighestGrade);
        }

        [TestMethod]
        public void ComputeAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(81.15f);
            book.AddGrade(49);

            GradeStatistics stats = book.ComputeGradeStatistics();
            Assert.AreEqual(73.71, stats.AverageGrade, 0.01);
        }
    }
}
