﻿using loader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace loader {
    public partial class Login : Form {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public static api KeyAuthApp = new api(
            name: " ", // Application Name
            ownerid: " ", // Owner ID
            secret: " ", // Application Secret
            version: " " // Application Version /*
                           //path: @"Your_Path_Here" // (OPTIONAL) see tutorial here https://www.youtube.com/watch?v=I9rxt821gMk&t=1s
        );

        public Login() {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Hide();
            var register = new Register();
            register.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            KeyAuthApp.init();

            KeyAuthApp.login(guna2TextBox1.Text, guna2TextBox2.Text);
            if (KeyAuthApp.response.success) {
                this.Hide();
                var main = new Main();
                main.Show();
            }
            else {
                MessageBox.Show("Wrong username or password. Please try again.", "Invalid Credidentials");
            }
        }
    }
}
