namespace domofon40
{
    partial class льготы1клиент
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.услугаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дата_сColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дата_поColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.услугаColumn,
            this.дата_сColumn,
            this.дата_поColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView1.Name = "dataGridView1";
<<<<<<< HEAD
            this.dataGridView1.Size = new System.Drawing.Size(704, 715);
=======
            this.dataGridView1.Size = new System.Drawing.Size(587, 763);
>>>>>>> a49fc8b534cc496ecc9ee0b06fe479ae66828c89
            this.dataGridView1.TabIndex = 0;
            // 
            // услугаColumn
            // 
            this.услугаColumn.DataPropertyName = "услуги";
            this.услугаColumn.HeaderText = "услуга";
            this.услугаColumn.Name = "услугаColumn";
            this.услугаColumn.ReadOnly = true;
            this.услугаColumn.Width = 300;
            // 
            // дата_сColumn
            // 
            this.дата_сColumn.DataPropertyName = "дата_с";
            dataGridViewCellStyle2.Format = "d";
            this.дата_сColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.дата_сColumn.HeaderText = "дата_с";
            this.дата_сColumn.Name = "дата_сColumn";
            this.дата_сColumn.ReadOnly = true;
            this.дата_сColumn.Width = 150;
            // 
            // дата_поColumn
            // 
            this.дата_поColumn.DataPropertyName = "дата_по";
            dataGridViewCellStyle3.Format = "d";
            this.дата_поColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.дата_поColumn.HeaderText = "дата_по";
            this.дата_поColumn.Name = "дата_поColumn";
            this.дата_поColumn.ReadOnly = true;
            this.дата_поColumn.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(789, 68);
=======
            this.label1.Location = new System.Drawing.Point(634, 48);
>>>>>>> a49fc8b534cc496ecc9ee0b06fe479ae66828c89
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "*";
            this.label1.Visible = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.Blue;
<<<<<<< HEAD
            this.button3.Location = new System.Drawing.Point(794, 324);
=======
            this.button3.Location = new System.Drawing.Point(639, 295);
>>>>>>> a49fc8b534cc496ecc9ee0b06fe479ae66828c89
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 46);
            this.button3.TabIndex = 24;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
<<<<<<< HEAD
            this.button2.Location = new System.Drawing.Point(794, 226);
=======
            this.button2.Location = new System.Drawing.Point(639, 197);
>>>>>>> a49fc8b534cc496ecc9ee0b06fe479ae66828c89
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 32);
            this.button2.TabIndex = 23;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
<<<<<<< HEAD
            this.button1.Location = new System.Drawing.Point(794, 137);
=======
            this.button1.Location = new System.Drawing.Point(639, 108);
>>>>>>> a49fc8b534cc496ecc9ee0b06fe479ae66828c89
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 32);
            this.button1.TabIndex = 22;
            this.button1.Text = "Новое";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
<<<<<<< HEAD
=======
            // услугаColumn
            // 
            this.услугаColumn.DataPropertyName = "услуги";
            this.услугаColumn.HeaderText = "услуга";
            this.услугаColumn.Name = "услугаColumn";
            this.услугаColumn.ReadOnly = true;
            this.услугаColumn.Width = 300;
            // 
            // дата_сColumn
            // 
            this.дата_сColumn.DataPropertyName = "дата_с";
            dataGridViewCellStyle1.Format = "d";
            this.дата_сColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.дата_сColumn.HeaderText = "дата_с";
            this.дата_сColumn.Name = "дата_сColumn";
            this.дата_сColumn.ReadOnly = true;
            // 
            // дата_поColumn
            // 
            this.дата_поColumn.DataPropertyName = "дата_по";
            dataGridViewCellStyle2.Format = "d";
            this.дата_поColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.дата_поColumn.HeaderText = "дата_по";
            this.дата_поColumn.Name = "дата_поColumn";
            this.дата_поColumn.ReadOnly = true;
            // 
>>>>>>> a49fc8b534cc496ecc9ee0b06fe479ae66828c89
            // льготы1клиент
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1087, 715);
=======
            this.ClientSize = new System.Drawing.Size(827, 763);
>>>>>>> a49fc8b534cc496ecc9ee0b06fe479ae66828c89
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "льготы1клиент";
            this.Text = "льготы1клиент";
            this.Load += new System.EventHandler(this.льготы1клиент_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn услугаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дата_сColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дата_поColumn;
    }
}