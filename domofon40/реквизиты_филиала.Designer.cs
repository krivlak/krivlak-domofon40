namespace domofon40
{
    partial class реквизиты_филиала
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
            System.Windows.Forms.Label адресLabel;
            System.Windows.Forms.Label наименLabel;
            System.Windows.Forms.Label телефонLabel;
            this.адресTextBox = new System.Windows.Forms.TextBox();
            this.наименTextBox = new System.Windows.Forms.TextBox();
            this.телефонTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.филиалыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            адресLabel = new System.Windows.Forms.Label();
            наименLabel = new System.Windows.Forms.Label();
            телефонLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.филиалыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // адресLabel
            // 
            адресLabel.AutoSize = true;
            адресLabel.Location = new System.Drawing.Point(40, 113);
            адресLabel.Name = "адресLabel";
            адресLabel.Size = new System.Drawing.Size(59, 18);
            адресLabel.TabIndex = 1;
            адресLabel.Text = "адрес:";
            // 
            // наименLabel
            // 
            наименLabel.AutoSize = true;
            наименLabel.Location = new System.Drawing.Point(27, 68);
            наименLabel.Name = "наименLabel";
            наименLabel.Size = new System.Drawing.Size(70, 18);
            наименLabel.TabIndex = 3;
            наименLabel.Text = "наимен:";
            // 
            // телефонLabel
            // 
            телефонLabel.AutoSize = true;
            телефонLabel.Location = new System.Drawing.Point(17, 165);
            телефонLabel.Name = "телефонLabel";
            телефонLabel.Size = new System.Drawing.Size(82, 18);
            телефонLabel.TabIndex = 7;
            телефонLabel.Text = "телефон:";
            // 
            // адресTextBox
            // 
            this.адресTextBox.Location = new System.Drawing.Point(135, 109);
            this.адресTextBox.MaxLength = 50;
            this.адресTextBox.Name = "адресTextBox";
            this.адресTextBox.Size = new System.Drawing.Size(547, 24);
            this.адресTextBox.TabIndex = 2;
            // 
            // наименTextBox
            // 
            this.наименTextBox.Location = new System.Drawing.Point(135, 65);
            this.наименTextBox.MaxLength = 50;
            this.наименTextBox.Name = "наименTextBox";
            this.наименTextBox.Size = new System.Drawing.Size(547, 24);
            this.наименTextBox.TabIndex = 4;
            // 
            // телефонTextBox
            // 
            this.телефонTextBox.Location = new System.Drawing.Point(135, 162);
            this.телефонTextBox.MaxLength = 50;
            this.телефонTextBox.Name = "телефонTextBox";
            this.телефонTextBox.Size = new System.Drawing.Size(547, 24);
            this.телефонTextBox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(499, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "*";
            this.label1.Visible = false;
            // 
            // реквизиты_филиала
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 345);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(адресLabel);
            this.Controls.Add(this.адресTextBox);
            this.Controls.Add(наименLabel);
            this.Controls.Add(this.наименTextBox);
            this.Controls.Add(телефонLabel);
            this.Controls.Add(this.телефонTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "реквизиты_филиала";
            this.Text = "реквизиты филиала";
            this.Load += new System.EventHandler(this.реквизиты_филиала_Load);
            ((System.ComponentModel.ISupportInitialize)(this.филиалыBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource филиалыBindingSource;
        private System.Windows.Forms.TextBox адресTextBox;
        private System.Windows.Forms.TextBox наименTextBox;
        private System.Windows.Forms.TextBox телефонTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}