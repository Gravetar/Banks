
namespace Banks
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
            this.DebugText = new System.Windows.Forms.RichTextBox();
            this.DebugTimer = new System.Windows.Forms.Timer(this.components);
            this.SelectUserCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectCardCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DebugText
            // 
            this.DebugText.Dock = System.Windows.Forms.DockStyle.Right;
            this.DebugText.Location = new System.Drawing.Point(707, 0);
            this.DebugText.Name = "DebugText";
            this.DebugText.Size = new System.Drawing.Size(263, 618);
            this.DebugText.TabIndex = 0;
            this.DebugText.Text = "DEBUGGER";
            // 
            // DebugTimer
            // 
            this.DebugTimer.Interval = 1000;
            this.DebugTimer.Tick += new System.EventHandler(this.DebugTimer_Tick);
            // 
            // SelectUserCB
            // 
            this.SelectUserCB.FormattingEnabled = true;
            this.SelectUserCB.Location = new System.Drawing.Point(160, 12);
            this.SelectUserCB.Name = "SelectUserCB";
            this.SelectUserCB.Size = new System.Drawing.Size(268, 21);
            this.SelectUserCB.TabIndex = 2;
            this.SelectUserCB.Text = "Выбрать...";
            this.SelectUserCB.SelectedIndexChanged += new System.EventHandler(this.SelectUserCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Смотреть от имени...";
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Location = new System.Drawing.Point(15, 80);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(686, 526);
            this.MainPanel.TabIndex = 3;
            this.MainPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выбрать карту...";
            this.label2.Visible = false;
            // 
            // SelectCardCB
            // 
            this.SelectCardCB.FormattingEnabled = true;
            this.SelectCardCB.Location = new System.Drawing.Point(160, 39);
            this.SelectCardCB.Name = "SelectCardCB";
            this.SelectCardCB.Size = new System.Drawing.Size(268, 21);
            this.SelectCardCB.TabIndex = 5;
            this.SelectCardCB.Text = "Выбрать...";
            this.SelectCardCB.Visible = false;
            this.SelectCardCB.SelectedIndexChanged += new System.EventHandler(this.SelectCardCB_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Переключить тип дебаггера";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 618);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectCardCB);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectUserCB);
            this.Controls.Add(this.DebugText);
            this.Name = "MainForm";
            this.Text = "Банковская система";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer DebugTimer;
        public System.Windows.Forms.RichTextBox DebugText;
        private System.Windows.Forms.ComboBox SelectUserCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SelectCardCB;
        private System.Windows.Forms.Button button1;
    }
}

