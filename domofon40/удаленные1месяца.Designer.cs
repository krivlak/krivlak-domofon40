namespace domofon40
{
    partial class удаленные1месяца
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.датаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.абонентColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.менеджерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.услугаColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.годColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяцColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 44);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(809, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.датаColumn,
            this.номерColumn,
            this.абонентColumn,
            this.менеджерColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(573, 499);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.датаColumn2,
            this.услугаColumn2,
            this.годColumn2,
            this.месяцColumn2,
            this.суммаColumn2});
            this.dataGridView2.DataSource = this.bindingSource2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView2.Location = new System.Drawing.Point(573, 44);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(543, 499);
            this.dataGridView2.TabIndex = 2;
            // 
            // датаColumn
            // 
            this.датаColumn.DataPropertyName = "дата";
            this.датаColumn.HeaderText = "дата";
            this.датаColumn.Name = "датаColumn";
            this.датаColumn.ReadOnly = true;
            this.датаColumn.Width = 80;
            // 
            // номерColumn
            // 
            this.номерColumn.DataPropertyName = "номер";
            this.номерColumn.HeaderText = "номер";
            this.номерColumn.Name = "номерColumn";
            this.номерColumn.ReadOnly = true;
            // 
            // абонентColumn
            // 
            this.абонентColumn.DataPropertyName = "абонент";
            this.абонентColumn.HeaderText = "абонент";
            this.абонентColumn.Name = "абонентColumn";
            this.абонентColumn.ReadOnly = true;
            this.абонентColumn.Width = 150;
            // 
            // менеджерColumn
            // 
            this.менеджерColumn.DataPropertyName = "менеджер";
            this.менеджерColumn.HeaderText = "менеджер";
            this.менеджерColumn.Name = "менеджерColumn";
            this.менеджерColumn.ReadOnly = true;
            this.менеджерColumn.Width = 150;
            // 
            // датаColumn2
            // 
            this.датаColumn2.DataPropertyName = "дата";
            this.датаColumn2.HeaderText = "дата";
            this.датаColumn2.Name = "датаColumn2";
            this.датаColumn2.ReadOnly = true;
            // 
            // услугаColumn2
            // 
            this.услугаColumn2.DataPropertyName = "наимен";
            this.услугаColumn2.HeaderText = "услуга";
            this.услугаColumn2.Name = "услугаColumn2";
            this.услугаColumn2.ReadOnly = true;
            this.услугаColumn2.Width = 120;
            // 
            // годColumn2
            // 
            this.годColumn2.DataPropertyName = "год";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0;#;#";
            this.годColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.годColumn2.HeaderText = "год";
            this.годColumn2.Name = "годColumn2";
            this.годColumn2.ReadOnly = true;
            this.годColumn2.Width = 80;
            // 
            // месяцColumn2
            // 
            this.месяцColumn2.DataPropertyName = "месяц";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0;#;#";
            this.месяцColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.месяцColumn2.HeaderText = "месяц";
            this.месяцColumn2.Name = "месяцColumn2";
            this.месяцColumn2.ReadOnly = true;
            this.месяцColumn2.Width = 60;
            // 
            // суммаColumn2
            // 
            this.суммаColumn2.DataPropertyName = "сумма";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "0;#;#";
            this.суммаColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.суммаColumn2.HeaderText = "сумма";
            this.суммаColumn2.Name = "суммаColumn2";
            this.суммаColumn2.ReadOnly = true;
            this.суммаColumn2.Width = 80;
            // 
            // удаленные1месяца
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 543);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "удаленные1месяца";
            this.Text = "удаленные1месяца";
            this.Load += new System.EventHandler(this.удаленные1месяца_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn абонентColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn менеджерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn услугаColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn годColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяцColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаColumn2;
    }
}