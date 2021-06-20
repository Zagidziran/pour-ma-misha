using DataAceess;
using DataAceess.Entities;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MaMishaVisage
{
    public partial class PlantsView : UserControl, IDataView
    {
        private readonly BindingSource bindingSource = new BindingSource();

        private SQLiteDataAdapter dataAdapter;

        private DataTable dataTable;

        private DatabaseConfiguration databaseConfiguration;

        public PlantsView()
        {
            InitializeComponent();
        }

        public void LoadData(DatabaseConfiguration databaseConfiguration)
        {
            this.databaseConfiguration = databaseConfiguration;
            var countriesServce = new CountriesService(databaseConfiguration);
            var countries = countriesServce.GetCountries().GetAwaiter().GetResult();
            var statuses = new[] {
                new { Name = "In operation", Value = (long)PlantStatus.InOperation },
                new { Name = "Under constraction", Value = (long)PlantStatus.UnderConstruction },
                new { Name = "Decomissed", Value = (long)PlantStatus.Decomissed },
            };

            grdData.Columns.Clear();
            grdData.Columns.AddRange(new DataGridViewColumn[] {
                ColumnsFactory.CreateTextBoxColumn("Name", "name"),
                ColumnsFactory.CreateComboBoxColumn("Country", "countryId", "id", "name", countries),
                ColumnsFactory.CreateComboBoxColumn("Status", "status", "value", "name", statuses),
                ColumnsFactory.CreateTextBoxColumn("Reactor Count", "reactorCount"),
                ColumnsFactory.CreateTextBoxColumn("Reactor Type", "reactorType"),
                ColumnsFactory.CreateTextBoxColumn("Gross Capacity", "grossCapacity"),
                ColumnsFactory.CreateTextBoxColumn("Net Capacity", "netCapacity"),
                ColumnsFactory.CreateTextBoxColumn("Comissed At", "comissedAt"),
                ColumnsFactory.CreateTextBoxColumn("Decomissed At", "decomissedAt"),
                ColumnsFactory.CreateTextBoxColumn("Monitoring Period", "monitoringPeriod"),
            });

            this.LoadData();
            this.grdData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadData()
        {
            this.dataAdapter = new SQLiteDataAdapter("SELECT * FROM powerPlants", this.databaseConfiguration.ConnectionString);
            var commandBuilder = new SQLiteCommandBuilder(this.dataAdapter);
            this.dataTable = new DataTable("powerPlants");
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
