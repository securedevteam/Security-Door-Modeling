namespace SecurityDoors.UI.WinForms.View
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.UpdateThroughtAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadDataFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboBoxDoors = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDownRepeatCount = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
			this.dataGridViewPeoplesAndCards = new System.Windows.Forms.DataGridView();
			this.textBoxLog = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.timerUpdateLog = new System.Windows.Forms.Timer(this.components);
			this.dataGridViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.SaveDataToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeoplesAndCards)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(389, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// сервисToolStripMenuItem
			// 
			this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.UpdateThroughtAPIToolStripMenuItem,
            this.LoadDataFromFileToolStripMenuItem,
            this.SaveDataToFileToolStripMenuItem});
			this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
			this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.сервисToolStripMenuItem.Text = "Сервис";
			// 
			// SettingsToolStripMenuItem
			// 
			this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
			this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.SettingsToolStripMenuItem.Text = "Настройки";
			this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
			// 
			// UpdateThroughtAPIToolStripMenuItem
			// 
			this.UpdateThroughtAPIToolStripMenuItem.Name = "UpdateThroughtAPIToolStripMenuItem";
			this.UpdateThroughtAPIToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.UpdateThroughtAPIToolStripMenuItem.Text = "Обновить данные через API";
			this.UpdateThroughtAPIToolStripMenuItem.Click += new System.EventHandler(this.UpdateThroughtAPIToolStripMenuItem_Click);
			// 
			// LoadDataFromFileToolStripMenuItem
			// 
			this.LoadDataFromFileToolStripMenuItem.Name = "LoadDataFromFileToolStripMenuItem";
			this.LoadDataFromFileToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.LoadDataFromFileToolStripMenuItem.Text = "Загрузить данные из файла";
			this.LoadDataFromFileToolStripMenuItem.Click += new System.EventHandler(this.LoadDataFromFileToolStripMenuItem_Click);
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
			// 
			// comboBoxDoors
			// 
			this.comboBoxDoors.FormattingEnabled = true;
			this.comboBoxDoors.Location = new System.Drawing.Point(12, 55);
			this.comboBoxDoors.Name = "comboBoxDoors";
			this.comboBoxDoors.Size = new System.Drawing.Size(121, 21);
			this.comboBoxDoors.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Выбор двери";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(136, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Повтор";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(190, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Пауза";
			// 
			// numericUpDownRepeatCount
			// 
			this.numericUpDownRepeatCount.Location = new System.Drawing.Point(139, 55);
			this.numericUpDownRepeatCount.Name = "numericUpDownRepeatCount";
			this.numericUpDownRepeatCount.Size = new System.Drawing.Size(48, 20);
			this.numericUpDownRepeatCount.TabIndex = 7;
			// 
			// numericUpDownDelay
			// 
			this.numericUpDownDelay.Location = new System.Drawing.Point(193, 55);
			this.numericUpDownDelay.Name = "numericUpDownDelay";
			this.numericUpDownDelay.Size = new System.Drawing.Size(48, 20);
			this.numericUpDownDelay.TabIndex = 8;
			// 
			// dataGridViewPeoplesAndCards
			// 
			this.dataGridViewPeoplesAndCards.Location = new System.Drawing.Point(12, 82);
			this.dataGridViewPeoplesAndCards.Name = "dataGridViewPeoplesAndCards";
			this.dataGridViewPeoplesAndCards.RowHeadersVisible = false;
			this.dataGridViewPeoplesAndCards.Size = new System.Drawing.Size(362, 150);
			this.dataGridViewPeoplesAndCards.TabIndex = 9;
			// 
			// textBoxLog
			// 
			this.textBoxLog.Location = new System.Drawing.Point(12, 254);
			this.textBoxLog.Multiline = true;
			this.textBoxLog.Name = "textBoxLog";
			this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxLog.Size = new System.Drawing.Size(362, 127);
			this.textBoxLog.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(26, 238);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(26, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Лог";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(247, 53);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 12;
			this.buttonStart.Text = "Начать";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// timerUpdateLog
			// 
			this.timerUpdateLog.Enabled = true;
			this.timerUpdateLog.Interval = 500;
			this.timerUpdateLog.Tick += new System.EventHandler(this.TimerUpdateLog_Tick);
			// 
			// dataGridViewModelBindingSource
			// 
			this.dataGridViewModelBindingSource.DataSource = typeof(SecurityDoors.BL.Models.ViewModels.DataGridViewModel);
			// 
			// SaveDataToFileToolStripMenuItem
			// 
			this.SaveDataToFileToolStripMenuItem.Name = "SaveDataToFileToolStripMenuItem";
			this.SaveDataToFileToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
			this.SaveDataToFileToolStripMenuItem.Text = "Сохранить данные в файл";
			this.SaveDataToFileToolStripMenuItem.Click += new System.EventHandler(this.SaveDataToFileToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(389, 398);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxLog);
			this.Controls.Add(this.dataGridViewPeoplesAndCards);
			this.Controls.Add(this.numericUpDownDelay);
			this.Controls.Add(this.numericUpDownRepeatCount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxDoors);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeoplesAndCards)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem UpdateThroughtAPIToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboBoxDoors;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDownRepeatCount;
		private System.Windows.Forms.NumericUpDown numericUpDownDelay;
		private System.Windows.Forms.DataGridView dataGridViewPeoplesAndCards;
		private System.Windows.Forms.BindingSource dataGridViewModelBindingSource;
		private System.Windows.Forms.TextBox textBoxLog;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.ToolStripMenuItem LoadDataFromFileToolStripMenuItem;
		private System.Windows.Forms.Timer timerUpdateLog;
		private System.Windows.Forms.ToolStripMenuItem SaveDataToFileToolStripMenuItem;
	}
}

