using App_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            using var db = new SystenSchoolContext();
            var CustomerData = from s in db.Sections select s;
            List_Section.DataSource = CustomerData.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var db = new SystenSchoolContext();
            Section sec = new Section();
            sec.SectionName = imputname.Text;
            sec.Detail = imputdetail.Text;
            db.Sections.Add(sec);
            db.SaveChanges();
            imputname.Text = "";
            imputdetail.Text = "";
            Listar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imputname.Text = "";
            imputdetail.Text = "";
        }
    }
}
