using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private StudentDBContext db = new StudentDBContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dgvStudents.DataSource = db.Students.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                Name = txtName.Text,
                Age = int.Parse(txtAge.Text),
                Class = txtClass.Text
            };
            db.Students.Add(student);
            db.SaveChanges();
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                int id = (int)dgvStudents.CurrentRow.Cells["Id"].Value;
                var student = db.Students.Find(id);
                if (student != null)
                {
                    student.Name = txtName.Text;
                    student.Age = int.Parse(txtAge.Text);
                    student.Class = txtClass.Text;
                    db.SaveChanges();
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                int id = (int)dgvStudents.CurrentRow.Cells["Id"].Value;
                var student = db.Students.Find(id);
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                    LoadData();
                }
            }

        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudents.Rows[e.RowIndex].Cells["Name"].Value != null)
            {
                txtName.Text = dgvStudents.Rows[e.RowIndex].Cells["Name"].Value?.ToString();
                txtAge.Text = dgvStudents.Rows[e.RowIndex].Cells["Age"].Value?.ToString();
                txtClass.Text = dgvStudents.Rows[e.RowIndex].Cells["Class"].Value?.ToString();
            }
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }
    } }
