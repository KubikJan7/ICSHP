using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesLibrary
{
    public class BaseMessage
    {
        public string Content { set; get; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            return Content == (obj as BaseMessage).Content;

            //var message = obj as BaseMessage;
            //return message != null &&
            //       Content == message.Content;
        }

        public override int GetHashCode()
        {
            return 13 + Content.GetHashCode();
            //return 1997410482 + EqualityComparer<string>.Default.GetHashCode(Content);
        }

        public override string ToString()
        {
            return Content.ToString();
        }
    }
}
