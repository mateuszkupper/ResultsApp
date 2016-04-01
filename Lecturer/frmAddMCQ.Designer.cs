namespace Lecturer
{
    partial class frmAddMCQ
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoOfQs = new System.Windows.Forms.TextBox();
            this.txtMarksPerQuestion = new System.Windows.Forms.TextBox();
            this.txtMarksAvailable = new System.Windows.Forms.TextBox();
            this.chbNegativeMarking = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of questions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Marks per question";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Marks available (%)";
            // 
            // txtNoOfQs
            // 
            this.txtNoOfQs.Location = new System.Drawing.Point(188, 30);
            this.txtNoOfQs.Name = "txtNoOfQs";
            this.txtNoOfQs.Size = new System.Drawing.Size(88, 22);
            this.txtNoOfQs.TabIndex = 4;
            // 
            // txtMarksPerQuestion
            // 
            this.txtMarksPerQuestion.Location = new System.Drawing.Point(188, 83);
            this.txtMarksPerQuestion.Name = "txtMarksPerQuestion";
            this.txtMarksPerQuestion.Size = new System.Drawing.Size(88, 22);
            this.txtMarksPerQuestion.TabIndex = 5;
            // 
            // txtMarksAvailable
            // 
            this.txtMarksAvailable.Location = new System.Drawing.Point(188, 133);
            this.txtMarksAvailable.Name = "txtMarksAvailable";
            this.txtMarksAvailable.Size = new System.Drawing.Size(88, 22);
            this.txtMarksAvailable.TabIndex = 6;
            // 
            // chbNegativeMarking
            // 
            this.chbNegativeMarking.AutoSize = true;
            this.chbNegativeMarking.Location = new System.Drawing.Point(346, 131);
            this.chbNegativeMarking.Name = "chbNegativeMarking";
            this.chbNegativeMarking.Size = new System.Drawing.Size(148, 21);
            this.chbNegativeMarking.TabIndex = 7;
            this.chbNegativeMarking.Text = "Negative marking?";
            this.chbNegativeMarking.UseVisualStyleBackColor = true;
            this.chbNegativeMarking.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chbNegativeMarking);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMarksAvailable);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMarksPerQuestion);
            this.groupBox1.Controls.Add(this.txtNoOfQs);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 172);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MCQ details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(367, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(448, 193);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmAddMCQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 228);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddMCQ";
            this.Text = "Add MCQ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoOfQs;
        private System.Windows.Forms.TextBox txtMarksPerQuestion;
        private System.Windows.Forms.TextBox txtMarksAvailable;
        private System.Windows.Forms.CheckBox chbNegativeMarking;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
    }
}