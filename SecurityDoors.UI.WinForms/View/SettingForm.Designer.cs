namespace SecurityDoors.UI.WinForms.View
{
	partial class SettingForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SetDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.maskedTextBoxPort = new System.Windows.Forms.MaskedTextBox();
			this.buttonCheckSettings = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.maskedTextBoxPortAPI = new System.Windows.Forms.MaskedTextBox();
			this.textBoxSecretKey = new System.Windows.Forms.TextBox();
			this.textBoxIP = new System.Windows.Forms.TextBox();
			this.buttonConnectionTest = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(344, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// сервисToolStripMenuItem
			// 
			this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.SetDefaultToolStripMenuItem,
            this.CloseToolStripMenuItem});
			this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
			this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.сервисToolStripMenuItem.Text = "Сервис";
			// 
			// SaveToolStripMenuItem
			// 
			this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
			this.SaveToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.SaveToolStripMenuItem.Text = "Сохранить";
			this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// SetDefaultToolStripMenuItem
			// 
			this.SetDefaultToolStripMenuItem.Name = "SetDefaultToolStripMenuItem";
			this.SetDefaultToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.SetDefaultToolStripMenuItem.Text = "Вернуть стандартные";
			this.SetDefaultToolStripMenuItem.Click += new System.EventHandler(this.SetDefaultToolStripMenuItem_Click);
			// 
			// CloseToolStripMenuItem
			// 
			this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
			this.CloseToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.CloseToolStripMenuItem.Text = "Выход";
			this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
			// 
			// справкаToolStripMenuItem
			// 
			this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
			this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
			this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.справкаToolStripMenuItem.Text = "Справка";
			// 
			// AboutToolStripMenuItem
			// 
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			this.AboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.AboutToolStripMenuItem.Text = "О программе";
			this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Введите IP:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(146, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Введите порт контроллера:";
			// 
			// maskedTextBoxPort
			// 
			this.maskedTextBoxPort.Location = new System.Drawing.Point(154, 45);
			this.maskedTextBoxPort.Mask = "00000";
			this.maskedTextBoxPort.Name = "maskedTextBoxPort";
			this.maskedTextBoxPort.PromptChar = ' ';
			this.maskedTextBoxPort.Size = new System.Drawing.Size(40, 20);
			this.maskedTextBoxPort.TabIndex = 4;
			// 
			// buttonCheckSettings
			// 
			this.buttonCheckSettings.Location = new System.Drawing.Point(222, 27);
			this.buttonCheckSettings.Name = "buttonCheckSettings";
			this.buttonCheckSettings.Size = new System.Drawing.Size(110, 45);
			this.buttonCheckSettings.TabIndex = 0;
			this.buttonCheckSettings.Text = "Проверить";
			this.buttonCheckSettings.UseVisualStyleBackColor = true;
			this.buttonCheckSettings.Click += new System.EventHandler(this.ButtonCheckSettings_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(142, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Введите порт для WebAPI:";
			// 
			// maskedTextBoxPortAPI
			// 
			this.maskedTextBoxPortAPI.Location = new System.Drawing.Point(154, 71);
			this.maskedTextBoxPortAPI.Mask = "00000";
			this.maskedTextBoxPortAPI.Name = "maskedTextBoxPortAPI";
			this.maskedTextBoxPortAPI.PromptChar = ' ';
			this.maskedTextBoxPortAPI.Size = new System.Drawing.Size(40, 20);
			this.maskedTextBoxPortAPI.TabIndex = 5;
			this.maskedTextBoxPortAPI.ValidatingType = typeof(int);
			// 
			// textBoxSecretKey
			// 
			this.textBoxSecretKey.Location = new System.Drawing.Point(6, 19);
			this.textBoxSecretKey.Multiline = true;
			this.textBoxSecretKey.Name = "textBoxSecretKey";
			this.textBoxSecretKey.Size = new System.Drawing.Size(308, 20);
			this.textBoxSecretKey.TabIndex = 7;
			// 
			// textBoxIP
			// 
			this.textBoxIP.Location = new System.Drawing.Point(77, 19);
			this.textBoxIP.Name = "textBoxIP";
			this.textBoxIP.Size = new System.Drawing.Size(117, 20);
			this.textBoxIP.TabIndex = 3;
			// 
			// buttonConnectionTest
			// 
			this.buttonConnectionTest.Location = new System.Drawing.Point(222, 78);
			this.buttonConnectionTest.Name = "buttonConnectionTest";
			this.buttonConnectionTest.Size = new System.Drawing.Size(110, 49);
			this.buttonConnectionTest.TabIndex = 1;
			this.buttonConnectionTest.Text = "Тест соединения";
			this.buttonConnectionTest.UseVisualStyleBackColor = true;
			this.buttonConnectionTest.Click += new System.EventHandler(this.ButtonConnectionTest_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBoxSecretKey);
			this.groupBox1.Location = new System.Drawing.Point(12, 133);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 49);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Секретный ключ";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.maskedTextBoxPortAPI);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.textBoxIP);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.maskedTextBoxPort);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(12, 27);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 100);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Основные данные";
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 192);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.buttonConnectionTest);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonCheckSettings);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Settings";
			this.Text = "Настройки";
			this.Load += new System.EventHandler(this.Settings_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SetDefaultToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MaskedTextBox maskedTextBoxPort;
		private System.Windows.Forms.Button buttonCheckSettings;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MaskedTextBox maskedTextBoxPortAPI;
		private System.Windows.Forms.TextBox textBoxSecretKey;
		private System.Windows.Forms.TextBox textBoxIP;
		private System.Windows.Forms.Button buttonConnectionTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}