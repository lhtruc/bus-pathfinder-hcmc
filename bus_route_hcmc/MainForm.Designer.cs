namespace FINAL_PROJECT_GRAPH_THEORY
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mapPN = new System.Windows.Forms.Panel();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.showBT = new System.Windows.Forms.Button();
            this.pathInformationLB = new System.Windows.Forms.Label();
            this.endCB = new System.Windows.Forms.ComboBox();
            this.startLB = new System.Windows.Forms.Label();
            this.endLB = new System.Windows.Forms.Label();
            this.startCB = new System.Windows.Forms.ComboBox();
            this.functionGB = new System.Windows.Forms.GroupBox();
            this.clearBT = new System.Windows.Forms.Button();
            this.pathInformationGB = new System.Windows.Forms.GroupBox();
            this.showBusRouteBT = new System.Windows.Forms.Button();
            this.busRouteTB = new System.Windows.Forms.TextBox();
            this.infoPN = new System.Windows.Forms.Panel();
            this.topPN = new System.Windows.Forms.Panel();
            this.minimizePIC = new System.Windows.Forms.PictureBox();
            this.closePIC = new System.Windows.Forms.PictureBox();
            this.mapPN.SuspendLayout();
            this.functionGB.SuspendLayout();
            this.pathInformationGB.SuspendLayout();
            this.infoPN.SuspendLayout();
            this.topPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizePIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePIC)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPN
            // 
            this.mapPN.Controls.Add(this.gMapControl1);
            this.mapPN.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapPN.Location = new System.Drawing.Point(3, 119);
            this.mapPN.Name = "mapPN";
            this.mapPN.Size = new System.Drawing.Size(1042, 618);
            this.mapPN.TabIndex = 2;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(3, 3);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1036, 615);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // showBT
            // 
            this.showBT.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBT.Location = new System.Drawing.Point(729, 42);
            this.showBT.Name = "showBT";
            this.showBT.Size = new System.Drawing.Size(152, 30);
            this.showBT.TabIndex = 0;
            this.showBT.Text = "SHOW";
            this.showBT.UseVisualStyleBackColor = true;
            this.showBT.Click += new System.EventHandler(this.showBT_Click);
            // 
            // pathInformationLB
            // 
            this.pathInformationLB.AutoSize = true;
            this.pathInformationLB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathInformationLB.Location = new System.Drawing.Point(3, 4);
            this.pathInformationLB.Name = "pathInformationLB";
            this.pathInformationLB.Size = new System.Drawing.Size(0, 20);
            this.pathInformationLB.TabIndex = 1;
            // 
            // endCB
            // 
            this.endCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.endCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.endCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endCB.FormattingEnabled = true;
            this.endCB.Location = new System.Drawing.Point(372, 44);
            this.endCB.Name = "endCB";
            this.endCB.Size = new System.Drawing.Size(351, 28);
            this.endCB.TabIndex = 3;
            // 
            // startLB
            // 
            this.startLB.AutoSize = true;
            this.startLB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLB.Location = new System.Drawing.Point(6, 24);
            this.startLB.Name = "startLB";
            this.startLB.Size = new System.Drawing.Size(115, 20);
            this.startLB.TabIndex = 4;
            this.startLB.Text = "Starting Station:";
            // 
            // endLB
            // 
            this.endLB.AutoSize = true;
            this.endLB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endLB.Location = new System.Drawing.Point(368, 23);
            this.endLB.Name = "endLB";
            this.endLB.Size = new System.Drawing.Size(88, 20);
            this.endLB.TabIndex = 5;
            this.endLB.Text = "Destination:";
            // 
            // startCB
            // 
            this.startCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.startCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.startCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startCB.FormattingEnabled = true;
            this.startCB.Location = new System.Drawing.Point(10, 44);
            this.startCB.Name = "startCB";
            this.startCB.Size = new System.Drawing.Size(351, 28);
            this.startCB.TabIndex = 6;
            // 
            // functionGB
            // 
            this.functionGB.BackColor = System.Drawing.Color.White;
            this.functionGB.Controls.Add(this.clearBT);
            this.functionGB.Controls.Add(this.showBT);
            this.functionGB.Controls.Add(this.startCB);
            this.functionGB.Controls.Add(this.endCB);
            this.functionGB.Controls.Add(this.startLB);
            this.functionGB.Controls.Add(this.endLB);
            this.functionGB.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.functionGB.Location = new System.Drawing.Point(3, 36);
            this.functionGB.Name = "functionGB";
            this.functionGB.Size = new System.Drawing.Size(1042, 80);
            this.functionGB.TabIndex = 2;
            this.functionGB.TabStop = false;
            this.functionGB.Text = "Choose Station:";
            // 
            // clearBT
            // 
            this.clearBT.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBT.Location = new System.Drawing.Point(887, 42);
            this.clearBT.Name = "clearBT";
            this.clearBT.Size = new System.Drawing.Size(149, 30);
            this.clearBT.TabIndex = 7;
            this.clearBT.Text = "CLEAR";
            this.clearBT.UseVisualStyleBackColor = true;
            this.clearBT.Click += new System.EventHandler(this.clearBT_Click);
            // 
            // pathInformationGB
            // 
            this.pathInformationGB.Controls.Add(this.showBusRouteBT);
            this.pathInformationGB.Controls.Add(this.busRouteTB);
            this.pathInformationGB.Controls.Add(this.infoPN);
            this.pathInformationGB.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathInformationGB.Location = new System.Drawing.Point(1051, 36);
            this.pathInformationGB.Name = "pathInformationGB";
            this.pathInformationGB.Size = new System.Drawing.Size(323, 701);
            this.pathInformationGB.TabIndex = 3;
            this.pathInformationGB.TabStop = false;
            this.pathInformationGB.Text = "Path:";
            // 
            // showBusRouteBT
            // 
            this.showBusRouteBT.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBusRouteBT.Location = new System.Drawing.Point(239, 665);
            this.showBusRouteBT.Name = "showBusRouteBT";
            this.showBusRouteBT.Size = new System.Drawing.Size(78, 30);
            this.showBusRouteBT.TabIndex = 9;
            this.showBusRouteBT.Text = "OK";
            this.showBusRouteBT.UseVisualStyleBackColor = true;
            this.showBusRouteBT.Click += new System.EventHandler(this.showBusRouteBT_Click);
            // 
            // busRouteTB
            // 
            this.busRouteTB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busRouteTB.Location = new System.Drawing.Point(6, 667);
            this.busRouteTB.Name = "busRouteTB";
            this.busRouteTB.Size = new System.Drawing.Size(227, 27);
            this.busRouteTB.TabIndex = 8;
            this.busRouteTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.busRouteTB.Enter += new System.EventHandler(this.busRouteTB_Enter);
            this.busRouteTB.Leave += new System.EventHandler(this.busRouteTB_Leave);
            // 
            // infoPN
            // 
            this.infoPN.AutoScroll = true;
            this.infoPN.Controls.Add(this.pathInformationLB);
            this.infoPN.Location = new System.Drawing.Point(6, 20);
            this.infoPN.Name = "infoPN";
            this.infoPN.Size = new System.Drawing.Size(311, 641);
            this.infoPN.TabIndex = 0;
            // 
            // topPN
            // 
            this.topPN.BackColor = System.Drawing.Color.Azure;
            this.topPN.Controls.Add(this.minimizePIC);
            this.topPN.Controls.Add(this.closePIC);
            this.topPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPN.Location = new System.Drawing.Point(0, 0);
            this.topPN.Name = "topPN";
            this.topPN.Size = new System.Drawing.Size(1386, 33);
            this.topPN.TabIndex = 4;
            this.topPN.Paint += new System.Windows.Forms.PaintEventHandler(this.topPN_Paint);
            this.topPN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPN_MouseDown);
            this.topPN.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPN_MouseMove);
            this.topPN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topPN_MouseUp);
            // 
            // minimizePIC
            // 
            this.minimizePIC.Image = ((System.Drawing.Image)(resources.GetObject("minimizePIC.Image")));
            this.minimizePIC.Location = new System.Drawing.Point(36, 0);
            this.minimizePIC.Name = "minimizePIC";
            this.minimizePIC.Size = new System.Drawing.Size(30, 30);
            this.minimizePIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minimizePIC.TabIndex = 3;
            this.minimizePIC.TabStop = false;
            this.minimizePIC.Click += new System.EventHandler(this.minimizePIC_Click);
            // 
            // closePIC
            // 
            this.closePIC.Image = ((System.Drawing.Image)(resources.GetObject("closePIC.Image")));
            this.closePIC.Location = new System.Drawing.Point(0, 0);
            this.closePIC.Name = "closePIC";
            this.closePIC.Size = new System.Drawing.Size(30, 30);
            this.closePIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.closePIC.TabIndex = 1;
            this.closePIC.TabStop = false;
            this.closePIC.Click += new System.EventHandler(this.closePIC_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1386, 743);
            this.Controls.Add(this.topPN);
            this.Controls.Add(this.pathInformationGB);
            this.Controls.Add(this.functionGB);
            this.Controls.Add(this.mapPN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mapPN.ResumeLayout(false);
            this.functionGB.ResumeLayout(false);
            this.functionGB.PerformLayout();
            this.pathInformationGB.ResumeLayout(false);
            this.pathInformationGB.PerformLayout();
            this.infoPN.ResumeLayout(false);
            this.infoPN.PerformLayout();
            this.topPN.ResumeLayout(false);
            this.topPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizePIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePIC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mapPN;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button showBT;
        private System.Windows.Forms.Label pathInformationLB;
        private System.Windows.Forms.ComboBox endCB;
        private System.Windows.Forms.Label startLB;
        private System.Windows.Forms.Label endLB;
        private System.Windows.Forms.ComboBox startCB;
        private System.Windows.Forms.GroupBox functionGB;
        private System.Windows.Forms.GroupBox pathInformationGB;
        private System.Windows.Forms.Panel topPN;
        private System.Windows.Forms.PictureBox closePIC;
        private System.Windows.Forms.PictureBox minimizePIC;
        private System.Windows.Forms.Button clearBT;
        private System.Windows.Forms.Panel infoPN;
        private System.Windows.Forms.TextBox busRouteTB;
        private System.Windows.Forms.Button showBusRouteBT;
    }
}

