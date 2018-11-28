namespace domofon40
{
    partial class ввод_разрешений
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.фиоColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.квартираColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.корпусColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.домColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сведенияColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.тефонColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.договор_сColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.звонокColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.подклColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.вводColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // фиоColumn
            // 
            this.фиоColumn.DataPropertyName = "фио";
            this.фиоColumn.HeaderText = "фио";
            this.фиоColumn.Name = "фиоColumn";
            this.фиоColumn.ReadOnly = true;
            this.фиоColumn.Width = 150;
            // 
            // квартираColumn
            // 
            this.квартираColumn.DataPropertyName = "квартира";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "0;#;#";
            this.квартираColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.квартираColumn.HeaderText = "квартира";
            this.квартираColumn.Name = "квартираColumn";
            this.квартираColumn.ReadOnly = true;
            this.квартираColumn.Width = 40;
            // 
            // корпусColumn
            // 
            this.корпусColumn.DataPropertyName = "корпус";
            this.корпусColumn.HeaderText = "корпус";
            this.корпусColumn.Name = "корпусColumn";
            this.корпусColumn.Width = 50;
            // 
            // домColumn
            // 
            this.домColumn.DataPropertyName = "номер_дома";
            this.домColumn.HeaderText = "дом";
            this.домColumn.Name = "домColumn";
            this.домColumn.Width = 50;
            // 
            // idColumn
            // 
            this.idColumn.DataPropertyName = "наимен_улицы";
            this.idColumn.HeaderText = "улица";
            this.idColumn.Name = "idColumn";
            this.idColumn.Width = 150;
            // 
            // сведенияColumn
            // 
            this.сведенияColumn.DataPropertyName = "эл_почта";
            this.сведенияColumn.HeaderText = "эл. почта";
            this.сведенияColumn.Name = "сведенияColumn";
            this.сведенияColumn.ReadOnly = true;
            this.сведенияColumn.Width = 200;
            // 
            // тефонColumn
            // 
            this.тефонColumn.DataPropertyName = "телефон";
            this.тефонColumn.HeaderText = "телефон";
            this.тефонColumn.Name = "тефонColumn";
            this.тефонColumn.Width = 200;
            // 
            // договор_сColumn
            // 
            this.договор_сColumn.DataPropertyName = "дата_по";
            this.договор_сColumn.HeaderText = "дата по";
            this.договор_сColumn.Name = "договор_сColumn";
            this.договор_сColumn.ReadOnly = true;
            this.договор_сColumn.Visible = false;
            // 
            // звонокColumn
            // 
            this.звонокColumn.DataPropertyName = "дата_с";
            this.звонокColumn.HeaderText = "дата  с";
            this.звонокColumn.Name = "звонокColumn";
            // 
            // подклColumn
            // 
            this.подклColumn.DataPropertyName = "номер";
            this.подклColumn.HeaderText = "номер";
            this.подклColumn.Name = "подклColumn";
            this.подклColumn.ReadOnly = true;
            this.подклColumn.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(874, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "поиск по фамилии";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1007, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 22);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(642, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 24);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(522, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Word";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(329, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "изменить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Новое разрешение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1222, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1636, 44);
            this.panel1.TabIndex = 11;
            // 
            // вводColumn
            // 
            this.вводColumn.DataPropertyName = "ввод";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "0;#;#";
            this.вводColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.вводColumn.HeaderText = "ввод";
            this.вводColumn.Name = "вводColumn";
            this.вводColumn.ReadOnly = true;
            this.вводColumn.Width = 30;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.подклColumn,
            this.звонокColumn,
            this.договор_сColumn,
            this.тефонColumn,
            this.сведенияColumn,
            this.idColumn,
            this.домColumn,
            this.корпусColumn,
            this.квартираColumn,
            this.вводColumn,
            this.фиоColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1636, 743);
            this.dataGridView1.TabIndex = 12;
            // 
            // ввод_разрешений
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1636, 787);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "ввод_разрешений";
            this.Text = "ввод_разрешений";
            this.Load += new System.EventHandler(this.ввод_разрешений_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn фиоColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn квартираColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn корпусColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn домColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сведенияColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn тефонColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn договор_сColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn звонокColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn подклColumn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn вводColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}