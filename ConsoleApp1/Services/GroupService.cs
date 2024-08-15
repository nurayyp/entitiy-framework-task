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
    public class GroupService
    {
        private static readonly AppDBcontext _context;
        static GroupService()
        {
            _context = new AppDBcontext();
        }
        public static void GetAllGroups()
        {
            foreach (var group in _context.Groups.ToList())
            {
                Console.WriteLine($"{group.Id}: {group.Name} - {group.Limit} -- {group.TeacherId}");
            }
        }
        public static void CreateGroup()
        {
        InputName: Messages.InputMessage("Group name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Name input");
                goto InputName;
            }
        InputLimit: Messages.InputMessage("Group limit");
            string limit = Console.ReadLine();
            int groupLimit;
            bool isTrue = int.TryParse(limit, out groupLimit);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Limit input");
                goto InputLimit;
            }
        InputTeacher: Messages.InputMessage("Teacher Id");
            string id = Console.ReadLine();
            int teacherId;
            bool isSucceeded = int.TryParse(id, out teacherId);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("Id input");
                goto InputTeacher;
            }
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == teacherId);
            if (teacher == null)
            {
                Messages.NotFoundMessage("Teacher");
                goto InputTeacher;
            }
            Group group = new Group
            {
                Name = name,
                Limit = groupLimit,
                Id = teacherId,
                Teacher = teacher
            };
            _context.Groups.Add(group);
            _context.SaveChanges();
            Messages.SuccessAddMessage("Group");
        }
        public static void RemoveGroup()
        {
            GetAllGroups();
        InputGroupId: Messages.InputMessage("Id of the group which you want to change");
            string id = Console.ReadLine();
            int groupId;
            bool isTrue = int.TryParse(id, out groupId);    
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Id input");
                goto InputGroupId;
            }
            var group = _context.Groups.FirstOrDefault(x => x.Id == groupId);
            if (group == null || group.IsDeleted)
            {
                Messages.NotFoundMessage("Group");
            }
            group.IsDeleted = true;
            _context.Groups.Remove(group);
            _context.SaveChanges();
            Messages.SuccessRemoveMessage("Group");
        }
        public static void UpdateGroup()
        {
            GetAllGroups();
        InputGroupId: Messages.InputMessage("Group Id");
            string id = Console.ReadLine();
            int groupId;
            bool isTrue = int.TryParse(id, out groupId);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Id input");
                goto InputGroupId;
            }
            var group = _context.Groups.FirstOrDefault(x => x.Id == groupId);
            if (group == null || group.IsDeleted)
            {
                Messages.NotFoundMessage("Group");
                goto InputGroupId;
            }
            InputChoiceForName: Messages.WantToChangeMessage("Group name");
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
            InputNewName: Messages.InputMessage("New group name");
                string newName = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(newName))
                {
                    Messages.InvalidInputMessage("New group name;");
                    goto InputNewName;
                }
                group.Name = newName;
            }
            InputChoiceForLimit: Messages.WantToChangeMessage("Group limit");
            var inputForLimitChoice = Console.ReadLine();
            char choiceForLimit;
            bool isBool = char.TryParse(inputForLimitChoice, out choiceForLimit);
            if (!isBool)
            {
                Messages.InvalidInputMessage("Choice input for limit");
                goto InputChoiceForLimit;
            }
            if (choiceForLimit == 'Y')
            {
            InputNewLimit: Messages.InputMessage("New group limit");
                string newLimitInput = Console.ReadLine();
                int newLimit;
                bool isLimit = int.TryParse(newLimitInput, out newLimit);
                if (!isLimit)
                {
                    Messages.InvalidInputMessage("New group limit");
                    goto InputNewLimit;
                }
                group.Limit = newLimit;
            }
        InputChoiceForTeacher: Messages.WantToChangeMessage("Group teacher");
            var inputForTeacherIdChoice = Console.ReadLine();
            char choiceForTeacherId;
            bool isTeacher = char.TryParse(inputForTeacherIdChoice, out choiceForTeacherId);
            if (!isTeacher)
            {
                Messages.InvalidInputMessage("Choice input for teacher id");
                goto InputChoiceForTeacher;
            }
            if (choiceForTeacherId == 'Y')
            {
            InputNewTeacherId: Messages.InputMessage("New group teacher id");
                string newTeacherIdInput = Console.ReadLine();
                int newTeacherId;
                bool IsId = int.TryParse(newTeacherIdInput, out newTeacherId);
                if (!IsId)
                {
                    Messages.InvalidInputMessage("New group teacher id");
                    goto InputNewTeacherId;
                }
                group.TeacherId = newTeacherId;
            }
            _context.SaveChanges();
            Messages.SuccessUpdateMessage("Group");
        }
        public static void DetailsOfGroup()
        {
            GetAllGroups();
        InputGroupId: Messages.InputMessage("Group id");
            string id = Console.ReadLine();
            int groupId;
            bool isTrue = int.TryParse(id, out groupId);
            if (!isTrue)
            {
                Messages.InvalidInputMessage("Id input");
                goto InputGroupId;
            }
            var group = _context.Groups.FirstOrDefault(x => x.Id == groupId);
            if (group == null || group.IsDeleted)
            {
                Messages.NotFoundMessage("Group");
                goto InputGroupId;
            }
            Console.WriteLine($" Name:{group.Name}, Limit-{group.Limit} : TeacherOfGroup - {group.Teacher.Name}");
        }
    }
}
