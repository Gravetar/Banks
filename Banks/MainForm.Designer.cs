
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 618);
            this.Controls.Add(this.DebugText);
            this.Name = "MainForm";
            this.Text = "Банковская система";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer DebugTimer;
        public System.Windows.Forms.RichTextBox DebugText;
    }
}

