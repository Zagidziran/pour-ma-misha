using DataAceess;
using DataAceess.Entities;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MaMishaVisage
{
    public partial class PlantSummaryByCountryView : UserControl, IDataView
    {
        private readonly BindingSource bindingSource = new BindingSource();

        private SQLiteDataAdapter dataAdapter;

        private DataTable dataTable;

        private DatabaseConfiguration databaseConfiguration;

        public PlantSummaryByCountryView()
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
                new { Name = "Stopped", Value = (long)PlantStatus.Decomissed },
            };

            grdData.Columns.Clear();
            grdData.Columns.AddRange(new DataGridViewColumn[] {
                ColumnsFactory.CreateTextBoxColumn("Country", "country"),
                ColumnsFactory.CreateTextBoxColumn("Operation", "operating"),
                ColumnsFactory.CreateTextBoxColumn("Under Construction", "underConstruction"),
                ColumnsFactory.CreateTextBoxColumn("Decomissed", "stopped"),
                ColumnsFactory.CreateTextBoxColumn("Total", "total"),
                ColumnsFactory.CreateGraphColumn("", "stopped"),
            });

            this.LoadData();
            this.grdData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadData()
        {
            this.dataAdapter = new SQLiteDataAdapter(
                @"SELECT countries.name country, SUM(stats.operating) operating, SUM(stats.underConstruction) underConstruction, SUM(stats.stopped) stopped, SUM(stats.operating) + SUM(stats.underConstruction) + SUM(stats.stopped) total FROM countries 				
                    JOIN (SELECT countryId, CASE status WHEN 0 THEN 1 ELSE 0 END operating, CASE status WHEN 2 THEN 1 ELSE 0 END stopped, CASE status WHEN 1 THEN 1 ELSE 0 END underConstruction FROM powerPlants) stats ON stats.countryId = countries.id
                    GROUP BY countries.id 
                    ORDER BY countries.name", this.databaseConfiguration.ConnectionString);
            this.dataTable = new DataTable("powerPlants");
            this.dataAdapter.Fill(this.dataTable);
            this.bindingSource.DataSource = this.dataTable;
            
            this.grdData.DataSource = this.bindingSource;
        }
    }
}
