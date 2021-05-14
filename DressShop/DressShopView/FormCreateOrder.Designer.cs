namespace AbstractShopView
{
	partial class FormCreateOrder
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.comboBoxDress = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskedTextBox1.Location = new System.Drawing.Point(21, 12);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(68, 13);
            this.maskedTextBox1.TabIndex = 0;
            this.maskedTextBox1.Text = "Изделие:";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.maskedTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskedTextBox2.Location = new System.Drawing.Point(21, 45);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(68, 13);
            this.maskedTextBox2.TabIndex = 1;
            this.maskedTextBox2.Text = "Количество:";
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.maskedTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskedTextBox3.Location = new System.Drawing.Point(21, 82);
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(68, 13);
            this.maskedTextBox3.TabIndex = 2;
            this.maskedTextBox3.Text = "Сумма:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(148, 45);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(121, 20);
            this.textBoxCount.TabIndex = 4;
            this.textBoxCount.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(148, 82);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(121, 20);
            this.textBoxSum.TabIndex = 5;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(42, 116);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(148, 116);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // comboBoxDress
            // 
            this.comboBoxDress.FormattingEnabled = true;
            this.comboBoxDress.Location = new System.Drawing.Point(148, 12);
            this.comboBoxDress.Name = "comboBoxDress";
            this.comboBoxDress.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDress.TabIndex = 8;
            this.comboBoxDress.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDress_SelectedIndexChanged);
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 151);
            this.Controls.Add(this.comboBoxDress);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Name = "FormCreateOrder";
            this.Text = "FormCreateOrder";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MaskedTextBox maskedTextBox1;
		private System.Windows.Forms.MaskedTextBox maskedTextBox2;
		private System.Windows.Forms.MaskedTextBox maskedTextBox3;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.TextBox textBoxSum;
		private System.Windows.Forms.Button ButtonSave;
		private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.ComboBox comboBoxDress;
    }
}