using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SmartCardApi.DataGroups;
using SmartCardApi.MRZ;
using SmartCardApi.SmartCard;

namespace FormApp
{
    public partial class SmartCardForm : Form
    {
        public SmartCardForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cardNumberForMRZTexBox.Text = "12IB34415";
            this.dateOfBirthDateTimePicker.Value = new DateTime(1992, 06, 16);
            this.dateOfExpiryDateTimePicker.Value = new DateTime(2022, 10, 08);
        }

        private void FillForm(DataGroupsContent dgsContent)
        {
            var firstName = dgsContent.Dg1Content.MRZ.NameOfHolder
                .Replace("<", " ")
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Last();

            var lastName = dgsContent.Dg1Content.MRZ.NameOfHolder
                .Replace("<", " ")
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .First();

            this.firstNameTextBox.Text = firstName;
            this.lastNameTextBox.Text = lastName;

            faceImagePictureBox.Image = new Bitmap(
                Image
                    .FromStream(
                        new MemoryStream(dgsContent.Dg2Content.FaceImageData)
                    ),
                128, 128
            );
            this.signatureImagePictureBox.Image = new Bitmap(
                Image
                    .FromStream(
                        new MemoryStream(dgsContent.Dg7Content.DisplayedSignatureImageData)
                    )
            );
            this.citTextBox.Text = dgsContent.Dg1Content.MRZ.Nationality;
            this.sexTextBox.Text = dgsContent.Dg1Content.MRZ.Sex;
            this.personalNumberTextBox.Text = dgsContent.Dg11Content.PersonalNumber;
            this.dateOfBirthTextBox.Text = dgsContent.Dg1Content.MRZ.DateOfBirth.ToShortDateString();
            this.dateOfExpiryTextBox.Text = dgsContent.Dg1Content.MRZ.DateOfExpiry.ToShortDateString();
            this.cardNumberTextBox.Text = dgsContent.Dg1Content.MRZ.DocumentNumber;
        }

        private void ClearForm()
        {
            this.firstNameTextBox.Text = String.Empty;
            this.lastNameTextBox.Text = String.Empty;
            this.citTextBox.Text = String.Empty;
            this.sexTextBox.Text = String.Empty;
            this.personalNumberTextBox.Text = String.Empty;
            this.dateOfBirthTextBox.Text = String.Empty;
            this.dateOfExpiryTextBox.Text = String.Empty;
            this.cardNumberTextBox.Text = String.Empty;
            this.faceImagePictureBox.Image = null;
            this.signatureImagePictureBox.Image = null;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("TreadID " + Thread.CurrentThread.ManagedThreadId);
            this.readBtn.Enabled = false;
            ClearForm();
            var mrzInfo = new MRZInfo(
                this.cardNumberForMRZTexBox.Text,
                this.dateOfBirthDateTimePicker.Value,
                this.dateOfExpiryDateTimePicker.Value
            );
            var dgsContent = await new SmartCardContent(mrzInfo)
                                            .Content();
            FillForm(dgsContent);
            this.readBtn.Enabled = true;
        }
    }
}
