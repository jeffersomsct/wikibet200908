namespace demo
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.GV_ACCOUNT = new System.Windows.Forms.DataGridView();
            this.ISHave = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BackLay = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Typeclass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Freebet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Han = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Odds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ints = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CM_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GV_ACCOUNT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // GV_ACCOUNT
            // 
            this.GV_ACCOUNT.AllowDrop = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            this.GV_ACCOUNT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GV_ACCOUNT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV_ACCOUNT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISHave,
            this.BackLay,
            this.Typeclass,
            this.Freebet,
            this.Han,
            this.Odds,
            this.Ints,
            this.Fee,
            this.AMT,
            this.CM_MAX});
            this.GV_ACCOUNT.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.GV_ACCOUNT.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GV_ACCOUNT.Location = new System.Drawing.Point(12, 24);
            this.GV_ACCOUNT.Name = "GV_ACCOUNT";
            this.GV_ACCOUNT.RowHeadersWidth = 10;
            this.GV_ACCOUNT.RowTemplate.Height = 24;
            this.GV_ACCOUNT.Size = new System.Drawing.Size(512, 188);
            this.GV_ACCOUNT.TabIndex = 4;
            // 
            // ISHave
            // 
            this.ISHave.Frozen = true;
            this.ISHave.HeaderText = "Has";
            this.ISHave.Name = "ISHave";
            this.ISHave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ISHave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ISHave.Width = 25;
            // 
            // BackLay
            // 
            this.BackLay.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.BackLay.DisplayStyleForCurrentCellOnly = true;
            this.BackLay.Frozen = true;
            this.BackLay.HeaderText = "Back/Lay";
            this.BackLay.Items.AddRange(new object[] {
            "Back",
            "Lay"});
            this.BackLay.Name = "BackLay";
            this.BackLay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BackLay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BackLay.Width = 52;
            // 
            // Typeclass
            // 
            this.Typeclass.DisplayStyleForCurrentCellOnly = true;
            this.Typeclass.HeaderText = "Type";
            this.Typeclass.Items.AddRange(new object[] {
            "EH1",
            "EH2",
            "EHX",
            "Over",
            "S1",
            "S2",
            "Under",
            "Win1",
            "Win2",
            "X"});
            this.Typeclass.Name = "Typeclass";
            this.Typeclass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Typeclass.Sorted = true;
            this.Typeclass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Typeclass.Width = 52;
            // 
            // Freebet
            // 
            this.Freebet.HeaderText = "Freebet";
            this.Freebet.Name = "Freebet";
            this.Freebet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Freebet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Han
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Han.DefaultCellStyle = dataGridViewCellStyle2;
            this.Han.HeaderText = "Han.";
            this.Han.Name = "Han";
            this.Han.Width = 30;
            // 
            // Odds
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Odds.DefaultCellStyle = dataGridViewCellStyle3;
            this.Odds.HeaderText = "Odds";
            this.Odds.Name = "Odds";
            this.Odds.Width = 35;
            // 
            // Ints
            // 
            this.Ints.HeaderText = "Int.";
            this.Ints.Name = "Ints";
            this.Ints.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ints.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ints.Width = 25;
            // 
            // Fee
            // 
            this.Fee.HeaderText = "Fee%";
            this.Fee.Name = "Fee";
            this.Fee.Width = 35;
            // 
            // AMT
            // 
            this.AMT.HeaderText = "Amt";
            this.AMT.Name = "AMT";
            this.AMT.Width = 35;
            // 
            // CM_MAX
            // 
            this.CM_MAX.HeaderText = "MAX";
            this.CM_MAX.Name = "CM_MAX";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 237);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 64);
            this.textBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 439);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GV_ACCOUNT);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GV_ACCOUNT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView GV_ACCOUNT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ISHave;
        private System.Windows.Forms.DataGridViewComboBoxColumn BackLay;
        private System.Windows.Forms.DataGridViewComboBoxColumn Typeclass;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Freebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Han;
        private System.Windows.Forms.DataGridViewTextBoxColumn Odds;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ints;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CM_MAX;

    }
}