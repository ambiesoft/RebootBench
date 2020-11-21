
namespace RebootBench
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbStartup = new System.Windows.Forms.GroupBox();
            this.rbThisApp = new System.Windows.Forms.RadioButton();
            this.rbBrower = new System.Windows.Forms.RadioButton();
            this.gbStartup.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbStartup
            // 
            resources.ApplyResources(this.gbStartup, "gbStartup");
            this.gbStartup.Controls.Add(this.rbThisApp);
            this.gbStartup.Controls.Add(this.rbBrower);
            this.gbStartup.Name = "gbStartup";
            this.gbStartup.TabStop = false;
            // 
            // rbThisApp
            // 
            resources.ApplyResources(this.rbThisApp, "rbThisApp");
            this.rbThisApp.Name = "rbThisApp";
            this.rbThisApp.UseVisualStyleBackColor = true;
            // 
            // rbBrower
            // 
            resources.ApplyResources(this.rbBrower, "rbBrower");
            this.rbBrower.Checked = true;
            this.rbBrower.Name = "rbBrower";
            this.rbBrower.TabStop = true;
            this.rbBrower.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.gbStartup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Name = "FormMain";
            this.gbStartup.ResumeLayout(false);
            this.gbStartup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbStartup;
        private System.Windows.Forms.RadioButton rbThisApp;
        private System.Windows.Forms.RadioButton rbBrower;
    }
}

