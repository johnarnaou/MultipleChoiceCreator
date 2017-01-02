using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace Multiple_Choice_Creator
{
    public partial class CreateTestControl : UserControl
    {
        private static List<Question> list;
        public CreateTestControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void create_Click(object sender, EventArgs e)
        {
            list = new List<Question>();
            var query = from c in list
                        select c;


            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Test.pdf";
            Document DC = new Document();
            FileStream FS = File.Create(path);
            PdfWriter.GetInstance(DC, FS);
            DC.Open();
            foreach (var X in query)
            {
                DC.Add(new Paragraph(X));
            }
            
            DC.Close();
        }
    }
}
