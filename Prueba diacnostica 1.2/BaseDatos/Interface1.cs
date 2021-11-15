using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BaseDatos
{
    interface IInterface1
    {
        //void Mostrar();
        void Agregar(ref string version, string comando);
        void Modificar(ref MySqlConnection cnn, ref string version, string comando);
        void Borrar(MySqlConnection cnn, ref string version, string comando);
        void Buscar(MySqlConnection cnn, ref string version, string comando);
        void Conectar(ref MySqlConnection cnn, ref string version, string comando);



    }


    class Bdestu89 : IInterface1
    {

        String Carne { set; get; }
        String Nombre { set; get; }
        String Apellido { set; get; }
        String String { set; get; }
        String Clase { set; get; }
        String Edad { set; get; }

        //public void Mostrar()
        //{
        //    Form1 pri = new Form1();
        //    string cs = @"server=localhost;database=colegio;uid=root;pwd=Ndrw7652801";
        //    var con = new MySqlConnection(cs);
        //    con.Open();

        //    string sql = "SELECT * FROM estudiantes";
        //    var cmd = new MySqlCommand(sql, con);
        //    MySqlDataReader rdr = cmd.ExecuteReader();

        //     pri.lstDatos.Items.Clear();
        //    //MessageBox.Show($"{rdr.GetName(0),-4} {rdr.GetName(1),-10} {rdr.GetName(2),10}");

        //    pri.lstDatos.Items.Add(rdr.GetName(0) + "   " + rdr.GetName(1) + "   " + rdr.GetName(2) + "   " + rdr.GetName(3) + "    " + "    " + rdr.GetName(4));

        //    while (rdr.Read())
        //    {
        //        //MessageBox.Show( rdr.GetInt32(0) + rdr.GetString(1) + rdr.GetString(2) + rdr.GetString(4) +rdr.GetInt32(4));
        //        pri.lstDatos.Items.Add(rdr.GetInt32(0) + "        " + rdr.GetString(1) + "       " + rdr.GetString(2) + "       " + rdr.GetString(4) + "       " + rdr.GetInt32(4));
        //    }
        //    pri.Show();
        //}
        public void Agregar()
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=colegio;uid=root;pwd=Ndrw7652801;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }
        }
        public void Agregar(String Carne, String Nombre, String Apellido, String Clase, String Edad)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=colegio;uid=root;pwd=Ndrw7652801;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Conexion Abierta ! ");
                //   string stm = "SELECT VERSION()";
                //   var cmd = new MySqlCommand(stm, cnn);
                //cmd.CommandText = "INSERT INTO estudiantes(carne, nombre, apellido, clase, edad) VALUES(Carne,Nombre,Apellido,Clase,Edad)";
                // cmd.ExecuteNonQuery();

                var sql = "INSERT INTO estudiantes(nombre, apellido, clase, edad) VALUES(@nombre, @apellido, @clase, @edad)";
                var cmd = new MySqlCommand(sql, cnn);

                //cmd.Parameters.AddWithValue("@carne", Convert.ToInt32(Carne));
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@apellido", Apellido);
                cmd.Parameters.AddWithValue("@clase", Clase);
                cmd.Parameters.AddWithValue("@edad", Convert.ToInt32(Edad));
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                MessageBox.Show("row inserted");



                //var version = cmd.ExecuteScalar().ToString();
                //MessageBox.Show($"MySQL version: {version}");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO se pudo conectar ! " + ex);
            }

        }

        public void Agregar(ref string version, string comando)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=colegio;uid=root;pwd=Ndrw7652801;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                //MessageBox.Show("Conexion Abierta ! ");
                version = "SELECT VERSION()";
                var cmd = new MySqlCommand(comando, cnn);



                version = cmd.ExecuteScalar().ToString();
                //MessageBox.Show($"MySQL version: {version}");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO se pudo conectar ! " + ex);
            }
        }
        public void Modificar(ref MySqlConnection cnn, ref string version, string comando)
        {

        }
        public void Borrar(MySqlConnection cnn, ref string version, string comando)
        {

        }
        public void Buscar(MySqlConnection cnn, ref string version, string comando)
        {
            cnn.Close();

        }

        public void Conectar(ref MySqlConnection cnn, ref string version, string comando)
        {
            string connetionString = null;
            //MySqlConnection cnn;
            connetionString = "server=localhost;database=colegio;uid=root;pwd=Ndrw7652801;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                //MessageBox.Show("Conexion Abierta ! ");
                //string stm = "SELECT VERSION()";
                var cmd = new MySqlCommand(comando, cnn);



                version = cmd.ExecuteScalar().ToString();
                //MessageBox.Show($"MySQL version: {version}");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO se pudo conectar ! " + ex);
            }
        }
    }



}


