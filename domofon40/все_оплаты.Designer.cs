namespace domofon40
{
    partial class все_оплаты
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.наименColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяцевColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.договорColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.номерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.адресColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фиоColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.менеджерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.вид_оплатыColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерColumn,
            this.датаColumn,
            this.адресColumn,
            this.фиоColumn,
            this.суммаColumn,
            this.менеджерColumn,
            this.вид_оплатыColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 156);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1395, 440);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.VirtualMode = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1395, 156);
            this.panel1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(834, 62);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 23);
            this.button4.TabIndex = 80;
            this.button4.Text = "Оплата услуг";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.Blue;
            this.button3.Location = new System.Drawing.Point(834, 13);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 29);
            this.button3.TabIndex = 79;
            this.button3.Text = "Выход ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.наименColumn,
            this.месяцевColumn,
            this.dataGridViewTextBoxColumn1,
            this.договорColumn});
            this.dataGridView2.DataSource = this.bindingSource2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(795, 156);
            this.dataGridView2.TabIndex = 28;
            // 
            // наименColumn
            // 
            this.наименColumn.DataPropertyName = "наимен";
            this.наименColumn.HeaderText = "наимен";
            this.наименColumn.Name = "наименColumn";
            this.наименColumn.ReadOnly = true;
            this.наименColumn.Width = 350;
            // 
            // месяцевColumn
            // 
            this.месяцевColumn.DataPropertyName = "месяцев";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.Format = "0;#;#";
            this.месяцевColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.месяцевColumn.HeaderText = "месяцев";
            this.месяцевColumn.Name = "месяцевColumn";
            this.месяцевColumn.ReadOnly = true;
            this.месяцевColumn.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "сумма";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.Format = "0;#;#";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn1.HeaderText = "сумма";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // договорColumn
            // 
            this.договорColumn.DataPropertyName = "договор";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.договорColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.договорColumn.HeaderText = "договор";
            this.договорColumn.Name = "договорColumn";
            this.договорColumn.ReadOnly = true;
            this.договорColumn.Width = 200;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(834, 108);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 24);
            this.textBox1.TabIndex = 1;
            // 
            // номерColumn
            // 
            this.номерColumn.DataPropertyName = "номер";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.NullValue = null;
            this.номерColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.номерColumn.HeaderText = "номер";
            this.номерColumn.Name = "номерColumn";
            this.номерColumn.ReadOnly = true;
            // 
            // датаColumn
            // 
            this.датаColumn.DataPropertyName = "дата";
            this.датаColumn.HeaderText = "дата";
            this.датаColumn.Name = "датаColumn";
            this.датаColumn.ReadOnly = true;
            // 
            // адресColumn
            // 
            this.адресColumn.DataPropertyName = "адрес";
            this.адресColumn.HeaderText = "адрес";
            this.адресColumn.Name = "адресColumn";
            this.адресColumn.ReadOnly = true;
            this.адресColumn.Width = 300;
            // 
            // фиоColumn
            // 
            this.фиоColumn.DataPropertyName = "фио";
            this.фиоColumn.HeaderText = "ФИО";
            this.фиоColumn.Name = "фиоColumn";
            this.фиоColumn.ReadOnly = true;
            this.фиоColumn.Width = 150;
            // 
            // суммаColumn
            // 
            this.суммаColumn.DataPropertyName = "оплатить";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.суммаColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.суммаColumn.HeaderText = "сумма";
            this.суммаColumn.Name = "суммаColumn";
            this.суммаColumn.ReadOnly = true;
            // 
            // менеджерColumn
            // 
            this.менеджерColumn.DataPropertyName = "менеджер";
            this.менеджерColumn.HeaderText = "менеджер";
            this.менеджерColumn.Name = "менеджерColumn";
            this.менеджерColumn.ReadOnly = true;
            this.менеджерColumn.Width = 150;
            // 
            // вид_оплатыColumn
            // 
            this.вид_оплатыColumn.DataPropertyName = "наимен_вида";
            this.вид_оплатыColumn.HeaderText = "вид оплаты ";
            this.вид_оплатыColumn.Name = "вид_оплатыColumn";
            this.вид_оплатыColumn.ReadOnly = true;
            this.вид_оплатыColumn.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1147, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "№ квитанции";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1138, 31);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(111, 20);
            this.numericUpDown1.TabIndex = 82;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1150, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 83;
            this.button1.Text = "поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // все_оплаты
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 596);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "все_оплаты";
            this.Text = "все оплаты";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.все_оплаты_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяцевColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn договорColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn адресColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фиоColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn менеджерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn вид_оплатыColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}