using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MaMishaVisage.Controls
{
    public class GraphColumn : DataGridViewColumn
    {
        public GraphColumn()
        {
            this.CellTemplate = new GraphCell();
        }
    }
}
