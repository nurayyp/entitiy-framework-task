using ConsoleApp1.Constants;
using ConsoleApp1.Contexts;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public static class StudentService
    {
        private static readonly AppDBcontext _context;
        static StudentService()
        {
            _context = new AppDBcontext();
        }
        public static void GetAllStudents()
        {
            var studentList = _context.Students.ToList();
            foreach (var student in studentList)
            {
                Console.WriteLine($"Id : {student.Id}, Name - {student.Name} Surname - {student.Surname} Email - {student.Email} BirthDate:{student.BirthDate}");
            }
        }
        public static void CreateStudent()
        {
        StudentNameInput: Messages.InputMessage("student name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("student name");
                goto StudentNameInput;
            }
        StudentSurnameInput: Messages.InputMessage("student surname");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Messages.InvalidInputMessage("student surname");
                goto StudentSurnameInput;
            }
        StudentEmailInput: Messages.InputMessage("student email");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Messages.InvalidInputMessage("student email");
                goto StudentEmailInput;
            }
        StudentBirthDateInput: Messages.InputMessage("student birthdate");
            string birthdate = Console.ReadLine();
            DateTime birthdateOfStudent;
            bool isTrue = DateTime.TryParse(birthdate, out birthdateOfStudent);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("student birthdate");
                goto StudentBirthDateInput;
            }
        InputGroup: Messages.InputMessage("Group Id");
            string id = Console.ReadLine();
            int groupId;
            bool isSucceeded = int.TryParse(id, out groupId);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("Id input");
                goto InputGroup;
            }
            var group = _context.Groups.FirstOrDefault(x => x.Id == groupId);
            if (group == null)
            {
                Messages.NotFoundMessage("Group");
                goto InputGroup;
            }
            Student student = new Student
            {
                Name = name,
                Surname = surname,
                Email = email,
                BirthDate = birthdateOfStudent,
                Id = groupId,
                Group = group
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            Messages.SuccessAddMessage("Student");
        }
        public static void RemoveStudent()
        {
            GetAllStudents();
        InputStudentId: Messages.InputMessage("Student id");
            string id = Console.ReadLine();
            int studentId;
            bool isTrue = int.TryParse(id, out studentId);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Student id input");
                goto InputStudentId;
            }
            var student = _context.Students.FirstOrDefault(x => x.Id == studentId);
            if (student == null || student.IsDeleted)
            {
                Messages.NotFoundMessage("Stydent");
            }
            student.IsDeleted = true;
            _context.Students.Remove(student);
            _context.SaveChanges();
            Messages.SuccessRemoveMessage("Student");
        }
        public static void UpdateStudent()
        {

            GetAllStudents();
        InputStudentId: Messages.InputMessage("Student Id");
            string id = Console.ReadLine();
            int studentId;
            bool isTrue = int.TryParse(id, out studentId);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Id input");
                goto InputStudentId;
            }
            var student = _context.Students.FirstOrDefault(x => x.Id == studentId);
            if (student == null || student.IsDeleted)
            {
                Messages.NotFoundMessage("Student");
                goto InputStudentId;
            }
        InputChoiceForName: Messages.WantToChangeMessage("Student name");
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
            InputNewName: Messages.InputMessage("New student name");
                string newName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    Messages.InvalidInputMessage("New student name;");
                    goto InputNewName;
                }
                student.Name = newName;
            }
        InputChoiceForSurname: Messages.WantToChangeMessage("Student surname");
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
            InputNewSurname: Messages.InputMessage("New student surname");
                string newSurname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newSurname))
                {
                    Messages.InvalidInputMessage("New student surname;");
                    goto InputNewSurname;
                }
                student.Surname = newSurname;
            }
        InputChoiceForEmail: Messages.WantToChangeMessage("Student email");
            var inputForEmailChoice = Console.ReadLine();
            char choiceForEmail;
            bool isEmail = char.TryParse(inputForEmailChoice, out choiceForEmail);
            if (!isEmail)
            {
                Messages.InvalidInputMessage("Choice input for email");
                goto InputChoiceForEmail;
            }
            if (choiceForEmail == 'Y')
            {
            InputNewEmail: Messages.InputMessage("New student email");
                string newEmail = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newEmail))
                {
                    Messages.InvalidInputMessage("New student email;");
                    goto InputNewEmail;
                }
                student.Email = newEmail;
            }
        InputChoiceForBirthDate: Messages.WantToChangeMessage("Student birthdate");
            var inputForBirthDateChoice = Console.ReadLine();
            char choiceForBirthDate;
            bool isDate = char.TryParse(inputForBirthDateChoice, out choiceForBirthDate);
            if (!isDate)
            {
                Messages.InvalidInputMessage("Choice input for birthdate");
                goto InputChoiceForBirthDate;
            }
            if (choiceForBirthDate == 'Y')
            {
            InputNewBirthDate: Messages.InputMessage("New student birthdate");
                string newDate = Console.ReadLine();
                DateTime newBirthDate;
                bool isYes = DateTime.TryParse(newDate, out newBirthDate);
                if (!isYes)
                {
                    Messages.InvalidInputMessage("New student birthdate;");
                    goto InputNewBirthDate;
                }
                student.BirthDate = newBirthDate;
            }
        InputChoiceForGroup: Messages.WantToChangeMessage("Group of student");
            var inputForGroupIdChoice = Console.ReadLine();
            char choiceForGroupId;
            bool isGroup = char.TryParse(inputForGroupIdChoice, out choiceForGroupId);
            if (!isGroup)
            {
                Messages.InvalidInputMessage("Choice input for group id");
                goto InputChoiceForGroup;
            }
            if (choiceForGroupId == 'Y')
            {
            InputNewGroupId: Messages.InputMessage("New group id");
                string newGroupIdInput = Console.ReadLine();
                int newGroupId;
                bool IsId = int.TryParse(newGroupIdInput, out newGroupId);
                if (!IsId)
                {
                    Messages.InvalidInputMessage("New group id");
                    goto InputNewGroupId;
                }
                student.GroupId = newGroupId;
            }
            _context.SaveChanges();
            Messages.SuccessUpdateMessage("Student");
        }
        public static void DetailsOfStudent()
        {
            GetAllStudents();
        InputStudentId: Messages.InputMessage("Student id");
            string id = Console.ReadLine();
            int studentId;
            bool isTrue = int.TryParse(id, out studentId);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Id input");
                goto InputStudentId;
            }
            var student = _context.Students.FirstOrDefault(x => x.Id == studentId);
            if (student == null || student.IsDeleted)
            {
                Messages.NotFoundMessage("Student");
                goto InputStudentId;
            }
            Console.WriteLine($" Name:{student.Name} Surname:{student.Surname} - BirthDate: {student.BirthDate} Email: {student.Email} Group-{student.GroupId}");
        }
    }
}
