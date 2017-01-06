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
using Multiple_Choice_Creator.Model;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;

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
        {/*
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
                //DC.Add(new Paragraph(X));
            }
            
            DC.Close();*/
        }

        QuePreview qPreview;

        private void button1_Click(object sender, EventArgs e)
        {
            
            Question q = new Question("Where Am I?",'1',1);
            Answer ans = new Answer(2, "Wrong1Debug");
            Answer ans2 = new Answer(3, "Wrong2Debug");
            List<Answer> lwrong= new List<Answer>();
            lwrong.Add(ans);
            lwrong.Add(ans2);
            List < Answer > lCorrect= new List<Answer>();
            Answer ans5 = new Answer(66, "CorrectAnswerDebug");
            lCorrect.Add(ans5);
            //QuestionAnswer QA = new QuestionAnswer(q);
            //AnswTableAdapter ata = new AnswTableAdapter();
            // mltChoiceDataSet.AnswDataTable ansDataTable=new mltChoiceDataSet.AnswDataTable();
            //ata.FillAnswersByQuestionID(ansDataTable,1);
            //QA.setAnswersDataTable(ansDataTable);
            string qu = "Where am I?";
            string ac = "home";
            string aw = "teithe";


            
            //QuePreview myQuewPreview = new QuePreview(panel1, QA);
            //Console.WriteLine(QA.ToString());

            //Εδω θα μπαίνει από panel to view a question
            qPreview = new QuePreview(flowLayoutPanel1, q, lCorrect,lwrong);
           // panel1.Controls.Add(createtestcontrol);
        }
    }
}
