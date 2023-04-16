namespace oop_1
{
    partial class FormTask2
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
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelMathSqrt = new System.Windows.Forms.Label();
            this.labelNewton = new System.Windows.Forms.Label();
            this.buttonNewtonIter = new System.Windows.Forms.Button();
            this.labelIterNum = new System.Windows.Forms.Label();
            this.labelInaccuracy = new System.Windows.Forms.Label();
            this.labelSqrtOnIter = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonToTask3 = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(37, 43);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(206, 20);
            this.textBoxInput.TabIndex = 0;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(34, 18);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(166, 13);
            this.labelInput.TabIndex = 2;
            this.labelInput.Text = "Введите положительное число:";
            // 
            // labelMathSqrt
            // 
            this.labelMathSqrt.AutoSize = true;
            this.labelMathSqrt.Location = new System.Drawing.Point(34, 93);
            this.labelMathSqrt.Name = "labelMathSqrt";
            this.labelMathSqrt.Size = new System.Drawing.Size(121, 13);
            this.labelMathSqrt.TabIndex = 3;
            this.labelMathSqrt.Text = "С помощью Math.Sqrt: ";
            // 
            // labelNewton
            // 
            this.labelNewton.AutoSize = true;
            this.labelNewton.Location = new System.Drawing.Point(34, 129);
            this.labelNewton.Name = "labelNewton";
            this.labelNewton.Size = new System.Drawing.Size(160, 13);
            this.labelNewton.TabIndex = 4;
            this.labelNewton.Text = "С помощью метода Ньютона: ";
            // 
            // buttonNewtonIter
            // 
            this.buttonNewtonIter.Location = new System.Drawing.Point(392, 163);
            this.buttonNewtonIter.Name = "buttonNewtonIter";
            this.buttonNewtonIter.Size = new System.Drawing.Size(105, 40);
            this.buttonNewtonIter.TabIndex = 6;
            this.buttonNewtonIter.Text = "Выполнить итерацию";
            this.buttonNewtonIter.UseVisualStyleBackColor = true;
            this.buttonNewtonIter.Click += new System.EventHandler(this.buttonNewtonIter_Click);
            // 
            // labelIterNum
            // 
            this.labelIterNum.AutoSize = true;
            this.labelIterNum.Location = new System.Drawing.Point(34, 177);
            this.labelIterNum.Name = "labelIterNum";
            this.labelIterNum.Size = new System.Drawing.Size(62, 13);
            this.labelIterNum.TabIndex = 7;
            this.labelIterNum.Text = "Итераций: ";
            // 
            // labelInaccuracy
            // 
            this.labelInaccuracy.AutoSize = true;
            this.labelInaccuracy.Location = new System.Drawing.Point(34, 207);
            this.labelInaccuracy.Name = "labelInaccuracy";
            this.labelInaccuracy.Size = new System.Drawing.Size(81, 13);
            this.labelInaccuracy.TabIndex = 8;
            this.labelInaccuracy.Text = "Погрешность: ";
            // 
            // labelSqrtOnIter
            // 
            this.labelSqrtOnIter.AutoSize = true;
            this.labelSqrtOnIter.Location = new System.Drawing.Point(34, 233);
            this.labelSqrtOnIter.Name = "labelSqrtOnIter";
            this.labelSqrtOnIter.Size = new System.Drawing.Size(169, 13);
            this.labelSqrtOnIter.TabIndex = 9;
            this.labelSqrtOnIter.Text = "Значение на текущей итерации:";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(306, 29);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(90, 46);
            this.buttonCalculate.TabIndex = 10;
            this.buttonCalculate.Text = "Вычислить";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonToTask3
            // 
            this.buttonToTask3.Location = new System.Drawing.Point(392, 286);
            this.buttonToTask3.Name = "buttonToTask3";
            this.buttonToTask3.Size = new System.Drawing.Size(105, 37);
            this.buttonToTask3.TabIndex = 11;
            this.buttonToTask3.Text = "К заданию 3";
            this.buttonToTask3.UseVisualStyleBackColor = true;
            this.buttonToTask3.Click += new System.EventHandler(this.buttonToTask3_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(392, 221);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(105, 36);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "Сброс";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // FormTask2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 363);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonToTask3);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.labelSqrtOnIter);
            this.Controls.Add(this.labelInaccuracy);
            this.Controls.Add(this.labelIterNum);
            this.Controls.Add(this.buttonNewtonIter);
            this.Controls.Add(this.labelNewton);
            this.Controls.Add(this.labelMathSqrt);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.textBoxInput);
            this.Name = "FormTask2";
            this.Text = "Вычисление квадратного корня с контролем точности";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelMathSqrt;
        private System.Windows.Forms.Label labelNewton;
        private System.Windows.Forms.Button buttonNewtonIter;
        private System.Windows.Forms.Label labelIterNum;
        private System.Windows.Forms.Label labelInaccuracy;
        private System.Windows.Forms.Label labelSqrtOnIter;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonToTask3;
        private System.Windows.Forms.Button buttonReset;
    }
}