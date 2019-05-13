﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

		void MakeRequest() {
			HttpClientHandler handler = new HttpClientHandler();
			HttpClient httpClient = new HttpClient(handler);
			HttpResponseMessage result;
			try {
				result = httpClient.GetAsync(textBoxURL.Text).Result;
				labelMessage.Text = result.Content.ToString();
			} catch (Exception ex) {
				labelMessage.Text = ex.Message;
			}
		}

		private void MainForm_Load(object sender, EventArgs e) {
			SharedLib.MathOperations m = new SharedLib.MathOperations();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			labelMath.Text = "1 + 1 = " + m.Add(1, 1).ToString();
		}

		private void buttonGetMessage_Click(object sender, EventArgs e) {
			if (0 < textBoxURL.Text.Length) {
				MakeRequest();
			}
		}
	}
}