using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using Multiple_Choice_Creator.Model;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using iTextSharp.text;

namespace Multiple_Choice_Creator
{
    public partial class CreateTestControl : UserControl
    {
        //private static List<Question> list;
        User myUser;
        public CreateTestControl(User usr)
        {
            InitializeComponent();
            myUser = usr;
            this.Dock = DockStyle.Fill;
        }
        List<QuestionPreview> myQPList = new List<QuestionPreview>();
        int numOfQuestions = 0;

        public void CountQuestion(int num)
        {
            numOfQuestions+=num;
            label3.Text = numOfQuestions.ToString();
        }

        public List<QuestionPreview> getMyPList()
        {
            return myQPList;
        }

        public FlowLayoutPanel getflowlayoutPanel()
        {
            return this.flowLayoutPanel1;
        }

        Question q;
        QuePreview qPreview;
        List<Answer> corans;
        List<Answer> lwrong;

        bool leftorrigt = true;
        int metr;
        string apot = "";
        private void create_Click(object sender, EventArgs e)
          {
            metr = 1;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Test.pdf";
            Document DC = new Document(PageSize.LETTER, 20, 20, 20, 20);
            FileStream FS = File.Create(path);
            PdfWriter.GetInstance(DC, FS);
            DC.Open();
            DC.SetMarginMirroring(true);
            PdfPTable table;
            PdfPCell cell;
            Paragraph paragraph;

            DC.Add(new Paragraph("Author: " + myUser.getEmail() + " " + myUser.getLname()));
            DC.Add(new Paragraph("Semester: "));
            DC.Add(new Paragraph("Lesson: "));
            DC.Add(new Paragraph("Full Name: "));
            DC.Add(new Paragraph("Student Number: "));

            table = new PdfPTable(2);
            bool prime = false;
            if (myQPList.Count % 2 > 0)
                prime = true;
            foreach (QuestionPreview QP in myQPList)
            {

                q = QP.getQuestion();
                corans = QP.getCorrAnswers();
                lwrong = QP.getWrongAnswers();

                string erwt = "";
                string apant = "";
                erwt += metr + ") " + q.getText() + "\n\n";

                Answer[] FinalAnswers = new Answer[corans.Count + lwrong.Count];
                int i = 0;
                foreach (Answer A in corans)
                {
                    FinalAnswers[i] = A;
                    i++;
                }
                foreach (Answer A in lwrong)
                {
                    FinalAnswers[i] = A;
                    i++;
                }
                

                
                for (int x = 0; x < FinalAnswers.Count(); x++)
                {
                    apant += "   O " + FinalAnswers[x].getText() + "\n";        
                    if (corans.Contains(FinalAnswers[x]))
                    {
                        apot += "\n" + metr + "" + (x + 1);
                    }
                }
                


                metr++;

                paragraph = new Paragraph();
                paragraph.Add(new Chunk(erwt, FontFactory.GetFont(FontFactory.HELVETICA, "ASCII", true, 15)));
                paragraph.Add(new Chunk(apant, FontFactory.GetFont(FontFactory.HELVETICA, "ASCII", true, 13)));
                cellConfigure(table, new PdfPCell(paragraph));

                if (prime)                  
                {
                    cellConfigure(table, new PdfPCell(new Paragraph()));
                    leftorrigt = true;
                }
                DC.Add(table);
                DC.Add(new Paragraph("Apotelesmata: " + apot));     
                DC.Close();
            }
        }
        private void cellConfigure(PdfPTable table, PdfPCell cell)	
        {
            cell.BorderWidth = 0;
            cell.Padding = 0;
            cell.PaddingTop = 12;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);
            table.SetWidthPercentage(new float[2] { 460f, 140f }, PageSize.LETTER);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            leftorrigt = true;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            Question q = new Question("Where Am I?","1",1);
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
            //qPreview = new QuePreview(flowLayoutPanel1, q, lCorrect, lwrong, myQPList);
            // panel1.Controls.Add(createtestcontrol);
        }
    }
}
