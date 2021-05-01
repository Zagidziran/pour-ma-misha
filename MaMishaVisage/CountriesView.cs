using DataAceess;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MaMishaVisage
{
    public partial class CountriesView : UserControl, IDataView
    {
        private readonly BindingSource bindingSource = new BindingSource();

        private SQLiteDataAdapter dataAdapter;

        private DataTable dataTable;

        private DatabaseConfiguration databaseConfiguration;

        public CountriesView()
        {
            InitializeComponent();
        }

        public void LoadData(DatabaseConfiguration databaseConfiguration)
        {
            this.databaseConfiguration = databaseConfiguration;
            var continentsServce = new ContinentsService(databaseConfiguration);
            var continents = continentsServce.GetContinents().GetAwaiter().GetResult();

            grdData.Columns.Clear();
            grdData.Columns.AddRange(new DataGridViewColumn[] {
                ColumnsFactory.CreateTextBoxColumn("Name", "name"),
                ColumnsFactory.CreateComboBoxColumn("Continent", "continentId", "id", "name", continents),
                ColumnsFactory.CreateTextBoxColumn("Code", "code"),
            });


            this.LoadData();
            this.grdData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadData()
        {
            this.dataAdapter = new SQLiteDataAdapter("SELECT * FROM countries", this.databaseConfiguration.ConnectionString);
            var commandBuilder = new SQLiteCommandBuilder(this.dataAdapter);
            this.dataTable = new DataTable("continents");
            this.dataAdapter.Fill(this.dataTable);
            this.bindingSource.DataSource = this.dataTable;

            this.grdData.DataSource = this.bindingSource;
            this.grdData.Columns["id"].Visible = false;
        }

        private void cmdSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataAdapter.Update(this.dataTable);
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.LoadData(this.databaseConfiguration);
        }
    }
}
