using DataAceess;
using System.Windows.Forms;

namespace MaMishaVisage
{
    public partial class AboutView : UserControl, IDataView
    {
        public AboutView()
        {
            InitializeComponent();
        }

        public void LoadData(DatabaseConfiguration databaseConfiguration)
        {
        }
    }
}
