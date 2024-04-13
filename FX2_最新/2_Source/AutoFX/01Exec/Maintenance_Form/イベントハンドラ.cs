using System.Drawing;
using System.Windows.Forms;

namespace Maintenance_Form
{
    public class イベントハンドラ
    {
        public void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.RowHeadersVisible)
            {
                //行番号を描画する範囲を決定する
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);

                //行番号を描画する
                TextRenderer.DrawText(e.Graphics,
                    (e.RowIndex + 1).ToString(),
                    e.InheritedRowStyle.Font,
                    rect,
                    e.InheritedRowStyle.ForeColor,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
