namespace NoteToMusic
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileInputBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.triggerBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fileInputBtn
            // 
            this.fileInputBtn.BackColor = System.Drawing.Color.White;
            this.fileInputBtn.Location = new System.Drawing.Point(135, 12);
            this.fileInputBtn.Name = "fileInputBtn";
            this.fileInputBtn.Size = new System.Drawing.Size(300, 50);
            this.fileInputBtn.TabIndex = 0;
            this.fileInputBtn.Text = "Please Select an Image File";
            this.fileInputBtn.UseVisualStyleBackColor = false;
            this.fileInputBtn.Click += new System.EventHandler(this.fileInputBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.ImageLocation = "";
            this.pictureBox.Location = new System.Drawing.Point(12, 68);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(555, 634);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // triggerBtn
            // 
            this.triggerBtn.BackColor = System.Drawing.Color.White;
            this.triggerBtn.Location = new System.Drawing.Point(234, 708);
            this.triggerBtn.Name = "triggerBtn";
            this.triggerBtn.Size = new System.Drawing.Size(100, 100);
            this.triggerBtn.TabIndex = 2;
            this.triggerBtn.Text = "Play";
            this.triggerBtn.UseVisualStyleBackColor = false;
            this.triggerBtn.Click += new System.EventHandler(this.triggerBtn_ClickAsync);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(573, 820);
            this.Controls.Add(this.triggerBtn);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.fileInputBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Note To Music";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button fileInputBtn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button triggerBtn;
    }
}

