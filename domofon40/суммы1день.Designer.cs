namespace domofon40
{
    partial class суммы1день
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.вид_услугиColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.вид_оплатыColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наимен_вида_оплColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.вид_услугиColumn,
            this.наименColumn,
            this.вид_оплатыColumn,
            this.наимен_вида_оплColumn,
            this.суммаColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(713, 349);
            this.dataGridView1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(777, 64);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 27);
            this.button2.TabIndex = 8;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(777, 204);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(99, 23);
            this.button18.TabIndex = 41;
            this.button18.Text = "Реестр работ";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(777, 156);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 23);
            this.button4.TabIndex = 40;
            this.button4.Text = "Реестр услуг";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // вид_услугиColumn
            // 
            this.вид_услугиColumn.DataPropertyName = "вид_услуги";
            this.вид_услугиColumn.HeaderText = "вид_услуги";
            this.вид_услугиColumn.Name = "вид_услугиColumn";
            this.вид_услугиColumn.Visible = false;
            // 
            // наименColumn
            // 
            this.наименColumn.DataPropertyName = "наимен";
            this.наименColumn.HeaderText = "вид услуги";
            this.наименColumn.Name = "наименColumn";
            this.наименColumn.ReadOnly = true;
            this.наименColumn.Width = 300;
            // 
            // вид_оплатыColumn
            // 
            this.вид_оплатыColumn.DataPropertyName = "вид_оплаты";
            this.вид_оплатыColumn.HeaderText = "вид_оплаты";
            this.вид_оплатыColumn.Name = "вид_оплатыColumn";
            this.вид_оплатыColumn.ReadOnly = true;
            this.вид_оплатыColumn.Visible = false;
            // 
            // наимен_вида_оплColumn
            // 
            this.наимен_вида_оплColumn.DataPropertyName = "наимен_вида_опл";
            this.наимен_вида_оплColumn.HeaderText = "вид оплаты";
            this.наимен_вида_оплColumn.Name = "наимен_вида_оплColumn";
            this.наимен_вида_оплColumn.ReadOnly = true;
            this.наимен_вида_оплColumn.Width = 150;
            // 
            // суммаColumn
            // 
            this.суммаColumn.DataPropertyName = "сумма";
            this.суммаColumn.HeaderText = "сумма";
            this.суммаColumn.Name = "суммаColumn";
            this.суммаColumn.ReadOnly = true;
            // 
            // суммы1день
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 349);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "суммы1день";
            this.Text = "суммы1день";
            this.Load += new System.EventHandler(this.суммы1день_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn вид_услугиColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn вид_оплатыColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наимен_вида_оплColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаColumn;
    }
}