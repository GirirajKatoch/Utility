using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utility.Windows.Forms
{
    public class ToolStripTextBox : System.Windows.Forms.ToolStripTextBox
    {
        public string WatermarkText
        {
            get;
            set;
        }

        public Color WatermarkForeColor
        {
            get;
            set;
        }

        public Font WatermarkFont
        {
            get;
            set;
        }

        private Color RegularForeColor
        {
            get;
            set;
        }
        private Font RegularFont
        {
            get;
            set;
        }

        public ToolStripTextBox()
            : base()
        {
            if (!this.DesignMode)
            {
                this.RegularFont = this.Font;
                this.RegularForeColor = this.ForeColor;

                this.LostFocus += new EventHandler(TerrificToolStripTextBox_LostFocus);
                this.MouseDown += new MouseEventHandler(TerrificToolStripTextBox_MouseDown);
                this.Paint += new PaintEventHandler(TerrificToolStripTextBox_Paint);
            }
        }

        private bool HasBeenPainted = false;

        void TerrificToolStripTextBox_Paint(object sender, PaintEventArgs e)
        {
            if (!this.HasBeenPainted)
            {
                this.SetToDefault();
                this.HasBeenPainted = true;
            }
        }

        void TerrificToolStripTextBox_LostFocus(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.WatermarkText))
            {
                this.SetToDefault();
            }
        }

        void TerrificToolStripTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.WatermarkText))
            {
                if (this.WatermarkText == this.Text)
                {
                    this.SetToEdit();
                }
            }
        }

        public void SetToDefault()
        {
            if (!this.DesignMode)
            {
                this.Text = this.WatermarkText;

                this.RegularFont = this.Font;
                this.RegularForeColor = this.ForeColor;

                this.ForeColor = this.WatermarkForeColor.IsEmpty ? this.ForeColor : this.WatermarkForeColor;
                this.Font = this.WatermarkFont ?? this.Font;
            }
        }

        protected void SetToEdit()
        {
            if (!this.DesignMode)
            {
                this.Text = String.Empty;
                this.ForeColor = this.RegularForeColor;
                this.Font = this.RegularFont;
            }
        }
    }
}
