using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    public class Tag
    {
        private string text;
        private int userId;

        public Tag(string text,int userId)
        {
            this.text = text;
            this.userId = userId;    
        }

        public void setText(string text)
        {
            this.text = text;
        }

        public void setUserId(int userId)
        {
            this.userId = userId;
        }

        public string getText()
        {
            return this.text;
        }

        public int getUserId()
        {
            return this.userId;
        }

    }
}
