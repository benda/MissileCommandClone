using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AthensDefender
{
	/// <summary>
	/// Summary description for SplashScreen.
	/// </summary>
	public class SplashScreen : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Timer timer1;
		private int _time;
		private System.ComponentModel.IContainer components;

		public SplashScreen()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			timer1.Start();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "+/-: Adjust Game Speed";
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(264, 32);
			this.label2.TabIndex = 1;
			this.label2.Text = "C: Toggle Collision Mode";
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(16, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(264, 32);
			this.label3.TabIndex = 2;
			this.label3.Text = "Athens Defender";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// SplashScreen
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SplashScreen";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SplashScreen";
			this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			_time++;
			if(_time == 5)
			{
				timer1.Stop();
				this.Hide();
			}
		}

	}
}
