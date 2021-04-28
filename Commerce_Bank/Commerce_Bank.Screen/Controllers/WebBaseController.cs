using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Commerce_Bank.Screen.Controllers.Message;

namespace Commerce_Bank.Screen.Controllers
{
    public class WebBaseController : Controller
    {
        protected void SetMessage(string message, Message.Category messageType)
        {
            var msg = new Message(message, (int)messageType);
            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }
        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "";
            TempData["notification"] = msg;
        }
    }
    public class Message
    {
        public enum Category
        {
            Warning = 1,
            Error = 2,
            Information = 3
        }
        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        }

        public Message()
        {
        }

        public Message(string message)
        {
            Description = message;
        }

        public Message(string message, int type)
        {
            Description = message;
            Type = type;
        }

        public Message(string title, string message, int type)
        {
            Title = title;
            Description = message;
            Type = type;
        }

        public int Type { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Advice { get; set; }
        public string Action { get; set; }
    }
}