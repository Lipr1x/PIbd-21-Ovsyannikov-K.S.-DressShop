namespace AbstractShopView
{
	partial class FormComponents
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.ButtonAdd = new System.Windows.Forms.Button();
			this.ButtonUpd = new System.Windows.Forms.Button();
			this.ButtonDel = new System.Windows.Forms.Button();
			this.ButtonRef = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(344, 342);
			this.dataGridView.TabIndex = 0;
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.Location = new System.Drawing.Point(367, 12);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
			this.ButtonAdd.TabIndex = 1;
			this.ButtonAdd.Text = "Добавить";
			this.ButtonAdd.UseVisualStyleBackColor = true;
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// ButtonUpd
			// 
			this.ButtonUpd.Location = new System.Drawing.Point(367, 55);
			this.ButtonUpd.Name = "ButtonUpd";
			this.ButtonUpd.Size = new System.Drawing.Size(75, 23);
			this.ButtonUpd.TabIndex = 2;
			this.ButtonUpd.Text = "Изменить";
			this.ButtonUpd.UseVisualStyleBackColor = true;
			this.ButtonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
			// 
			// ButtonDel
			// 
			this.ButtonDel.Location = new System.Drawing.Point(367, 93);
			this.ButtonDel.Name = "ButtonDel";
			this.ButtonDel.Size = new System.Drawing.Size(75, 23);
			this.ButtonDel.TabIndex = 3;
			this.ButtonDel.Text = "Удалить";
			this.ButtonDel.UseVisualStyleBackColor = true;
			this.ButtonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// ButtonRef
			// 
			this.ButtonRef.Location = new System.Drawing.Point(367, 133);
			this.ButtonRef.Name = "ButtonRef";
			this.ButtonRef.Size = new System.Drawing.Size(75, 23);
			this.ButtonRef.TabIndex = 4;
			this.ButtonRef.Text = "Обновить";
			this.ButtonRef.UseVisualStyleBackColor = true;
			this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// FormComponents
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 344);
			this.Controls.Add(this.ButtonRef);
			this.Controls.Add(this.ButtonDel);
			this.Controls.Add(this.ButtonUpd);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.dataGridView);
			this.Name = "FormComponents";
			this.Text = "FormComponents";
			this.Load += new System.EventHandler(this.FormComponents_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button ButtonAdd;
		private System.Windows.Forms.Button ButtonUpd;
		private System.Windows.Forms.Button ButtonDel;
		private System.Windows.Forms.Button ButtonRef;
	}
}