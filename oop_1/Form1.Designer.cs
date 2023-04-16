namespace oop_1
{
    partial class FormTask1
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
            this.buttonEnter = new System.Windows.Forms.Button();
            this.textBoxEnter = new System.Windows.Forms.TextBox();
            this.buttonToTask2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(246, 43);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(75, 23);
            this.buttonEnter.TabIndex = 0;
            this.buttonEnter.Text = "Ввод";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // textBoxEnter
            // 
            this.textBoxEnter.Location = new System.Drawing.Point(57, 43);
            this.textBoxEnter.Name = "textBoxEnter";
            this.textBoxEnter.Size = new System.Drawing.Size(156, 20);
            this.textBoxEnter.TabIndex = 1;
            // 
            // buttonToTask2
            // 
            this.buttonToTask2.Location = new System.Drawing.Point(432, 227);
            this.buttonToTask2.Name = "buttonToTask2";
            this.buttonToTask2.Size = new System.Drawing.Size(91, 36);
            this.buttonToTask2.TabIndex = 2;
            this.buttonToTask2.Text = "К заданию 2";
            this.buttonToTask2.UseVisualStyleBackColor = true;
            this.buttonToTask2.Click += new System.EventHandler(this.buttonToTask2_Click);
            // 
            // FormTask1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 299);
            this.Controls.Add(this.buttonToTask2);
            this.Controls.Add(this.textBoxEnter);
            this.Controls.Add(this.buttonEnter);
            this.Name = "FormTask1";
            this.Text = "Ввод вещественного числа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.TextBox textBoxEnter;
        private System.Windows.Forms.Button buttonToTask2;
    }
}

