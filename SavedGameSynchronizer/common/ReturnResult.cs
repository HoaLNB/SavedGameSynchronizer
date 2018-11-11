using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavedGameSynchronizer.common
{
    class ReturnResult
    {
        string code;
        string message;
        object content;

        public ReturnResult()
        {
        }

        public ReturnResult(string code)
        {
            this.code = code;
        }

        public ReturnResult(string code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public ReturnResult(string code, string message, object content)
        {
            this.code = code;
            this.message = message;
            this.content = content;
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public object Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
