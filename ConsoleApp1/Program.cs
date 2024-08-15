using Azure;
using ConsoleApp1.Constants;
using ConsoleApp1.Services;
using Microsoft.Identity.Client;

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            ShowMenu();
            string input = Console.ReadLine();
            int choice;
            bool isTrue = int.TryParse(input, out choice);
            if (isTrue)
            {
                switch ((Operations)choice)
                {
                    case Operations.GetAllTeachers:
                        TeacherService.GetAllTeachers();
                        break;
                    case Operations.CreateTeacher:
                        TeacherService.CreateTeacher();
                        break;
                    case Operations.RemoveTeacher:
                        TeacherService.RemoveTeacher();
                        break;
                    case Operations.UpdateTeacher:
                        TeacherService.UpdateTeacher();
                        break;
                    case Operations.DetailsOfTeacher:
                        TeacherService.DetailsOfTeacher();
                        break;
                    case Operations.GetAllStudents:
                        StudentService.GetAllStudents();
                        break;
                    case Operations.CreateStudent:
                        StudentService.CreateStudent();
                        break;
                    case Operations.RemoveStudent:
                        StudentService.RemoveStudent();
                        break;
                    case Operations.UpdateStudent:
                        StudentService.UpdateStudent();
                        break;
                    case Operations.DetailsOfStudent:
                        StudentService.DetailsOfStudent();
                        break;
                    case Operations.GetAllGroups:
                        GroupService.GetAllGroups(); 
                        break;
                    case Operations.CreateGroup:
                        GroupService.CreateGroup();
                        break;
                    case Operations.RemoveGroup:
                        GroupService.RemoveGroup();
                        break;
                    case Operations.UpdateGroup:
                        GroupService.UpdateGroup();
                        break;
                    case Operations.DetailsOfGroup:
                        GroupService.DetailsOfGroup();
                        break;
                    case Operations.Exit:
                        return;
                    default:
                        Messages.InvalidInputMessage("choice");
                        break;
                }
            }
            else
            {
                Messages.InvalidInputMessage("choice");
            }
        }
    }
    public static void ShowMenu()
    {
        Console.WriteLine("MENU");
        Console.WriteLine("1 - Get All Teachers");
        Console.WriteLine("2 - Create Teacher");
        Console.WriteLine("3 - Remove Teacher");
        Console.WriteLine("4 - Update Teacher");
        Console.WriteLine("5 - Details of Teacher");
        Console.WriteLine("1 - Get All Students");
        Console.WriteLine("2 - Create Stuent");
        Console.WriteLine("3 - Remove Student");
        Console.WriteLine("4 - Update Student");
        Console.WriteLine("5 - Details of Student");
        Console.WriteLine("1 - Get All Groups");
        Console.WriteLine("2 - Create Group");
        Console.WriteLine("3 - Remove Group");
        Console.WriteLine("4 - Update Group");
        Console.WriteLine("5 - Details of Group");
        Console.WriteLine("0 - Exit");
    }
}