

namespace Delegates_Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students>students = new List<Students>();
            while (true)
            {
                Console.WriteLine("Welcome to grading system ");
                Console.WriteLine("Please enter you name , if you want to exit please enter 'done'");
                string StudentName = Console.ReadLine();
                if (StudentName=="done")
                {
                    break;
                }
                List<int>StudentGrades= new List<int>();
                Console.WriteLine("Please enter you grades : (5 Subject )");
                for (int i = 0; i < 5; i++)
                {
                    int GradeValue = int.Parse(Console.ReadLine());
                    StudentGrades.Add(GradeValue);
                    
                }

                Students student = new Students();
                student.Name = StudentName;
                student.Grades = StudentGrades;
                students.Add(student);
                Console.WriteLine($"Student Added successfully with name {StudentName} & Grade count = {student.Grades.Count}");
            }

            GradingSystem gradingSystem = new GradingSystem();
            //gradingSystem.DisplayingGradingInfo(students, CalculateAverage,CheckIfPassed,DisplayInfo);
            gradingSystem.DisplayingGradingInfo(students, CalculateAverage,
                (double X)=> X>=20, //Using lambda 
                DisplayInfo);

        }

        private static void DisplayInfo(Students students, double Average, bool IsPassed)
        {
            string Status = "Passed";
            if (!IsPassed)
            {
                Status = "Failed";
            }
            Console.WriteLine($"Student name is {students.Name} ," +
                $" the average is {Average} & is status is {Status}");

        }

        private static bool CheckIfPassed(double Average)
        {
            return Average >= 30;
        }

        private static double CalculateAverage(List<int> Grades)
        {
            return Grades.Sum() / Grades.Count;
        }
    }
}
