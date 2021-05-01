using DataAceess;
using DataAceess.Entities;
using Microsoft.Data.Sqlite;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace MaMishaVisage
{
    public partial class MainForm : Form
    {
        private readonly DatabaseConfiguration databaseConfiguration;
        private string currentViewName = "plantSummaryView";

        public MainForm(ContinentsService contnentsService, DatabaseConfiguration databaseConfiguration)
        {
            this.databaseConfiguration = databaseConfiguration;

            InitializeComponent();

            this.ShowComponent(this.currentViewName);
        }

        private void ShowComponent(string name)
        {
            this.currentViewName = name;
            foreach (var dataView in this.Controls.OfType<IDataView>())
            {
                dataView.LoadData(this.databaseConfiguration);
                var control = (Control)dataView;
                control.Visible = this.currentViewName == control.Name;
            }
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag != null)
            this.ShowComponent(e.ClickedItem.Tag.ToString());
        }
    }
}
