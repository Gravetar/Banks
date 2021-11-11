
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
            this.SuspendLayout();
            // 
            // DebugText
            // 
            this.DebugText.Dock = System.Windows.Forms.DockStyle.Right;
            this.DebugText.Location = new System.Drawing.Point(944, 0);
            this.DebugText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DebugText.Name = "DebugText";
            this.DebugText.Size = new System.Drawing.Size(349, 761);
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
            this.SelectUserCB.Location = new System.Drawing.Point(213, 15);
            this.SelectUserCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SelectUserCB.Name = "SelectUserCB";
            this.SelectUserCB.Size = new System.Drawing.Size(356, 24);
            this.SelectUserCB.TabIndex = 2;
            this.SelectUserCB.Text = "Выбрать...";
            this.SelectUserCB.SelectedIndexChanged += new System.EventHandler(this.SelectUserCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Смотреть от имени...";
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Location = new System.Drawing.Point(20, 59);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(915, 687);
            this.MainPanel.TabIndex = 3;
            this.MainPanel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 761);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectUserCB);
            this.Controls.Add(this.DebugText);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}

