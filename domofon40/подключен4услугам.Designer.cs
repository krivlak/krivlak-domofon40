namespace domofon40
{
    partial class подключен4услугам
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonЗвонок = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.наименColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.подключенColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.годColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяуColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.догColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.примColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отклColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.повторноColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonЗвонок);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1319, 89);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(458, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 24);
            this.textBox1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "последний звонок";
            // 
            // buttonЗвонок
            // 
            this.buttonЗвонок.AutoSize = true;
            this.buttonЗвонок.Location = new System.Drawing.Point(716, 12);
            this.buttonЗвонок.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonЗвонок.Name = "buttonЗвонок";
            this.buttonЗвонок.Size = new System.Drawing.Size(254, 32);
            this.buttonЗвонок.TabIndex = 10;
            this.buttonЗвонок.Text = "Звонок на";
            this.buttonЗвонок.UseVisualStyleBackColor = true;
            this.buttonЗвонок.Click += new System.EventHandler(this.buttonЗвонок_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(868, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Последний оплаченый месяц";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(40, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 32);
            this.button3.TabIndex = 8;
            this.button3.Text = "Подробности";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.наименColumn,
            this.подключенColumn,
            this.годColumn,
            this.месяуColumn,
            this.догColumn,
            this.сColumn,
            this.примColumn,
            this.отклColumn,
            this.повторноColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 89);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1319, 409);
            this.dataGridView1.TabIndex = 1;
            // 
            // наименColumn
            // 
            this.наименColumn.DataPropertyName = "наимен";
            this.наименColumn.HeaderText = "услуга";
            this.наименColumn.Name = "наименColumn";
            this.наименColumn.ReadOnly = true;
            this.наименColumn.Width = 250;
            // 
            // подключенColumn
            // 
            this.подключенColumn.DataPropertyName = "подключена";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.NullValue = false;
            this.подключенColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.подключенColumn.HeaderText = "подключен";
            this.подключенColumn.Name = "подключенColumn";
            // 
            // годColumn
            // 
            this.годColumn.DataPropertyName = "год";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0;#;#";
            this.годColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.годColumn.HeaderText = "год";
            this.годColumn.Name = "годColumn";
            this.годColumn.ReadOnly = true;
            this.годColumn.Width = 60;
            // 
            // месяуColumn
            // 
            this.месяуColumn.DataPropertyName = "месяц";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0;#;#";
            this.месяуColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.месяуColumn.HeaderText = "месяц";
            this.месяуColumn.Name = "месяуColumn";
            this.месяуColumn.ReadOnly = true;
            this.месяуColumn.Width = 60;
            // 
            // догColumn
            // 
            this.догColumn.DataPropertyName = "номер_пп";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "0;#;#";
            this.догColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.догColumn.HeaderText = "№ дог";
            this.догColumn.Name = "догColumn";
            this.догColumn.ReadOnly = true;
            // 
            // сColumn
            // 
            this.сColumn.DataPropertyName = "от";
            this.сColumn.HeaderText = "с";
            this.сColumn.Name = "сColumn";
            this.сColumn.ReadOnly = true;
            // 
            // примColumn
            // 
            this.примColumn.DataPropertyName = "прим";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.примColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.примColumn.HeaderText = "прим";
            this.примColumn.MaxInputLength = 50;
            this.примColumn.Name = "примColumn";
            this.примColumn.Width = 300;
            // 
            // отклColumn
            // 
            this.отклColumn.DataPropertyName = "откл";
            this.отклColumn.HeaderText = "отключен";
            this.отклColumn.Name = "отклColumn";
            this.отклColumn.ReadOnly = true;
            // 
            // повторноColumn
            // 
            this.повторноColumn.DataPropertyName = "подк";
            this.повторноColumn.HeaderText = "повторно";
            this.повторноColumn.Name = "повторноColumn";
            this.повторноColumn.ReadOnly = true;
            // 
            // подключен4услугам
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 498);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "подключен4услугам";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "подключен4услугам";
            this.Load += new System.EventHandler(this.подключен4услугам_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonЗвонок;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn подключенColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn годColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяуColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn догColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn примColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn отклColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn повторноColumn;
    }
}