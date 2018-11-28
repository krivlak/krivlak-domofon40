namespace domofon40
{
    partial class удаленные_оплаты
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.наименColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.годColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяцColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.удаленаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.абонентColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.менеджерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.наименColumn,
            this.годColumn,
            this.месяцColumn,
            this.суммаColumn});
            this.dataGridView2.DataSource = this.bindingSource2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView2.Location = new System.Drawing.Point(651, 49);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(525, 526);
            this.dataGridView2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.удаленаColumn,
            this.номерColumn,
            this.датаColumn,
            this.абонентColumn,
            this.менеджерColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(651, 526);
            this.dataGridView1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 49);
            this.panel1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(511, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Все ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(361, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Поиск клиента";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1039, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // наименColumn
            // 
            this.наименColumn.DataPropertyName = "наимен";
            this.наименColumn.HeaderText = "услуга";
            this.наименColumn.Name = "наименColumn";
            this.наименColumn.ReadOnly = true;
            this.наименColumn.Width = 200;
            // 
            // годColumn
            // 
            this.годColumn.DataPropertyName = "год";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0;#;#";
            this.годColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.годColumn.HeaderText = "год";
            this.годColumn.Name = "годColumn";
            this.годColumn.ReadOnly = true;
            this.годColumn.Width = 80;
            // 
            // месяцColumn
            // 
            this.месяцColumn.DataPropertyName = "месяц";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0;#;#";
            this.месяцColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.месяцColumn.HeaderText = "месяц";
            this.месяцColumn.Name = "месяцColumn";
            this.месяцColumn.ReadOnly = true;
            this.месяцColumn.Width = 80;
            // 
            // суммаColumn
            // 
            this.суммаColumn.DataPropertyName = "сумма";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0;#;#";
            this.суммаColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.суммаColumn.HeaderText = "сумма";
            this.суммаColumn.Name = "суммаColumn";
            this.суммаColumn.ReadOnly = true;
            // 
            // удаленаColumn
            // 
            this.удаленаColumn.DataPropertyName = "удалена";
            this.удаленаColumn.HeaderText = "удалена";
            this.удаленаColumn.Name = "удаленаColumn";
            this.удаленаColumn.ReadOnly = true;
            // 
            // номерColumn
            // 
            this.номерColumn.DataPropertyName = "номер";
            this.номерColumn.HeaderText = "номер";
            this.номерColumn.Name = "номерColumn";
            this.номерColumn.ReadOnly = true;
            this.номерColumn.Width = 80;
            // 
            // датаColumn
            // 
            this.датаColumn.DataPropertyName = "дата";
            this.датаColumn.HeaderText = "дата";
            this.датаColumn.Name = "датаColumn";
            this.датаColumn.ReadOnly = true;
            this.датаColumn.Width = 80;
            // 
            // абонентColumn
            // 
            this.абонентColumn.DataPropertyName = "абонент";
            this.абонентColumn.FillWeight = 150F;
            this.абонентColumn.HeaderText = "абонент";
            this.абонентColumn.Name = "абонентColumn";
            this.абонентColumn.ReadOnly = true;
            this.абонентColumn.Width = 150;
            // 
            // менеджерColumn
            // 
            this.менеджерColumn.DataPropertyName = "менеджер";
            this.менеджерColumn.FillWeight = 150F;
            this.менеджерColumn.HeaderText = "менеджер";
            this.менеджерColumn.Name = "менеджерColumn";
            this.менеджерColumn.ReadOnly = true;
            this.менеджерColumn.Width = 150;
            // 
            // удаленные_оплаты
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 575);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "удаленные_оплаты";
            this.Text = "удаленные_оплаты";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.удаленные_оплаты_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn годColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяцColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn удаленаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn абонентColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn менеджерColumn;
    }
}