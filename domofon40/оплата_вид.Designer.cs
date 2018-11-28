namespace domofon40
{
    partial class оплата_вид
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.годColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяцColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.услугаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.менеджерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наимен_видаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 53);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(707, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.годColumn,
            this.месяцColumn,
            this.услугаColumn,
            this.суммаColumn,
            this.датаColumn,
            this.номерColumn,
            this.менеджерColumn,
            this.наимен_видаColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1278, 383);
            this.dataGridView1.TabIndex = 4;
            // 
            // годColumn
            // 
            this.годColumn.DataPropertyName = "год";
            this.годColumn.HeaderText = "год";
            this.годColumn.Name = "годColumn";
            this.годColumn.ReadOnly = true;
            this.годColumn.Width = 70;
            // 
            // месяцColumn
            // 
            this.месяцColumn.DataPropertyName = "наим_месяца";
            this.месяцColumn.HeaderText = "месяц";
            this.месяцColumn.Name = "месяцColumn";
            this.месяцColumn.ReadOnly = true;
            // 
            // услугаColumn
            // 
            this.услугаColumn.DataPropertyName = "наим_услуги";
            this.услугаColumn.HeaderText = "услуга";
            this.услугаColumn.Name = "услугаColumn";
            this.услугаColumn.ReadOnly = true;
            this.услугаColumn.Width = 150;
            // 
            // суммаColumn
            // 
            this.суммаColumn.DataPropertyName = "сумма";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.суммаColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.суммаColumn.HeaderText = "оплачено";
            this.суммаColumn.Name = "суммаColumn";
            this.суммаColumn.ReadOnly = true;
            // 
            // датаColumn
            // 
            this.датаColumn.DataPropertyName = "дата";
            this.датаColumn.HeaderText = "дата счета";
            this.датаColumn.Name = "датаColumn";
            this.датаColumn.ReadOnly = true;
            // 
            // номерColumn
            // 
            this.номерColumn.DataPropertyName = "номер";
            this.номерColumn.HeaderText = "номер_счета";
            this.номерColumn.Name = "номерColumn";
            this.номерColumn.ReadOnly = true;
            // 
            // менеджерColumn
            // 
            this.менеджерColumn.DataPropertyName = "менеджер";
            this.менеджерColumn.HeaderText = "менеджер";
            this.менеджерColumn.Name = "менеджерColumn";
            this.менеджерColumn.ReadOnly = true;
            this.менеджерColumn.Width = 150;
            // 
            // наимен_видаColumn
            // 
            this.наимен_видаColumn.DataPropertyName = "наимен_вида";
            this.наимен_видаColumn.HeaderText = "вид оплаты";
            this.наимен_видаColumn.Name = "наимен_видаColumn";
            this.наимен_видаColumn.ReadOnly = true;
            this.наимен_видаColumn.Width = 150;
            // 
            // оплата_вид
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 436);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "оплата_вид";
            this.Text = "оплата_вид";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.оплата_вид_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn годColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяцColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn услугаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn менеджерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наимен_видаColumn;
    }
}