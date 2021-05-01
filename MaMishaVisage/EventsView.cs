using DataAceess;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MaMishaVisage
{
    public partial class EventsView : UserControl, IDataView
    {
        private readonly BindingSource bindingSource = new BindingSource();

        private SQLiteDataAdapter dataAdapter;

        private DataTable dataTable;

        private DatabaseConfiguration databaseConfiguration;

        public EventsView()
        {
            InitializeComponent();
        }

        public void LoadData(DatabaseConfiguration databaseConfiguration)
        {
            this.databaseConfiguration = databaseConfiguration;
            var plantsService = new PowerPlantsService(databaseConfiguration);
            var plants = plantsService.GetPowerPlants().GetAwaiter().GetResult();

            grdData.Columns.Clear();
            grdData.Columns.AddRange(new DataGridViewColumn[] {
                ColumnsFactory.CreateTextBoxColumn("Date", "date"),
                ColumnsFactory.CreateComboBoxColumn("Plant", "powerPlantId", "id", "name", plants),
                ColumnsFactory.CreateTextBoxColumn("Description", "description"),
                ColumnsFactory.CreateTextBoxColumn("Reason", "reason"),
                ColumnsFactory.CreateTextBoxColumn("Rating", "rating"),
                ColumnsFactory.CreateTextBoxColumn("Consequences", "consequences"),
            });

            this.LoadData();
            this.grdData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadData()
        {
            this.dataAdapter = new SQLiteDataAdapter("SELECT * FROM events", this.databaseConfiguration.ConnectionString);
            var commandBuilder = new SQLiteCommandBuilder(this.dataAdapter);
            this.dataTable = new DataTable("events");
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
