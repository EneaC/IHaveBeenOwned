using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;

namespace Examen
{
    public partial class Form1 : Form
    {
        private string connectionString =
            "Server=localhost;Port=3307;Database=sakila;Uid=staff;Pwd=$up3r$3cr3t;";
        private string sql = "";
        private Boolean login = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            List<Film> films = new List<Film>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            if (checkBox1.Checked == true)
            {
                sql = $"SELECT title FROM FILM" +
                $" WHERE title LIKE '{ searchTextBox.Text }'";
            }
            else if (checkBox1.Checked == false)
            {
                sql = $"SELECT title FROM FILM" +
                $" WHERE title LIKE '%{searchTextBox.Text}%'";
            }
            films = connection.Query<Film>(sql).ToList();
            searchListBox.DataSource = films;
            searchListBox.DisplayMember = "fullinfo";

        }

        private void searchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchListBox_DoubleClick(object sender, EventArgs e)
        {
            Film selectedFilm = searchListBox.SelectedItem as Film;
            FilmDetailsForm filmDetails = new FilmDetailsForm(selectedFilm);

            DialogResult result = filmDetails.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                //this.txtResult.Text = testDialog.TextBox1.Text;
            }
            else if (result == DialogResult.Cancel)
            {
                //this.txtResult.Text = "Cancelled";

            }

            filmDetails.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(userTextBox.Text == "guest")
            {
                if(passwordTextBox.Text == "£123")
                {
                    login = true;
                }
            }
            else if (userTextBox.Text == "staff")
            {
                if (passwordTextBox.Text == "£456")
                {
                    login = true;
                }
            }
            else
            {
                
            }
        }
    }
}
