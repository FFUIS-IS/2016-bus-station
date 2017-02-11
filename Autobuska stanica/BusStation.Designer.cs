namespace Autobuska_stanica
{
    partial class Bus_station
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bus_station));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.linessOfTransportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carrierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pricelistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linessOfTransportToolStripMenuItem,
            this.carrierToolStripMenuItem,
            this.workersToolStripMenuItem,
            this.pricelistToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // linessOfTransportToolStripMenuItem
            // 
            this.linessOfTransportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledToolStripMenuItem,
            this.unosToolStripMenuItem});
            this.linessOfTransportToolStripMenuItem.Name = "linessOfTransportToolStripMenuItem";
            this.linessOfTransportToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.linessOfTransportToolStripMenuItem.Text = "Liness of transport";
            // 
            // pregledToolStripMenuItem
            // 
            this.pregledToolStripMenuItem.Name = "pregledToolStripMenuItem";
            this.pregledToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.pregledToolStripMenuItem.Text = "Information";
            this.pregledToolStripMenuItem.Click += new System.EventHandler(this.pregledToolStripMenuItem_Click);
            // 
            // unosToolStripMenuItem
            // 
            this.unosToolStripMenuItem.Name = "unosToolStripMenuItem";
            this.unosToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.unosToolStripMenuItem.Text = "Data entry";
            this.unosToolStripMenuItem.Click += new System.EventHandler(this.unosToolStripMenuItem_Click);
            // 
            // carrierToolStripMenuItem
            // 
            this.carrierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unosToolStripMenuItem1,
            this.pregledToolStripMenuItem1});
            this.carrierToolStripMenuItem.Name = "carrierToolStripMenuItem";
            this.carrierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.carrierToolStripMenuItem.Text = "Carrier";
            // 
            // unosToolStripMenuItem1
            // 
            this.unosToolStripMenuItem1.Name = "unosToolStripMenuItem1";
            this.unosToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.unosToolStripMenuItem1.Text = "Data entry";
            this.unosToolStripMenuItem1.Click += new System.EventHandler(this.unosToolStripMenuItem1_Click);
            // 
            // pregledToolStripMenuItem1
            // 
            this.pregledToolStripMenuItem1.Name = "pregledToolStripMenuItem1";
            this.pregledToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.pregledToolStripMenuItem1.Text = "Information";
            this.pregledToolStripMenuItem1.Click += new System.EventHandler(this.pregledToolStripMenuItem1_Click);
            // 
            // workersToolStripMenuItem
            // 
            this.workersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataEntryToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.workersToolStripMenuItem.Name = "workersToolStripMenuItem";
            this.workersToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.workersToolStripMenuItem.Text = "Workers";
            // 
            // dataEntryToolStripMenuItem
            // 
            this.dataEntryToolStripMenuItem.Name = "dataEntryToolStripMenuItem";
            this.dataEntryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dataEntryToolStripMenuItem.Text = "Data entry";
            this.dataEntryToolStripMenuItem.Click += new System.EventHandler(this.dataEntryToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.informationToolStripMenuItem.Text = "Information";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // pricelistToolStripMenuItem
            // 
            this.pricelistToolStripMenuItem.Name = "pricelistToolStripMenuItem";
            this.pricelistToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.pricelistToolStripMenuItem.Text = "Price_list";
            // 
            // Bus_station
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(669, 532);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Bus_station";
            this.Text = "Bus station";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem linessOfTransportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carrierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem workersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pricelistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

