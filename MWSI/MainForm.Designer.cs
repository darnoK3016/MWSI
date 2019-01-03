namespace MWSI
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenCADRGFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CADRGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpacityScrollBar = new System.Windows.Forms.HScrollBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.LayersPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckedListBoxMaps = new System.Windows.Forms.CheckedListBox();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.OpacityLabel = new System.Windows.Forms.Label();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.WarstwyMapyLayer = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.LayersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenCADRGFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenCADRGFileToolStripMenuItem
            // 
            this.OpenCADRGFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.OpenCADRGFileToolStripMenuItem.Name = "OpenCADRGFileToolStripMenuItem";
            this.OpenCADRGFileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.OpenCADRGFileToolStripMenuItem.Text = "File";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CADRGToolStripMenuItem});
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            // 
            // CADRGToolStripMenuItem
            // 
            this.CADRGToolStripMenuItem.Name = "CADRGToolStripMenuItem";
            this.CADRGToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.CADRGToolStripMenuItem.Text = "CADRG";
            this.CADRGToolStripMenuItem.Click += new System.EventHandler(this.CADRGToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // OpacityScrollBar
            // 
            this.OpacityScrollBar.Enabled = false;
            this.OpacityScrollBar.LargeChange = 1;
            this.OpacityScrollBar.Location = new System.Drawing.Point(406, 193);
            this.OpacityScrollBar.Name = "OpacityScrollBar";
            this.OpacityScrollBar.Size = new System.Drawing.Size(281, 16);
            this.OpacityScrollBar.TabIndex = 0;
            this.OpacityScrollBar.Value = 100;
            this.OpacityScrollBar.ValueChanged += new System.EventHandler(this.OpacityScrollBar_ValueChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // LayersPanel
            // 
            this.LayersPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayersPanel.Controls.Add(this.panel1);
            this.LayersPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LayersPanel.Location = new System.Drawing.Point(0, 24);
            this.LayersPanel.Name = "LayersPanel";
            this.LayersPanel.Size = new System.Drawing.Size(400, 400);
            this.LayersPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(399, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 436);
            this.panel1.TabIndex = 8;
            // 
            // CheckedListBoxMaps
            // 
            this.CheckedListBoxMaps.BackColor = System.Drawing.SystemColors.Control;
            this.CheckedListBoxMaps.FormattingEnabled = true;
            this.CheckedListBoxMaps.Location = new System.Drawing.Point(406, 40);
            this.CheckedListBoxMaps.Name = "CheckedListBoxMaps";
            this.CheckedListBoxMaps.Size = new System.Drawing.Size(281, 109);
            this.CheckedListBoxMaps.TabIndex = 3;
            this.CheckedListBoxMaps.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxMaps_ItemCheck);
            this.CheckedListBoxMaps.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxMaps_SelectedIndexChanged);
            // 
            // ButtonUp
            // 
            this.ButtonUp.Enabled = false;
            this.ButtonUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ButtonUp.Location = new System.Drawing.Point(406, 154);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonUp.Size = new System.Drawing.Size(140, 23);
            this.ButtonUp.TabIndex = 4;
            this.ButtonUp.Text = "▲";
            this.ButtonUp.UseVisualStyleBackColor = true;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // ButtonDown
            // 
            this.ButtonDown.Enabled = false;
            this.ButtonDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ButtonDown.Location = new System.Drawing.Point(547, 154);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(140, 23);
            this.ButtonDown.TabIndex = 5;
            this.ButtonDown.Text = "▼";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // OpacityLabel
            // 
            this.OpacityLabel.AutoSize = true;
            this.OpacityLabel.BackColor = System.Drawing.SystemColors.Control;
            this.OpacityLabel.Location = new System.Drawing.Point(406, 180);
            this.OpacityLabel.Name = "OpacityLabel";
            this.OpacityLabel.Size = new System.Drawing.Size(49, 13);
            this.OpacityLabel.TabIndex = 6;
            this.OpacityLabel.Text = "Opacity: ";
            this.OpacityLabel.Visible = false;
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.Location = new System.Drawing.Point(406, 401);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(281, 23);
            this.ButtonRefresh.TabIndex = 7;
            this.ButtonRefresh.Text = "Refresh";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // WarstwyMapyLayer
            // 
            this.WarstwyMapyLayer.AutoSize = true;
            this.WarstwyMapyLayer.Location = new System.Drawing.Point(406, 24);
            this.WarstwyMapyLayer.Name = "WarstwyMapyLayer";
            this.WarstwyMapyLayer.Size = new System.Drawing.Size(79, 13);
            this.WarstwyMapyLayer.TabIndex = 8;
            this.WarstwyMapyLayer.Text = "Warstwy mapy:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(693, 424);
            this.Controls.Add(this.WarstwyMapyLayer);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.OpacityLabel);
            this.Controls.Add(this.ButtonDown);
            this.Controls.Add(this.ButtonUp);
            this.Controls.Add(this.CheckedListBoxMaps);
            this.Controls.Add(this.LayersPanel);
            this.Controls.Add(this.OpacityScrollBar);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(309, 463);
            this.Name = "MainForm";
            this.Text = "MWSI";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.LayersPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenCADRGFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CADRGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.HScrollBar OpacityScrollBar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel LayersPanel;
        private System.Windows.Forms.CheckedListBox CheckedListBoxMaps;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Label OpacityLabel;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label WarstwyMapyLayer;
    }
}

