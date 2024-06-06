using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PolimorfismoGrafico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RepositorioClientes repo = new RepositorioClientes();
            bool IsNumber = int.TryParse(txtBusca.Text, out int ID);


            if (IsNumber)
            {
                //repo.BuscarCliente(ID);
                List<RepositorioClientes> listaClientes = repo.BuscarCliente(ID);
                dgClientes.DataSource = listaClientes;
            }
            else
            {
                List<RepositorioClientes> listaClientes = repo.BuscarCliente(txtBusca.Text);
                dgClientes.DataSource = listaClientes;

            }

           
            
            
            
        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //Tecla Enter Pressionada
            {
                RepositorioClientes repo = new RepositorioClientes();
                bool IsNumber = int.TryParse(txtBusca.Text, out int ID);


                if (IsNumber)
                {
                    //repo.BuscarCliente(ID);
                    List<RepositorioClientes> listaClientes = repo.BuscarCliente(ID);
                    dgClientes.DataSource = listaClientes;
                }
                else
                {
                    List<RepositorioClientes> listaClientes = repo.BuscarCliente(txtBusca.Text);
                    dgClientes.DataSource = listaClientes;

                }
            }
        }
    }
}
