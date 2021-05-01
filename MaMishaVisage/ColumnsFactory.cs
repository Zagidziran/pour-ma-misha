using MaMishaVisage.Controls;
using System.Windows.Forms;

namespace MaMishaVisage
{
    public static class ColumnsFactory
    {
        public static DataGridViewTextBoxColumn CreateTextBoxColumn(string name, string dataPropertyName)
        {
            var column = new DataGridViewTextBoxColumn();
            column.HeaderText = name;
            column.DataPropertyName = dataPropertyName;

            return column;
        }

        public static GraphColumn CreateGraphColumn(string name, string dataPropertyName)
        {
            var column = new GraphColumn();
            column.HeaderText = name;
            column.DataPropertyName = dataPropertyName;
            column.MinimumWidth = 200;
            return column;
        }


        public static DataGridViewComboBoxColumn CreateComboBoxColumn(
            string name,
            string dataPropertyName,
            string valueMember,
            string displayMember,
            object dataSource)
        {
            var column = new DataGridViewComboBoxColumn();
            column.DataSource = new BindingSource() { DataSource = dataSource };
            column.HeaderText = name;
            column.DataPropertyName = dataPropertyName;
            column.ValueMember = valueMember;
            column.DisplayMember = displayMember;

            return column;
        }
    }
}
