namespace domofon40
{
    partial class все_события
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.услугаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.событиеColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дата_сColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дата_поColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.примColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1532, 69);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.Blue;
            this.button3.Location = new System.Drawing.Point(827, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 40);
            this.button3.TabIndex = 79;
            this.button3.Text = "Выход ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.услугаColumn,
            this.событиеColumn,
            this.дата_сColumn,
            this.дата_поColumn,
            this.примColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1532, 618);
            this.dataGridView1.TabIndex = 1;
            // 
            // услугаColumn
            // 
            this.услугаColumn.DataPropertyName = "наимен_услуги";
            this.услугаColumn.HeaderText = "услуга";
            this.услугаColumn.Name = "услугаColumn";
            this.услугаColumn.ReadOnly = true;
            this.услугаColumn.Width = 200;
            // 
            // событиеColumn
            // 
            this.событиеColumn.DataPropertyName = "наимен";
            this.событиеColumn.HeaderText = "событие";
            this.событиеColumn.Name = "событиеColumn";
            this.событиеColumn.ReadOnly = true;
            this.событиеColumn.Width = 200;
            // 
            // дата_сColumn
            // 
            this.дата_сColumn.DataPropertyName = "дата_с";
            this.дата_сColumn.HeaderText = "дата с";
            this.дата_сColumn.Name = "дата_сColumn";
            this.дата_сColumn.ReadOnly = true;
            // 
            // дата_поColumn
            // 
            this.дата_поColumn.DataPropertyName = "дата_по";
            this.дата_поColumn.HeaderText = "дата по";
            this.дата_поColumn.Name = "дата_поColumn";
            this.дата_поColumn.ReadOnly = true;
            // 
            // примColumn
            // 
            this.примColumn.DataPropertyName = "прим";
            this.примColumn.HeaderText = "примечание";
            this.примColumn.Name = "примColumn";
            this.примColumn.ReadOnly = true;
            this.примColumn.Width = 300;
            // 
            // все_события
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 687);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "все_события";
            this.Text = "все_события";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.все_события_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn услугаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn событиеColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дата_сColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дата_поColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn примColumn;
    }
}