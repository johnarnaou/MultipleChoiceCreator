using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    public class Answer
    {
        
        private string text;
        public Answer(int id,string text)
        {
            this.text = text;
        }

        public void setText(string text)
        {
            this.text = text;
        }

        public string getText()
        {
            return this.text;
        }
    }
}
