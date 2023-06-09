using StudentCatalog1;
using System;
using System.Collections.Generic;
using System.Linq;

class Catalog
{
    private List<Student> students = new List<Student>();
    public void GenerateDefaultStudents()
    {
        students = new List<Student>
            {
                new Student(1, "Alice", "William", 25, new Address("Gherla", "Fierarilor", 5)),
                new Student(2, "John", "Simsomn", 21, new Address("Oradea", "Plopilor", 350)),
                new Student(3, "Ruth", "Peter", 22, new Address("Timisoara", "Timis", 73)),
                new Student(4, "Joanna", "Flinston", 29, new Address("Dej", "Ispas", 22)),
                new Student(1, "Aron", "Ross", 25, new Address("Cluj Napoca", "Motilor", 99))
            };


    }


    public void DisplayAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("\nNo students found.\n");
            return;
        }

        Console.WriteLine("\nAll Students:\n");
        foreach (Student student in students)
        {
            student.DisplayStudent();
            Console.WriteLine();
        }
    }

    public void DisplayStudentById(int id)
    {
        Student student = students.Find(s => s.Id == id);
        if (student != null)
        {
            Console.WriteLine("\nStudent Details:\n");
            student.DisplayStudent();
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"\nStudent with ID {id} not found.\n");
        }
    }

    public void AddStudentFromConsole()
    {

        Console.WriteLine("\nEnter student details:");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter address details:");
        Console.Write("City: ");
        string city = Console.ReadLine();
        Console.Write("Street: ");
        string street = Console.ReadLine();
        Console.Write("Number: ");
        string number = Console.ReadLine();

        Address address = new Address(city, street, number);
        Student student = new Student(id, firstName, lastName, age, address);
        students.Add(student);

        Console.WriteLine("\nStudent added successfully.\n");
    }

    public void RemoveStudentById(int id)
    {
        int index = students.FindIndex(s => s.Id == id);
        if (index != -1)
        {
            students.RemoveAt(index);
            Console.WriteLine($"\nStudent with ID {id} has been removed.\n");
        }
        else
        {
            Console.WriteLine($"\nStudent with ID {id} not found.\n");
        }
    }

    public void UpdateStudentData(int id)
    {
        Student student = students.Find(s => s.Id == id);
        if (student != null)
        {
            Console.WriteLine("\nEnter updated student details:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            student.FirstName = firstName;
            student.LastName = lastName;
            student.Age = age;

            Console.WriteLine("\nStudent data updated successfully.\n");
        }
        else
        {
            Console.WriteLine($"\nStudent with ID {id} not found.\n");
        }
    }

    public void UpdateStudentAddress(int id)
    {
        Student student = students.Find(s => s.Id == id);
        if (student != null)
        {
            Console.WriteLine("\nEnter updated address details:");
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.Write("Number: ");
            string number = Console.ReadLine();

            Address address = new Address(city, street, number);
            student.Address = address;

            Console.WriteLine("\nStudent address updated successfully.\n");
        }
        else
        {
            Console.WriteLine($"\nStudent with ID {id} not found.\n");
        }
    }

    public void AssignGradeToStudent(int id)
    {
        Student student = students.Find(s => s.Id == id);
        if (student != null)
        {
            Console.WriteLine("\nEnter grade details:");
            Console.Write("Subject: ");
            string subject = Console.ReadLine();
            Console.Write("Value: ");
            double value = double.Parse(Console.ReadLine());

            Grade grade = new Grade(value, subject);
            student.AddGrade(grade);

            Console.WriteLine("\nGrade assigned to the student.\n");
        }
        else
        {
            Console.WriteLine($"\nStudent with ID {id} not found.\n");
        }
    }

    public void DisplayOverallAverage(int id)
    {
        Student student = students.Find(s => s.Id == id);
        if (student != null)
        {
            double average = student.GetAverageGrade();
            Console.WriteLine($"\nOverall average for student with ID {id}: {average}\n");
        }
        else
        {
            Console.WriteLine($"\nStudent with ID {id} not found.\n");
        }
    }

    public void DisplaySubjectWiseAverage(int id)
    {
        Student student = students.Find(s => s.Id == id);
        if (student != null)
        {
            Dictionary<string, double> subjectAverages = student.GetSubjectWiseAverages();
            Console.WriteLine($"\nSubject-wise averages for student with ID {id}:");
            foreach (var subjectAverage in subjectAverages)
            {
                Console.WriteLine($"{subjectAverage.Key}: {subjectAverage.Value}");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"\nStudent with ID {id} not found.\n");
        }
    }

    public void DisplayStudentsInDescendingOrder()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("\nNo students found.\n");
            return;
        }

        List<Student> sortedStudents = students.OrderByDescending(s => s.GetAverageGrade()).ToList();
        Console.WriteLine("\nStudents in descending order of average:\n");
        foreach (Student student in sortedStudents)
        {
            student.DisplayStudent();
            Console.WriteLine();
        }
    }
}

