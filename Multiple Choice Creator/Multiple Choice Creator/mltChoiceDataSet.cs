
using System.Data;
using System;
namespace Multiple_Choice_Creator
{


    partial class mltChoiceDataSet
    {
        partial class AnswDataTable
        {
            private void AnswDataTable_TableNewRow(object sender, DataTableNewRowEventArgs e)
            {
                mltChoiceDataSet.AnswRow newrow = (mltChoiceDataSet.AnswRow)e.Row;
                if (newrow.answer.Length < 20)
                {

                    newrow.Delete();
                }
                else
                {
                    e.Row.ClearErrors();
                }
            }

            private void AnswDataTable_AnswColumnChanging(object sender, DataColumnChangeEventArgs e)
            {//an ginetai update dhladh se kapoio keli tou pinaka Answ
                
                if (e.Column.ColumnName == "answer")
                {
                    if (Convert.ToString(e.ProposedValue).Length < 5)
                    {
                        e.Row.SetColumnError(e.Column, "error,not enough characters");
                    }
                }
                else
                {
                    e.Row.SetColumnError(e.Column,string.Empty);
                }

            }
        }

        partial class QuestDataTable
        {
            private void QuestDatatbale_TableNewRow(object sender, DataTableNewRowEventArgs e)
            {

                mltChoiceDataSet.QuestRow newrow = (mltChoiceDataSet.QuestRow)e.Row;
                if (newrow.question.Length < 20)
                {

                    newrow.Delete();
                }
                else
                {
                    e.Row.ClearErrors();
                }
            }

            private void QuestDatatbale_QuestColumnChanging(object sender, DataColumnChangeEventArgs e)
            {//when updating question
                if (e.Column.ColumnName == "question")
                {
                    if (Convert.ToString(e.ProposedValue).Length < 5)
                    {
                        e.Row.SetColumnError(e.Column, "error,not enough characters");
                    }
                }
                else
                {
                    e.Row.SetColumnError(e.Column, string.Empty);
                }

            }
        }

        partial class UsersDataTable
        {
        }
    }
}

namespace Multiple_Choice_Creator.mltChoiceDataSetTableAdapters {
    
    
    public partial class QuestTableAdapter {
    }
}
