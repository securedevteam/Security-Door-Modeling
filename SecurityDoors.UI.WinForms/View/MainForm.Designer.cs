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
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxDoors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownRepeatCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewPeoplesAndCards = new System.Windows.Forms.DataGridView();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timerUpdateLog = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeoplesAndCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.UpdateThroughtAPIToolStripMenuItem,
            this.LoadDataFromFileToolStripMenuItem});
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
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionSettingToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // connectionSettingToolStripMenuItem
            // 
            this.connectionSettingToolStripMenuItem.Name = "connectionSettingToolStripMenuItem";
            this.connectionSettingToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.connectionSettingToolStripMenuItem.Text = "ConnectionSetting";
            this.connectionSettingToolStripMenuItem.Click += new System.EventHandler(this.ConnectionSettingToolStripMenuItem_Click);
            // 
            // comboBoxDoors
            // 
            this.comboBoxDoors.FormattingEnabled = true;
            this.comboBoxDoors.Location = new System.Drawing.Point(7, 35);
            this.comboBoxDoors.Name = "comboBoxDoors";
            this.comboBoxDoors.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDoors.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбор двери";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Повтор";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пауза";
            // 
            // numericUpDownRepeatCount
            // 
            this.numericUpDownRepeatCount.Location = new System.Drawing.Point(134, 35);
            this.numericUpDownRepeatCount.Name = "numericUpDownRepeatCount";
            this.numericUpDownRepeatCount.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownRepeatCount.TabIndex = 7;
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Location = new System.Drawing.Point(188, 35);
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownDelay.TabIndex = 8;
            // 
            // dataGridViewPeoplesAndCards
            // 
            this.dataGridViewPeoplesAndCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPeoplesAndCards.Location = new System.Drawing.Point(12, 97);
            this.dataGridViewPeoplesAndCards.Name = "dataGridViewPeoplesAndCards";
            this.dataGridViewPeoplesAndCards.RowHeadersVisible = false;
            this.dataGridViewPeoplesAndCards.Size = new System.Drawing.Size(600, 126);
            this.dataGridViewPeoplesAndCards.TabIndex = 9;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(3, 16);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(594, 181);
            this.textBoxLog.TabIndex = 10;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(242, 33);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.comboBoxDoors);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDownRepeatCount);
            this.groupBox1.Controls.Add(this.numericUpDownDelay);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 64);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основные действия";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxLog);
            this.groupBox2.Location = new System.Drawing.Point(12, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 200);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Лог приложения";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewPeoplesAndCards);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Моделирование данных для приложения SecurityDoors.DoorController";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeoplesAndCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelBindingSource)).EndInit();
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
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.ToolStripMenuItem LoadDataFromFileToolStripMenuItem;
		private System.Windows.Forms.Timer timerUpdateLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionSettingToolStripMenuItem;
    }
}

