using ConsoleApp1.Constants;
using ConsoleApp1.Contexts;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public static class TeacherService
    {
        private static readonly AppDBcontext _context;
        static TeacherService()
        {
            _context = new AppDBcontext();
        }
        public static void GetAllTeachers()
        {
            var teacherList = _context.Teachers.ToList();
            foreach (var teacher in teacherList)
            {
                Console.WriteLine($"Id : {teacher.Id}, Name - {teacher.Name} Surname - {teacher.Surname}");
            }
        }
        public static void CreateTeacher()
        {
            TeacherNameInput: Messages.InputMessage("teacher name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("teacher name");
                goto TeacherNameInput;
            }
        TeacherSurnameInput: Messages.InputMessage("teacher surname");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Messages.InvalidInputMessage("teacher surname");
                goto TeacherSurnameInput;
            }
            Teacher teacher = new Teacher
            {
                Name = name,
                Surname = surname,
            };
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            Messages.SuccessAddMessage("Teacher");
        }
        public static void RemoveTeacher()
        {
            GetAllTeachers();
        InputTeacherId: Messages.InputMessage("Teacher id");
            string id = Console.ReadLine();
            int teacherId;
            bool isTrue = int.TryParse(id, out teacherId);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Teacher id input");
                goto InputTeacherId;
            }
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == teacherId);
            if (teacher == null || teacher.IsDeleted)
            {
                Messages.NotFoundMessage("Teacher");
            }
            teacher.IsDeleted = true;
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            Messages.SuccessRemoveMessage("Teacher");
        }
        public static void UpdateTeacher()
        {
            GetAllTeachers();
        InputTeacherId: Messages.InputMessage("Teacher Id");
            string id = Console.ReadLine();
            int teacherId;
            bool isTrue = int.TryParse(id, out teacherId);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Id input");
                goto InputTeacherId;
            }
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == teacherId);
            if (teacher == null || teacher.IsDeleted)
            {
                Messages.NotFoundMessage("Teacher");
                goto InputTeacherId;
            }
        InputChoiceForName: Messages.WantToChangeMessage("Teacher name");
            var inputForNameChoice = Console.ReadLine();
            char choiceForName;
            bool isSucceeded = char.TryParse(inputForNameChoice, out choiceForName);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("Choice input for name");
                goto InputChoiceForName;
            }
            if (choiceForName == 'Y')
            {
            InputNewName: Messages.InputMessage("New teacher name");
                string newName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    Messages.InvalidInputMessage("New teacher name;");
                    goto InputNewName;
                }
                teacher.Name = newName;
            }
        InputChoiceForSurname: Messages.WantToChangeMessage("Teacher surname");
            var inputForSurnameChoice = Console.ReadLine();
            char choiceForSurname;
            bool isBool = char.TryParse(inputForSurnameChoice, out choiceForSurname);
            if (!isBool)
            {
                Messages.InvalidInputMessage("Choice input for surname");
                goto InputChoiceForSurname;
            }
            if (choiceForSurname == 'Y')
            {
            InputNewSurname: Messages.InputMessage("New teacher surname");
                string newSurname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newSurname))
                {
                    Messages.InvalidInputMessage("New teacher surname;");
                    goto InputNewSurname;
                }
                teacher.Surname = newSurname;
            }
            _context.SaveChanges();
            Messages.SuccessUpdateMessage("Teacher");
        }
        public static void DetailsOfTeacher()
        {
            GetAllTeachers();
        InputTeacherId: Messages.InputMessage("Teacher id");
            string id = Console.ReadLine();
            int teacherId;
            bool isTrue = int.TryParse(id, out teacherId);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Id input");
                goto InputTeacherId;
            }
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == teacherId);
            if (teacher == null || teacher.IsDeleted)
            {
                Messages.NotFoundMessage("Teacher");
                goto InputTeacherId;
            }
            Console.WriteLine($" Name:{teacher.Name} Surname:{teacher.Surname}");
        }
    }
}
