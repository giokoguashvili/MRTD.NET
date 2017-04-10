namespace FormApp
{
    partial class SmartCardForm
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
            this.faceImagePictureBox = new System.Windows.Forms.PictureBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.sexLabel = new System.Windows.Forms.Label();
            this.sexTextBox = new System.Windows.Forms.TextBox();
            this.citLabel = new System.Windows.Forms.Label();
            this.citTextBox = new System.Windows.Forms.TextBox();
            this.personalNumberLabel = new System.Windows.Forms.Label();
            this.personalNumberTextBox = new System.Windows.Forms.TextBox();
            this.dateOfExpiryLabel = new System.Windows.Forms.Label();
            this.dateOfExpiryTextBox = new System.Windows.Forms.TextBox();
            this.dateOfBirthLabel = new System.Windows.Forms.Label();
            this.dateOfBirthTextBox = new System.Windows.Forms.TextBox();
            this.cardNumberLabel = new System.Windows.Forms.Label();
            this.cardNumberTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.signatureImagePictureBox = new System.Windows.Forms.PictureBox();
            this.readBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cardNumberForMRZTexBox = new System.Windows.Forms.TextBox();
            this.dateOfBirthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateOfExpiryDateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.faceImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // faceImagePictureBox
            // 
            this.faceImagePictureBox.Image = global::FormApp.Properties.Resources.logo;
            this.faceImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.faceImagePictureBox.Name = "faceImagePictureBox";
            this.faceImagePictureBox.Size = new System.Drawing.Size(189, 166);
            this.faceImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.faceImagePictureBox.TabIndex = 0;
            this.faceImagePictureBox.TabStop = false;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(207, 28);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.ReadOnly = true;
            this.firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameTextBox.TabIndex = 2;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(207, 12);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(125, 13);
            this.firstNameLabel.TabIndex = 3;
            this.firstNameLabel.Text = "სახელი / FIRST NAME";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(207, 51);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(111, 13);
            this.lastNameLabel.TabIndex = 5;
            this.lastNameLabel.Text = "გვარი / LAST NAME";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(207, 67);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.ReadOnly = true;
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameTextBox.TabIndex = 4;
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new System.Drawing.Point(332, 90);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(67, 13);
            this.sexLabel.TabIndex = 9;
            this.sexLabel.Text = "სქესი / SEX";
            // 
            // sexTextBox
            // 
            this.sexTextBox.Location = new System.Drawing.Point(334, 106);
            this.sexTextBox.Name = "sexTextBox";
            this.sexTextBox.ReadOnly = true;
            this.sexTextBox.Size = new System.Drawing.Size(120, 20);
            this.sexTextBox.TabIndex = 8;
            // 
            // citLabel
            // 
            this.citLabel.AutoSize = true;
            this.citLabel.Location = new System.Drawing.Point(208, 90);
            this.citLabel.Name = "citLabel";
            this.citLabel.Size = new System.Drawing.Size(56, 13);
            this.citLabel.TabIndex = 7;
            this.citLabel.Text = "მოქ. / CIT";
            // 
            // citTextBox
            // 
            this.citTextBox.Location = new System.Drawing.Point(208, 106);
            this.citTextBox.Name = "citTextBox";
            this.citTextBox.ReadOnly = true;
            this.citTextBox.Size = new System.Drawing.Size(120, 20);
            this.citTextBox.TabIndex = 6;
            // 
            // personalNumberLabel
            // 
            this.personalNumberLabel.AutoSize = true;
            this.personalNumberLabel.Location = new System.Drawing.Point(457, 90);
            this.personalNumberLabel.Name = "personalNumberLabel";
            this.personalNumberLabel.Size = new System.Drawing.Size(145, 13);
            this.personalNumberLabel.TabIndex = 11;
            this.personalNumberLabel.Text = "პირადი № / PERSONAL №";
            // 
            // personalNumberTextBox
            // 
            this.personalNumberTextBox.Location = new System.Drawing.Point(460, 106);
            this.personalNumberTextBox.Name = "personalNumberTextBox";
            this.personalNumberTextBox.ReadOnly = true;
            this.personalNumberTextBox.Size = new System.Drawing.Size(120, 20);
            this.personalNumberTextBox.TabIndex = 10;
            // 
            // dateOfExpiryLabel
            // 
            this.dateOfExpiryLabel.AutoSize = true;
            this.dateOfExpiryLabel.Location = new System.Drawing.Point(332, 129);
            this.dateOfExpiryLabel.MaximumSize = new System.Drawing.Size(120, 0);
            this.dateOfExpiryLabel.Name = "dateOfExpiryLabel";
            this.dateOfExpiryLabel.Size = new System.Drawing.Size(105, 26);
            this.dateOfExpiryLabel.TabIndex = 15;
            this.dateOfExpiryLabel.Text = "მოქმედების ვადა DATE OF EXPIRY";
            // 
            // dateOfExpiryTextBox
            // 
            this.dateOfExpiryTextBox.Location = new System.Drawing.Point(335, 158);
            this.dateOfExpiryTextBox.Name = "dateOfExpiryTextBox";
            this.dateOfExpiryTextBox.ReadOnly = true;
            this.dateOfExpiryTextBox.Size = new System.Drawing.Size(120, 20);
            this.dateOfExpiryTextBox.TabIndex = 14;
            // 
            // dateOfBirthLabel
            // 
            this.dateOfBirthLabel.AutoSize = true;
            this.dateOfBirthLabel.Location = new System.Drawing.Point(207, 129);
            this.dateOfBirthLabel.MaximumSize = new System.Drawing.Size(120, 0);
            this.dateOfBirthLabel.Name = "dateOfBirthLabel";
            this.dateOfBirthLabel.Size = new System.Drawing.Size(119, 26);
            this.dateOfBirthLabel.TabIndex = 13;
            this.dateOfBirthLabel.Text = "დაბადების თარიღი DATE OF BIRTH";
            // 
            // dateOfBirthTextBox
            // 
            this.dateOfBirthTextBox.Location = new System.Drawing.Point(207, 158);
            this.dateOfBirthTextBox.Name = "dateOfBirthTextBox";
            this.dateOfBirthTextBox.ReadOnly = true;
            this.dateOfBirthTextBox.Size = new System.Drawing.Size(120, 20);
            this.dateOfBirthTextBox.TabIndex = 12;
            // 
            // cardNumberLabel
            // 
            this.cardNumberLabel.AutoSize = true;
            this.cardNumberLabel.Location = new System.Drawing.Point(42, 181);
            this.cardNumberLabel.Name = "cardNumberLabel";
            this.cardNumberLabel.Size = new System.Drawing.Size(124, 13);
            this.cardNumberLabel.TabIndex = 17;
            this.cardNumberLabel.Text = "ბარათის № / CARD №";
            // 
            // cardNumberTextBox
            // 
            this.cardNumberTextBox.Location = new System.Drawing.Point(52, 197);
            this.cardNumberTextBox.Name = "cardNumberTextBox";
            this.cardNumberTextBox.ReadOnly = true;
            this.cardNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.cardNumberTextBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 187);
            this.label1.MaximumSize = new System.Drawing.Size(120, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 26);
            this.label1.TabIndex = 18;
            this.label1.Text = "ხელმოწერა SIGNATURE";
            // 
            // signatureImagePictureBox
            // 
            this.signatureImagePictureBox.Location = new System.Drawing.Point(334, 187);
            this.signatureImagePictureBox.Name = "signatureImagePictureBox";
            this.signatureImagePictureBox.Size = new System.Drawing.Size(121, 30);
            this.signatureImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.signatureImagePictureBox.TabIndex = 19;
            this.signatureImagePictureBox.TabStop = false;
            // 
            // readBtn
            // 
            this.readBtn.Location = new System.Drawing.Point(355, 267);
            this.readBtn.Name = "readBtn";
            this.readBtn.Size = new System.Drawing.Size(99, 50);
            this.readBtn.TabIndex = 1;
            this.readBtn.Text = "წაკითხვა    Read";
            this.readBtn.UseVisualStyleBackColor = true;
            this.readBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 267);
            this.label2.MaximumSize = new System.Drawing.Size(120, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 26);
            this.label2.TabIndex = 24;
            this.label2.Text = "მოქმედების ვადა DATE OF EXPIRY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 267);
            this.label3.MaximumSize = new System.Drawing.Size(120, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 26);
            this.label3.TabIndex = 22;
            this.label3.Text = "დაბადების თარიღი DATE OF BIRTH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 267);
            this.label4.MaximumSize = new System.Drawing.Size(70, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 26);
            this.label4.TabIndex = 26;
            this.label4.Text = "ბარათის № CARD №";
            // 
            // cardNumberForMRZTexBox
            // 
            this.cardNumberForMRZTexBox.Location = new System.Drawing.Point(12, 296);
            this.cardNumberForMRZTexBox.Name = "cardNumberForMRZTexBox";
            this.cardNumberForMRZTexBox.Size = new System.Drawing.Size(80, 20);
            this.cardNumberForMRZTexBox.TabIndex = 25;
            // 
            // dateOfBirthDateTimePicker
            // 
            this.dateOfBirthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfBirthDateTimePicker.Location = new System.Drawing.Point(119, 296);
            this.dateOfBirthDateTimePicker.Name = "dateOfBirthDateTimePicker";
            this.dateOfBirthDateTimePicker.Size = new System.Drawing.Size(82, 20);
            this.dateOfBirthDateTimePicker.TabIndex = 27;
            // 
            // dateOfExpiryDateTimePicker
            // 
            this.dateOfExpiryDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfExpiryDateTimePicker.Location = new System.Drawing.Point(244, 296);
            this.dateOfExpiryDateTimePicker.Name = "dateOfExpiryDateTimePicker";
            this.dateOfExpiryDateTimePicker.Size = new System.Drawing.Size(88, 20);
            this.dateOfExpiryDateTimePicker.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 328);
            this.Controls.Add(this.dateOfExpiryDateTimePicker);
            this.Controls.Add(this.dateOfBirthDateTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cardNumberForMRZTexBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.readBtn);
            this.Controls.Add(this.signatureImagePictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cardNumberLabel);
            this.Controls.Add(this.cardNumberTextBox);
            this.Controls.Add(this.dateOfExpiryLabel);
            this.Controls.Add(this.dateOfExpiryTextBox);
            this.Controls.Add(this.dateOfBirthLabel);
            this.Controls.Add(this.dateOfBirthTextBox);
            this.Controls.Add(this.personalNumberLabel);
            this.Controls.Add(this.personalNumberTextBox);
            this.Controls.Add(this.sexLabel);
            this.Controls.Add(this.sexTextBox);
            this.Controls.Add(this.citLabel);
            this.Controls.Add(this.citTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.faceImagePictureBox);
            this.Name = "Form1";
            this.Text = "Smart Card";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.faceImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox faceImagePictureBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.TextBox sexTextBox;
        private System.Windows.Forms.Label citLabel;
        private System.Windows.Forms.TextBox citTextBox;
        private System.Windows.Forms.Label personalNumberLabel;
        private System.Windows.Forms.TextBox personalNumberTextBox;
        private System.Windows.Forms.Label dateOfExpiryLabel;
        private System.Windows.Forms.TextBox dateOfExpiryTextBox;
        private System.Windows.Forms.Label dateOfBirthLabel;
        private System.Windows.Forms.TextBox dateOfBirthTextBox;
        private System.Windows.Forms.Label cardNumberLabel;
        private System.Windows.Forms.TextBox cardNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox signatureImagePictureBox;
        private System.Windows.Forms.Button readBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cardNumberForMRZTexBox;
        private System.Windows.Forms.DateTimePicker dateOfBirthDateTimePicker;
        private System.Windows.Forms.DateTimePicker dateOfExpiryDateTimePicker;
    }
}

