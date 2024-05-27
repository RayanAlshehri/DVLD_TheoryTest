namespace DVLD_TheroyTest
{
    partial class CtrlQuestion
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblQuestionText = new System.Windows.Forms.Label();
            this.rbAnswer1 = new System.Windows.Forms.RadioButton();
            this.rbAnswer2 = new System.Windows.Forms.RadioButton();
            this.rbAnswer3 = new System.Windows.Forms.RadioButton();
            this.pbQuestionImage = new System.Windows.Forms.PictureBox();
            this.btnClearAnswer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestionImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.AutoSize = true;
            this.lblQuestionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionText.Location = new System.Drawing.Point(3, 58);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(168, 42);
            this.lblQuestionText.TabIndex = 0;
            this.lblQuestionText.Text = "Question";
            // 
            // rbAnswer1
            // 
            this.rbAnswer1.AutoSize = true;
            this.rbAnswer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAnswer1.Location = new System.Drawing.Point(31, 133);
            this.rbAnswer1.Name = "rbAnswer1";
            this.rbAnswer1.Size = new System.Drawing.Size(158, 41);
            this.rbAnswer1.TabIndex = 1;
            this.rbAnswer1.TabStop = true;
            this.rbAnswer1.Text = "Answer1";
            this.rbAnswer1.UseVisualStyleBackColor = true;
            this.rbAnswer1.CheckedChanged += new System.EventHandler(this.rbAnswer_CheckedChanged);
            // 
            // rbAnswer2
            // 
            this.rbAnswer2.AutoSize = true;
            this.rbAnswer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAnswer2.Location = new System.Drawing.Point(31, 201);
            this.rbAnswer2.Name = "rbAnswer2";
            this.rbAnswer2.Size = new System.Drawing.Size(160, 41);
            this.rbAnswer2.TabIndex = 2;
            this.rbAnswer2.TabStop = true;
            this.rbAnswer2.Text = "Answer2";
            this.rbAnswer2.UseVisualStyleBackColor = true;
            this.rbAnswer2.CheckedChanged += new System.EventHandler(this.rbAnswer_CheckedChanged);
            // 
            // rbAnswer3
            // 
            this.rbAnswer3.AutoSize = true;
            this.rbAnswer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAnswer3.Location = new System.Drawing.Point(31, 269);
            this.rbAnswer3.Name = "rbAnswer3";
            this.rbAnswer3.Size = new System.Drawing.Size(160, 41);
            this.rbAnswer3.TabIndex = 3;
            this.rbAnswer3.TabStop = true;
            this.rbAnswer3.Text = "Answer3";
            this.rbAnswer3.UseVisualStyleBackColor = true;
            this.rbAnswer3.CheckedChanged += new System.EventHandler(this.rbAnswer_CheckedChanged);
            // 
            // pbQuestionImage
            // 
            this.pbQuestionImage.Location = new System.Drawing.Point(826, 21);
            this.pbQuestionImage.Name = "pbQuestionImage";
            this.pbQuestionImage.Size = new System.Drawing.Size(161, 111);
            this.pbQuestionImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQuestionImage.TabIndex = 4;
            this.pbQuestionImage.TabStop = false;
            this.pbQuestionImage.Visible = false;
            // 
            // btnClearAnswer
            // 
            this.btnClearAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAnswer.Location = new System.Drawing.Point(31, 329);
            this.btnClearAnswer.Name = "btnClearAnswer";
            this.btnClearAnswer.Size = new System.Drawing.Size(225, 49);
            this.btnClearAnswer.TabIndex = 5;
            this.btnClearAnswer.Text = "Clear Answer";
            this.btnClearAnswer.UseVisualStyleBackColor = true;
            this.btnClearAnswer.Click += new System.EventHandler(this.btnClearAnswer_Click);
            // 
            // CtrlQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearAnswer);
            this.Controls.Add(this.pbQuestionImage);
            this.Controls.Add(this.rbAnswer3);
            this.Controls.Add(this.rbAnswer2);
            this.Controls.Add(this.rbAnswer1);
            this.Controls.Add(this.lblQuestionText);
            this.Name = "CtrlQuestion";
            this.Size = new System.Drawing.Size(1000, 381);
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestionImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestionText;
        private System.Windows.Forms.RadioButton rbAnswer1;
        private System.Windows.Forms.RadioButton rbAnswer2;
        private System.Windows.Forms.RadioButton rbAnswer3;
        private System.Windows.Forms.PictureBox pbQuestionImage;
        private System.Windows.Forms.Button btnClearAnswer;
    }
}
