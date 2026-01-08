using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates_Exercise1
{
    internal class GradingSystem
    {

        public void DisplayingGradingInfo(List<Students>Students,
            Func<List<int>,double>CalculateAverage,Predicate<double>CheckIfPassed
            ,Action<Students,double,bool>DisplayInfo)
        {
            foreach (var student in Students)
            {
               double Average= CalculateAverage(student.Grades);
                bool IsPassed = CheckIfPassed(Average);
                DisplayInfo(student, Average, IsPassed);
            }
        }
    }
}
