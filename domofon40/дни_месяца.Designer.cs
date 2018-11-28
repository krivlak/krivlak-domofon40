namespace domofon40
{
    partial class дни_месяца
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.датаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.догоаорColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.льготаColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.отключенColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.простойColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.оплаченColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.раб_деньColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.номерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дата_сColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дата_откColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дата_повтColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.примColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1531, 41);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(572, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.датаColumn,
            this.догоаорColumn,
            this.льготаColumn,
            this.отключенColumn,
            this.простойColumn,
            this.оплаченColumn,
            this.раб_деньColumn,
            this.номерColumn,
            this.дата_сColumn,
            this.дата_откColumn,
            this.дата_повтColumn1,
            this.примColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 41);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1531, 636);
            this.dataGridView1.TabIndex = 1;
            // 
            // датаColumn
            // 
            this.датаColumn.DataPropertyName = "дата";
            this.датаColumn.HeaderText = "дата";
            this.датаColumn.Name = "датаColumn";
            this.датаColumn.ReadOnly = true;
            // 
            // догоаорColumn
            // 
            this.догоаорColumn.DataPropertyName = "договор";
            this.догоаорColumn.HeaderText = "договор";
            this.догоаорColumn.Name = "догоаорColumn";
            this.догоаорColumn.ReadOnly = true;
            // 
            // льготаColumn
            // 
            this.льготаColumn.DataPropertyName = "льгота";
            this.льготаColumn.HeaderText = "льгота";
            this.льготаColumn.Name = "льготаColumn";
            this.льготаColumn.ReadOnly = true;
            // 
            // отключенColumn
            // 
            this.отключенColumn.DataPropertyName = "отключен";
            this.отключенColumn.HeaderText = "отключен";
            this.отключенColumn.Name = "отключенColumn";
            this.отключенColumn.ReadOnly = true;
            // 
            // простойColumn
            // 
            this.простойColumn.DataPropertyName = "простой";
            this.простойColumn.HeaderText = "простой";
            this.простойColumn.Name = "простойColumn";
            this.простойColumn.ReadOnly = true;
            // 
            // оплаченColumn
            // 
            this.оплаченColumn.DataPropertyName = "оплачен";
            this.оплаченColumn.HeaderText = "оплачено";
            this.оплаченColumn.Name = "оплаченColumn";
            this.оплаченColumn.ReadOnly = true;
            // 
            // раб_деньColumn
            // 
            this.раб_деньColumn.DataPropertyName = "раб_день";
            this.раб_деньColumn.HeaderText = "раб.день";
            this.раб_деньColumn.Name = "раб_деньColumn";
            this.раб_деньColumn.ReadOnly = true;
            // 
            // номерColumn
            // 
            this.номерColumn.DataPropertyName = "номер_дог";
            this.номерColumn.HeaderText = "номер";
            this.номерColumn.Name = "номерColumn";
            this.номерColumn.ReadOnly = true;
            // 
            // дата_сColumn
            // 
            this.дата_сColumn.DataPropertyName = "дата_с";
            this.дата_сColumn.HeaderText = "договор с";
            this.дата_сColumn.Name = "дата_сColumn";
            this.дата_сColumn.ReadOnly = true;
            this.дата_сColumn.Width = 120;
            // 
            // дата_откColumn
            // 
            this.дата_откColumn.DataPropertyName = "дата_отк";
            this.дата_откColumn.HeaderText = "отключено";
            this.дата_откColumn.Name = "дата_откColumn";
            this.дата_откColumn.ReadOnly = true;
            // 
            // дата_повтColumn1
            // 
            this.дата_повтColumn1.DataPropertyName = "дата_повт";
            this.дата_повтColumn1.HeaderText = "повт. подк.";
            this.дата_повтColumn1.Name = "дата_повтColumn1";
            this.дата_повтColumn1.ReadOnly = true;
            // 
            // примColumn
            // 
            this.примColumn.DataPropertyName = "прим";
            this.примColumn.HeaderText = "примечание";
            this.примColumn.Name = "примColumn";
            this.примColumn.ReadOnly = true;
            this.примColumn.Width = 200;
            // 
            // дни_месяца
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 677);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "дни_месяца";
            this.Text = "дни_месяца";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.дни_месяца_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn догоаорColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn льготаColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn отключенColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn простойColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn оплаченColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn раб_деньColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дата_сColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дата_откColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дата_повтColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn примColumn;
    }
}