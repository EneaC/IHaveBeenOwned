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
    public partial class FilmDetailsForm : Form
    {
        Film _selectedFilm;
        private string connectionString = "Server=localhost;Port=3307;Database=sakila;Uid=staff;Pwd=$up3r$3cr3t;";
        public FilmDetailsForm(Film selectedFilm)
        {
            InitializeComponent();
            _selectedFilm = selectedFilm;

            List<Film> films = new List<Film>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = $"select f.film_id as id, ct.name as categoria, f.title as title, f.description as descripction, lg.language_id as idiomaid, f.length as length," +
              $" f.rating as rating, lg.name as idioma from film as f join film_category as fc on f.film_id = fc.film_id join category as ct on fc.category_id = ct.category_id join language as lg on f.language_id = lg.language_id";
             //$"where title like '{selectedFilm.title}';";

           // string sql = $"select title, description, length, rating from film;"; // cuando pongo where title = { selectedFilm.title } peta... fk shit

            films = connection.Query<Film>(sql).ToList();
            Film film = films.FirstOrDefault();
            tituloLabel.Text = film.title;
            generoLabel.Text = film.categoria;
            idiomaLabel.Text = film.idioma;
            descriptionLabel.Text = film.description;
            textBox1.Text = film.length;
            textBox2.Text = film.rating;



        }
    }
}
