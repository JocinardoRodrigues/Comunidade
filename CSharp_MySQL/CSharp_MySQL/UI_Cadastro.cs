using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_MySQL
{
    public partial class UI_Cadastro : Form
    {

        MySqlConnection MyConn;

        public UI_Cadastro()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Fecha a Aplicação
            Application.Exit();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Query
                string strQuery = "INSERT INTO Clientes(Nome,Telefone,Celular,Email)";
                strQuery += "VALUES('" + edtNome.Text + "','" + edtTelefone.Text + "','" + edtCelular.Text + "','" + edtEmail.Text + "')";
                MySqlCommand cmd = new MySqlCommand(strQuery);

                // Abra a Conexão
                MyConn = DB.Conectar();

                // Set
                cmd.Connection = MyConn;

                // Executa a Query.
                cmd.ExecuteNonQuery();

                // Fecha Conexão
                DB.Fechar(MyConn);

                // Recupera o ID do Registro
                edtCodigo.Text = cmd.LastInsertedId.ToString();

                MessageBox.Show("Registro inserido com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
