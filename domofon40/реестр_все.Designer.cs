namespace domofon40
{
    partial class реестр_все
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.номерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фиоColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.адресColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяцаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.менеджерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.номерColumn,
            this.фиоColumn,
            this.адресColumn,
            this.месяцаColumn,
            this.суммаColumn,
            this.менеджерColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 54);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1365, 325);
            this.dataGridView1.TabIndex = 0;
            // 
            // номерColumn
            // 
            this.номерColumn.DataPropertyName = "номер";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.номерColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.номерColumn.HeaderText = "№ квит";
            this.номерColumn.Name = "номерColumn";
            // 
            // фиоColumn
            // 
            this.фиоColumn.DataPropertyName = "фио";
            this.фиоColumn.HeaderText = "фио";
            this.фиоColumn.Name = "фиоColumn";
            this.фиоColumn.ReadOnly = true;
            this.фиоColumn.Width = 150;
            // 
            // адресColumn
            // 
            this.адресColumn.DataPropertyName = "адрес";
            this.адресColumn.HeaderText = "адрес";
            this.адресColumn.Name = "адресColumn";
            this.адресColumn.ReadOnly = true;
            this.адресColumn.Width = 300;
            // 
            // месяцаColumn
            // 
            this.месяцаColumn.DataPropertyName = "месяца";
            this.месяцаColumn.FillWeight = 200F;
            this.месяцаColumn.HeaderText = "за месяца";
            this.месяцаColumn.Name = "месяцаColumn";
            this.месяцаColumn.ReadOnly = true;
            this.месяцаColumn.Width = 200;
            // 
            // суммаColumn
            // 
            this.суммаColumn.DataPropertyName = "сумма";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.суммаColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.суммаColumn.HeaderText = "сумма";
            this.суммаColumn.Name = "суммаColumn";
            this.суммаColumn.ReadOnly = true;
            // 
            // менеджерColumn
            // 
            this.менеджерColumn.DataPropertyName = "менеджер";
            this.менеджерColumn.FillWeight = 150F;
            this.менеджерColumn.HeaderText = "менеджер";
            this.менеджерColumn.Name = "менеджерColumn";
            this.менеджерColumn.ReadOnly = true;
            this.менеджерColumn.Width = 200;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1365, 54);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(44, 7);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 37);
            this.button3.TabIndex = 6;
            this.button3.Text = "Word по № квит.";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(244, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 39);
            this.button2.TabIndex = 5;
            this.button2.Text = "Word по алфавиту";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(941, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(714, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 24);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // реестр_все
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 379);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "реестр_все";
            this.Text = "реестр_все";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.реестр_все_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фиоColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn адресColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяцаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn менеджерColumn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}