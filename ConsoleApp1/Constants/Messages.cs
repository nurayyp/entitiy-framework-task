using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp1.Constants
{
    public class Messages
    {
        public static void SuccessUpdateMessage(string title) => Console.WriteLine($"{title} successfully updated");
        public static void WantToChangeMessage(string title) => Console.WriteLine($"Do you want to change {title}? Choose 'Y' for yes; 'N' for no ");
        public static void SuccessRemoveMessage(string title) => Console.WriteLine($"{title} successfully removed");
        public static void SuccessAddMessage(string title) => Console.WriteLine($"{title} successfully added");
        public static void NotFoundMessage(string title) => Console.WriteLine($"{title} is not found");
        public static void InvalidInputMessage(string title) => Console.WriteLine($"{title} is invalid, please try again");
        public static void InputMessage(string title) => Console.WriteLine($"Please input {title}");
    }
}
