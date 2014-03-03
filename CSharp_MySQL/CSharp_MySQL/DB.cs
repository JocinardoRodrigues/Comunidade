using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_MySQL
{
    public class DB
    {
        private static string strConexao = "Server=localhost;Database=Store;Uid=root;Password='123456';";


        // Metodo responsavel por abrir a conexão.
        public static MySqlConnection Conectar()
        {
            try
            {
                MySqlConnection MyConn = new MySqlConnection(strConexao);
                MyConn.Open();
                return MyConn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Metodo responsavel por fechar a conexão.
        public static void Fechar(MySqlConnection MyConn)
        {
            try
            {
                if (MyConn.State != System.Data.ConnectionState.Closed)
                    MyConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
