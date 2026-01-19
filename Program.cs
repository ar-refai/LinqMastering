using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using LinqMastering;
namespace LinqMastering;

class Program
{
    static void Main(string[] args)
    {
        #region Conceptual#0Linq (Reading Employee Data from employees.txt)
        // Reading employee data from a text file and mapping to Employee objects
        var lines = System.IO.File.ReadAllLines("employees.txt");
        List<Employee> employees = lines
                            .Skip(1)
                            .Select(line => line.Split(','))    // now it is an array of arrays of strings
                            .Select(parts => new Employee
                            {
                                Id = int.Parse(parts[0]),
                                FirstName = parts[1],
                                LastName = parts[2],
                                Salary = decimal.Parse(parts[3]),
                                DateOfBirth = DateTime.Parse(parts[4]),
                                DateOfEmployment = DateTime.Parse(parts[5]),
                                Department = parts[6],
                                IsEmployed = bool.Parse(parts[7]),
                                Points = int.Parse(parts[8]),
                                PerformanceScore = int.Parse(parts[9]),
                                ProjectCount = int.Parse(parts[10])
                            }).ToList();
        #endregion

        #region Conceptual#1Linq (Deferred vs Immediate Execution) i
        // // deferred execution example i 
        // List<int> dataList = [10, 20, 30, 40, 50];

        // var defferedQuery = dataList.Where(x => x > 25);

        // dataList.Add(60);
        // dataList.Add(70);

        // foreach(var item in defferedQuery)
        // {
        //     System.Console.WriteLine(item + " ");
        // }

        #endregion

        #region Conceptual#2Linq (Deferred vs Immediate Execution) ii 
        // var dataList = new List<int> {10,20,30,40,50};
        // var query = dataList.Where(x =>
        // {
        //     System.Console.WriteLine("Evaluating: " + x);
        //     return x > 25;
        // });

        // System.Console.WriteLine("Query defined, but not executed yet.");
        // System.Console.WriteLine("****************************************");
        // dataList.Add(60);
        // dataList.Add(70);
        // System.Console.WriteLine("Executing the query now:");
        // System.Console.WriteLine("****************************************");

        // foreach (var item in query)
        // {
        //     System.Console.WriteLine("Result: " + item);
        // }





        #endregion

        #region Conceptual#3Linq (Deferred vs Immediate Execution) iii

        // var dataList = new List<int> { 10, 20, 30, 40, 50 };

        // var query = dataList.Where(x=> x > 25);

        // dataList.Add(60);
        // foreach(var item in query.ToList()) // ToList() forces immediate execution
        //     System.Console.Write(item + " ");
        // System.Console.WriteLine("\n");

        // dataList.Add(70); // This won't affect the output of the above query
        // foreach(var item in query) // This will reflect the latest dataList
        //     System.Console.Write(item + " ");
        // System.Console.WriteLine("\n");

        #endregion

        #region Conceptual#4Linq (Deferred vs Immediate Execution) iv
        // // compared side by side (deferred vs immediate)
        // var dataList = new List<int>() { 10, 20, 30, 40, 50 };

        // var deferredQuery = dataList.Where(x => x > 25); // Deferred execution
        // var immediateQuery = dataList.Where(x => x > 25).ToList(); // Immediate execution

        // dataList.Add(60);
        // dataList.Add(70);

        // System.Console.WriteLine("Deferred Execution Results:"); // live data reflecting changes
        // foreach (var item in deferredQuery)
        //     System.Console.Write(item + " ");
        // System.Console.WriteLine("\n");

        // System.Console.WriteLine("Immediate Execution Results:"); // snapshot of data at the time of ToList() call
        // foreach (var item in immediateQuery)
        //     System.Console.Write(item + " ");
        // System.Console.WriteLine("\n");

        #endregion

        #region Conceptual#5Linq (Select vs SelectMany) i
        // var dataList = new List<int>() { 1,2,3,4,5,6,7,8,9,10};

        // var resultSelect = dataList.Select(x => x * 2);
        // // var resultSelectMany = dataList.SelectMany(x=> x * 2); // This will cause a compile-time error because SelectMany expects a collection to flatten.
        // var resultSelectMany = dataList.SelectMany(x => new List<int> { x * 2 }); // Correct usage of SelectMany

        // System.Console.WriteLine("Select Results:");
        // foreach(var item in resultSelect)
        //     System.Console.Write(item + " ");
        // System.Console.WriteLine("\n");

        // System.Console.WriteLine("SelectMany Results:");
        // foreach(var item in resultSelectMany)
        //     System.Console.Write(item + " ");
        // System.Console.WriteLine("\n");

        #endregion

        #region Conceptual#6Linq (Select vs SelectMany) ii
        // var dataList = new List<string> { "apple", "banana", "cherry" };

        // var resultSelect= dataList.Select(fr => fr.ToCharArray()).ToList();
        // var resultSelectMany = dataList.SelectMany(fr => fr.ToCharArray()).ToList();

        // System.Console.WriteLine("Select Results:");
        // foreach(var charArray in resultSelect)
        // {
        //     System.Console.WriteLine(string.Join(", ", charArray));
        // }
        // System.Console.WriteLine("\n");
        // System.Console.WriteLine("SelectMany Results:");
        // foreach(var ch in resultSelectMany)
        // {
        //     System.Console.Write(ch + " ");
        // }

        #endregion

        #region Conceptual#7Linq (Select vs SelectMany) iii
        // var dataList = new List<string> {"Hello" , "World"};
        // var resultSelectMany = dataList.SelectMany(x => x.ToCharArray()).ToList();

        // System.Console.WriteLine("SelectMany Results:");
        // foreach(var ch in resultSelectMany)
        //     System.Console.Write(ch + " ");
        // System.Console.WriteLine("\n");

        // var resultSelect = dataList.Select(X => X.ToCharArray()).ToList();

        // System.Console.WriteLine("Select Results:");
        // foreach(var arr in resultSelect)
        // {
        //     foreach(var ch in arr)
        //     {
        //         System.Console.Write(ch + " ");
        //     }
        //     System.Console.WriteLine();
        // }

        #endregion

        #region Conceptual#8Linq_exercise_i (All currently employed employees)
        // var allCurrentEmployees = employees.Where(em => em.IsEmployed == true).ToList();
        // foreach(var em in allCurrentEmployees)
        //     System.Console.WriteLine($"ID: ({em.Id}) Employee name: {em.FirstName} {em.LastName} -> isEmployed: {em.IsEmployed}"); 
        #endregion

        #region Conceptual#9Linq_exercise_ii (employees with salary > 10_000)
        // var withSalaryAbove10_000 = employees.Where(em => em.Salary > 10_000).OrderByDescending(em => em.Salary);
        // foreach(var em in withSalaryAbove10_000)
        //     System.Console.WriteLine($"ID: ({em.Id}) Employee name: {em.FirstName} {em.LastName} -> Salary: {em.Salary}"); 
        #endregion

        #region Conceptual#10Linq_exercise_iii (Employees in "IT" department)
        // var itDeptEmployees = employees.Where(em=>em.Department =="IT").ToList();
        // foreach(var em in itDeptEmployees)
        //     System.Console.WriteLine($"ID: ({em.Id}) Employee name: {em.FirstName} {em.LastName} -> Department: {em.Department}");
        #endregion

        #region Conceptual#11Linq_exercise_iv (Emplyees born after 1990)
        // var bornAfter1990 = employees.Where(em => em.DateOfBirth.Year > 1990).OrderByDescending(em => em.DateOfBirth.Year).ToList();
        // foreach(var em in bornAfter1990)
        //     System.Console.WriteLine($"ID: ({em.Id}) Employee name: {em.FirstName} {em.LastName} -> DOB: {em.DateOfBirth.Year}");
        #endregion

        #region Conceptual#12Linq_exercise_v (First and last names only)
        // var names = employees.Select(em => em.FirstName + " " + em.LastName).OrderBy(em => em).ToList();
        // foreach (var name in names)
        //     System.Console.WriteLine(name);
        #endregion

        #region Conceptual#13Linq_exercise_vi (Anonymous projection: Name + Salary)
        // var namePlusSalary = employees.OrderBy(em => em.FirstName).ThenBy(em => em.LastName).Select(em => em.FirstName + " " + em.LastName + " " + em.Salary.ToString()).ToList();
        // foreach(var item in namePlusSalary) 
        //     System.Console.WriteLine($"{item}");
        #endregion

        #region Conceptual#14Linq_exercise_vii (Employees with more than 3 projects)
        // var with3ProjectsEmployees = employees.OrderByDescending(em => em.ProjectCount).Where(em => em.ProjectCount > 3).ToList();
        // foreach(var em in with3ProjectsEmployees)
        //     System.Console.WriteLine($"ID: ({em.Id}), Name: {em.FirstName} {em.LastName}, Project Count: {em.ProjectCount}");
        #endregion
    
        #region Conceptual#15Linq_exercise_viii (Employees with performance score ≥ 8)
        // var withScoreLessThanOrEqual8 = employees.OrderByDescending(em => em.PerformanceScore).Where(em => em.PerformanceScore >= 8).ToList();
        // foreach(var em in withScoreLessThanOrEqual8)
        //     System.Console.WriteLine($"ID: ({em.Id}), Name: {em.FirstName} {em.LastName}, Performance Score: {em.PerformanceScore}");
        #endregion

        #region Conceptual#16Linq_exercise_ix (Employees whose last name starts with "A")
        // var withLastNameA_ = employees.Where(em => em.LastName.ToLowerInvariant().StartsWith('a')).ToList();
        // foreach(var em in withLastNameA_) 
        //     System.Console.WriteLine($"ID: ({em.Id}), Last Name: {em.LastName}");
        #endregion

        #region Conceptual#17Linq_exercise_x (count of employees per department)
        // var countPerDept = employees.GroupBy(em=>em.Department).OrderByDescending(em => em.Count()).Select(e => e.Key + " department has " + e.Count().ToString());
        
        // foreach(var item in countPerDept)
        //     System.Console.WriteLine(item);
        #endregion

        #region Conceptual#18Linq_train S1-A (Get active employees in IT, project only)
        // var activeITEmployees = employees.Where(em => em.Department == "IT" && em.IsEmployed == true) .Select(em => new
        // {
        //     FullName = em.FirstName + " " + em.LastName,
        //     em.Salary
        // }); // deferred
        // foreach(var em in activeITEmployees)
        //     System.Console.WriteLine($"Employee Name: {em.FullName} -> Salary: {em.Salary}");
        
        #endregion

        #region Conceptual#19Linq_train S1-B (Count employees with salary > 10,000 Then print them)
        // var withMore10000Salary = employees.Where(em => em.Salary >10000);  // deferred
        // foreach(var e in withMore10000Salary)
        // {
        //     System.Console.WriteLine($"Employee Name: {e.FirstName} {e.LastName} -> Salary: {e.Salary}");
        // }
        #endregion

        #region Conceptual#20Linq_train S1-C (Return just last namesFor employees born after 1990)
        // var after1990 = employees.Where(em => em.DateOfBirth.Year > 1990).Select(e => e.LastName); // deferred
        // foreach(var x in after1990)
        //     System.Console.WriteLine(x);
        #endregion

        #region Conceptual#21Linq_train S2-A (Find employees in IT, then calculate average salary, but ensure the collection is enumerated once.)
            // var itEmployeesSalariesAverage = employees.Where(em => em.Department == "IT" && em.IsEmployed).Select(em => em.Salary).Average(); // iterate once   
            // Console.Write(itEmployeesSalariesAverage);
        #endregion

        #region Conceptual#22Linq_train S2-B (Count total projects across all employed IT employees)
            var itEmployeesProjectsCount = employees.Where(em => em.Department == "IT" && em.IsEmployed).Select(em =>em.ProjectCount).Sum();
            Console.Write(itEmployeesProjectsCount);
        #endregion

        #region Conceptual#23Linq_train S2-C (Project employees into an EmployeeSummaryDto)
        var empSummary = employees.Where(em => em.IsEmployed).Select(em => new EmployeeSummaryDTO
        {
            Id = em.Id,
            FullName = em.FirstName + " " + em.LastName,
            Department = em.Department,
            Salary = em.Salary,
            PerformanceScore = em.PerformanceScore
        });

        #endregion






    }
}
