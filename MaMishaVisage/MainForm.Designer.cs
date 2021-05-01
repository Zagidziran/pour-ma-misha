
namespace MaMishaVisage
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.mnPlantSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.mnContinents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCountries = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPowerPlants = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.nmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.continentsView = new MaMishaVisage.ContinentsView();
            this.countriesView = new MaMishaVisage.CountriesView();
            this.plantsView = new MaMishaVisage.PlantsView();
            this.eventsView = new MaMishaVisage.EventsView();
            this.plantSummaryView = new MaMishaVisage.PlantSummaryView();
            this.about = new MaMishaVisage.AboutView();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPlantSummary,
            this.mnContinents,
            this.mnCountries,
            this.mnPowerPlants,
            this.mnEvents,
            this.nmAbout});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // mnPlantSummary
            // 
            this.mnPlantSummary.Name = "mnPlantSummary";
            this.mnPlantSummary.Size = new System.Drawing.Size(116, 20);
            this.mnPlantSummary.Tag = "plantSummaryView";
            this.mnPlantSummary.Text = "Plants Summmary";
            // 
            // mnContinents
            // 
            this.mnContinents.Name = "mnContinents";
            this.mnContinents.Size = new System.Drawing.Size(77, 20);
            this.mnContinents.Tag = "continentsView";
            this.mnContinents.Text = "Continents";
            // 
            // mnCountries
            // 
            this.mnCountries.Name = "mnCountries";
            this.mnCountries.Size = new System.Drawing.Size(70, 20);
            this.mnCountries.Tag = "countriesView";
            this.mnCountries.Text = "Countries";
            // 
            // mnPowerPlants
            // 
            this.mnPowerPlants.Name = "mnPowerPlants";
            this.mnPowerPlants.Size = new System.Drawing.Size(87, 20);
            this.mnPowerPlants.Tag = "plantsView";
            this.mnPowerPlants.Text = "Power Plants";
            // 
            // mnEvents
            // 
            this.mnEvents.Name = "mnEvents";
            this.mnEvents.Size = new System.Drawing.Size(53, 20);
            this.mnEvents.Tag = "eventsView";
            this.mnEvents.Text = "Events";
            // 
            // nmAbout
            // 
            this.nmAbout.Name = "nmAbout";
            this.nmAbout.Size = new System.Drawing.Size(52, 20);
            this.nmAbout.Tag = "about";
            this.nmAbout.Text = "About";
            // 
            // continentsView
            // 
            this.continentsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.continentsView.Location = new System.Drawing.Point(12, 27);
            this.continentsView.Name = "continentsView";
            this.continentsView.Size = new System.Drawing.Size(776, 411);
            this.continentsView.TabIndex = 3;
            // 
            // countriesView
            // 
            this.countriesView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countriesView.Location = new System.Drawing.Point(12, 27);
            this.countriesView.Name = "countriesView";
            this.countriesView.Size = new System.Drawing.Size(776, 411);
            this.countriesView.TabIndex = 4;
            // 
            // plantsView
            // 
            this.plantsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plantsView.Location = new System.Drawing.Point(12, 27);
            this.plantsView.Name = "plantsView";
            this.plantsView.Size = new System.Drawing.Size(776, 411);
            this.plantsView.TabIndex = 5;
            // 
            // eventsView
            // 
            this.eventsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventsView.Location = new System.Drawing.Point(12, 27);
            this.eventsView.Name = "eventsView";
            this.eventsView.Size = new System.Drawing.Size(776, 411);
            this.eventsView.TabIndex = 6;
            // 
            // plantSummaryView
            // 
            this.plantSummaryView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plantSummaryView.Location = new System.Drawing.Point(12, 27);
            this.plantSummaryView.Name = "plantSummaryView";
            this.plantSummaryView.Size = new System.Drawing.Size(776, 411);
            this.plantSummaryView.TabIndex = 7;
            // 
            // about
            // 
            this.about.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.about.Location = new System.Drawing.Point(12, 27);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(776, 411);
            this.about.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.about);
            this.Controls.Add(this.plantSummaryView);
            this.Controls.Add(this.eventsView);
            this.Controls.Add(this.plantsView);
            this.Controls.Add(this.countriesView);
            this.Controls.Add(this.continentsView);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Pour ma Misha";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mnContinents;
        private System.Windows.Forms.ToolStripMenuItem mnCountries;
        private ContinentsView continentsView;
        private CountriesView countriesView;
        private PlantsView plantsView;
        private System.Windows.Forms.ToolStripMenuItem mnPowerPlants;
        private System.Windows.Forms.ToolStripMenuItem mnEvents;
        private EventsView eventsView;
        private System.Windows.Forms.ToolStripMenuItem mnPlantSummary;
        private PlantSummaryView plantSummaryView;
        private System.Windows.Forms.ToolStripMenuItem nmAbout;
        private AboutView about;
    }
}

