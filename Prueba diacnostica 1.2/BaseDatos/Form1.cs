using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WFA.Base
{
    public partial class Form1 : Form
    {
        class bdestu
        {
            String Cedula { set; get; }
            String Nombre { set; get; }
            String Cod_Mat { set; get; }
            String Par1 { set; get; }
            String Par2 { set; get; }
            String Tar1 { set; get; }
            String Tar2 { set; get; }
            String Pro { set; get; }
            String Aus { set; get; }
            String Estados { set; get; }

            public void Agregar(String Cedula, String Nombre, String Cod_Mat, String Par1, String Par2, String Tar1, String Tar2, String Pro, String Aus)// String Estados)
            {
                string connectionstring = null;
                MySqlConnection cnn;
                connectionstring = "server=localhost;database=estudiantes;uid=root;pwd=BLEER2001;";
                cnn = new MySqlConnection(connectionstring);
                try
                {
                    cnn.Open();
                    MessageBox.Show("Conexion abierta!");

                    var sql = "INSERT INTO estudiantes(nombre, codigo, par1, par2, tar1 ,tar2 ,pro, aus) VALUES (@nombre, @codigo, @par1, @par2, @tar1, @tar2, @pro, @aus)";
                    var cmd = new MySqlCommand(sql, cnn);

                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@codigo", Cod_Mat);
                    cmd.Parameters.AddWithValue("@par1", Convert.ToInt32(Par1));
                    cmd.Parameters.AddWithValue("@par2", Convert.ToInt32(Par2));
                    cmd.Parameters.AddWithValue("@tar1", Convert.ToInt32(Tar1));
                    cmd.Parameters.AddWithValue("@tar2", Convert.ToInt32(Tar2));
                    cmd.Parameters.AddWithValue("@pro", Convert.ToInt32(Pro));
                    cmd.Parameters.AddWithValue("@aus", Convert.ToInt32(Aus));
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Linea insertada!");
                    cnn.Close();

                    Estados = "";
                    int a, b, c, d, f, g, t, g2;
                    a = Convert.ToInt32(Par1);
                    b = Convert.ToInt32(Par2);
                    c = Convert.ToInt32(Tar1);
                    d = Convert.ToInt32(Tar2);
                    f = Convert.ToInt32(Pro);
                    g = Convert.ToInt32(Aus);
                    a = a * 25 / 100;
                    b = b * 25 / 100;
                    c = c * 10 / 100;
                    d = d * 10 / 100;
                    f = f * 25 / 100;
                    g2 = g;
                    if (g2 == 0)
                    {
                        g = 5;
                    }
                    if (g2 == 1)
                    {
                        g = 4;
                    }
                    if (g2 == 2)
                    {
                        g = 3;
                    }
                    if (g2 >= 6)
                    {
                        g = 0;
                    }

                    t = (a + b + c + d + f );

                   MessageBox.Show("Su nota es " + t);
                    if (t >= 60)
                    {
                        Estados = "Reprobado";
                    }

                    if (t <= 70)
                    {
                        Estados = "Aprobado";
                    }

                    if (t < 70 && t > 60)
                    {
                        Estados = "aplazado";
                    }
                    if (g2 >= 3)
                    {
                        Estados = "Reprobado";
                    }

                    MessageBox.Show("su estado es" + Estados);
                   //  cmd.Parameters.AddWithValue("@est", Estados);
                   // cmd.Prepare();
                   //cmd.ExecuteNonQuery();

                    MessageBox.Show("Linea insertada!");
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo conectar!" + ex);
                }
            }

            public void Buscar(DataGridView dataGridView1, TextBox textBox1_TextChanged)
            {
                string cs = "server=localhost;database=colegios;uid=root;pwd=BLEER2001;";
                var con = new MySqlConnection(cs);
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM estudiantes WHERE cedula=" + textBox1_TextChanged.Text;
                    var cmd = new MySqlCommand(sql, con);
                    var adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataSet();
                    adapter.Fill(dt, "estudiantes");
                    dataGridView1.DataSource = dt.Tables["estudiantes"];
                    dataGridView1.ReadOnly = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    MySqlDataReader rdr = cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo conectar!" + ex);
                }
            }
            public void Modificar(String Cedula, String Nombre, String Cod_Mat, String Par1, String Par2, String Tar1, String Tar2, String Pro, String Aus)
            {
                string cs = "server=localhost;database=colegios;uid=root;pwd=BLEER2001;";
                var con = new MySqlConnection(cs);
                try
                {
                    con.Open();

                    string sql = "UPDATE estudiantes SET nombre=@nombre, codigo=@codigo, par1=@par1, par2=@par2, tar1=@tar1, tar2=@tar2, pro=@pro, aus=@aus WHERE cedula=" + Cedula;
                    var cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@ced_est", Convert.ToInt32(Cedula));
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@codigo", Cod_Mat);
                    cmd.Parameters.AddWithValue("@par1", Convert.ToInt32(Par1));
                    cmd.Parameters.AddWithValue("@par2", Convert.ToInt32(Par2));
                    cmd.Parameters.AddWithValue("@tar1", Convert.ToInt32(Tar1));
                    cmd.Parameters.AddWithValue("@tar2", Convert.ToInt32(Tar2));
                    cmd.Parameters.AddWithValue("@pro", Convert.ToInt32(Pro));
                    cmd.Parameters.AddWithValue("@aus", Convert.ToInt32(Aus));
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se encontro!" + ex);
                }
            }

        }

        bdestu bd = new bdestu();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Any() && textBox3.Text.Any() && textBox4.Text.Any() && textBox5.Text.Any() && textBox6.Text.Any() && textBox7.Text.Any() && textBox8.Text.Any() && textBox9.Text.Any())
            bd.Agregar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
            else
            {
                MessageBox.Show("Todos los campos deben llenarse");
            }
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
        }

        
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string cs = "server=localhost;database=colegios;uid=root;pwd=BLEER2001;";
            var con = new MySqlConnection(cs);
            try
            {
                con.Open();
                string sql = "DELETE FROM estudiantes WHERE cedula= " + int.Parse(textBox1.Text);
                var cmd = new MySqlCommand(sql, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                textBox1.Text = string.Empty;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro!" + ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Any() && textBox3.Text.Any() && textBox4.Text.Any() && textBox5.Text.Any() && textBox6.Text.Any() && textBox7.Text.Any() && textBox8.Text.Any() && textBox9.Text.Any())
                bd.Modificar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
            else
            {
                MessageBox.Show("Todos los campos deben llenarse");
            }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = "server=localhost;database=estudiantes;uid=root;pwd=BLEER2001;";
            var con = new MySqlConnection(cs);
            try
            {
                con.Open();
                string sql = "DELETE FROM estudiantes";
                var elim = new MySqlCommand(sql, con);
                MySqlDataReader rdr = elim.ExecuteReader();
                MessageBox.Show("Lineas borradas!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar!" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = "server=localhost;database=estudiantes;uid=root;pwd=BLEER2001;";
            var cnn = new MySqlConnection(con);
            try
            {
                cnn.Open();
                string sql = "SELECT * FROM estudiantes";
                var cmd = new MySqlCommand(sql, cnn);
                var adapter = new MySqlDataAdapter(cmd);
                var ds = new DataSet();
                adapter.Fill(ds, "estudiantes");
                dataGridView1.DataSource = ds.Tables["estudiantes"];
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                MySqlDataReader rdr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connecion fallida!" + ex);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Any())
            bd.Buscar(dataGridView1, textBox1);
            else
            {
                MessageBox.Show("Todos los campos deben llenarse");
            }
            textBox1.Text = string.Empty;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}


