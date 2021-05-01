using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MaMishaVisage.Controls
{
    public class GraphCell : DataGridViewCell
    {
        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            graphics.FillRectangle(Brushes.White, new Rectangle(cellBounds.Left, cellBounds.Top, cellBounds.Width, cellBounds.Height));
            graphics.DrawRectangle(new Pen(Color.FromArgb(0xA0, 0xA0, 0xA0)), new Rectangle(cellBounds.Left - 1, cellBounds.Top - 1, cellBounds.Width + 2, cellBounds.Height));
            var data = (DataRowView)this.DataGridView.Rows[rowIndex].DataBoundItem;
            var operating = (long)data.Row.ItemArray[1];
            var underConstruction = (long)data.Row.ItemArray[2];
            var stopped = (long)data.Row.ItemArray[3];
            var total = operating + underConstruction + stopped;

            if (total > 0)
            {
                var lineLength = cellBounds.Right - cellBounds.Left - 10;
                var plantWeight = lineLength / total;

                var sortedData = new SortedDictionary<long, Brush>()
                {
                    [total] = Brushes.LightGray,
                    [stopped] = Brushes.DarkRed,
                    [underConstruction] = Brushes.DarkGreen,
                    [operating] = Brushes.Blue,
                };

                foreach (var kvp in sortedData.Reverse())
                {
                    graphics.FillRectangle(kvp.Value, cellBounds.Left + 5, cellBounds.Top + 10, kvp.Key * plantWeight, cellBounds.Height - 20);
                }
            }
        }
    }
}
