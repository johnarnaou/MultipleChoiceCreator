
using System.Data;

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

            private void AnswDataTable_AnswRowChanging(object sender, AnswRowChangeEvent e)
            {//an ginetai update dhladh
                if (e.Row.RowState == DataRowState.Modified)
                {
                    if (e.Row.answer.Length < 20)
                    {
                        e.Row.RowError =
                      "the answer can not be upbadated.Letters count<20";
                        e.Row.CancelEdit();
                        e.Row.RowError += ",edit cancelled";
                    }
                    else
                    {
                        e.Row.ClearErrors();
                    }
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

            private void QuestDatatbale_QuestRowChanging(object sender, QuestRowChangeEvent e)
            {//when updating question
                if (e.Row.RowState == DataRowState.Modified)
                {
                    if (e.Row.question.Length < 20)
                    {
                        e.Row.RowError =
                      "the question can not be upbadated.Letters count<20";
                        e.Row.CancelEdit();
                        e.Row.RowError += ",edit cancelled";
                    }
                    else
                    {
                        e.Row.ClearErrors();
                    }
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
