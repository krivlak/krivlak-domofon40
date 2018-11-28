namespace domofon40
{
    partial class начало_учета
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
            System.Windows.Forms.Label начало1Label;
            this.button2 = new System.Windows.Forms.Button();
            this.начало1DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            начало1Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // начало1Label
            // 
            начало1Label.AutoSize = true;
            начало1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            начало1Label.Location = new System.Drawing.Point(69, 145);
            начало1Label.Name = "начало1Label";
            начало1Label.Size = new System.Drawing.Size(123, 20);
            начало1Label.TabIndex = 11;
            начало1Label.Text = "начало учета";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(322, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 27);
            this.button2.TabIndex = 9;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // начало1DateTimePicker
            // 
            this.начало1DateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.начало1DateTimePicker.Location = new System.Drawing.Point(227, 140);
            this.начало1DateTimePicker.Name = "начало1DateTimePicker";
            this.начало1DateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.начало1DateTimePicker.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "записать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // начало_учета
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 370);
            this.Controls.Add(this.button1);
            this.Controls.Add(начало1Label);
            this.Controls.Add(this.начало1DateTimePicker);
            this.Controls.Add(this.button2);
            this.Name = "начало_учета";
            this.Text = "Начало учета с первого числа месяца";
            this.Load += new System.EventHandler(this.начало_учета_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker начало1DateTimePicker;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button1;
    }
}