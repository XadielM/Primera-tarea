using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;

namespace Risxpert
{

    public partial class Form1 : Form
    {
        List<Riesgos> listRiesgo = new List<Riesgos>
        {
            R1 = new Riesgos(),
        };


        public Form1()
        {
            InitializeComponent();

            // Inicializar LiteDB e insertar los datos de listaPersonas en la base de datos
            using (var db = new LiteDatabase("C:\\Temp\\Risxpert"))
            {
                var riesgoCollection = db.GetCollection<Riesgos>("Riesgos");
                riesgoCollection.DeleteAll();
                riesgoCollection.Insert(listRiesgo);
            }

            MessageBox.Show("Datos guardados correctamente en LiteDB.");
        }

        public class riesgos
        {
            int ID;
            string Analista;
            string Activo;
            string daño;
            DateTime Fecha;
            int Fun, Sus, Prof, Ext, Agres, Vul;
        }

        int quantity = 0;

        private void Form1_Load(object sender, EventArgs e) // App general
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblDate2.Text = DateTime.Now.ToLongDateString();

        }

        private void btnAgregar_Click_1(object sender, EventArgs e) // Boton Agregar Tab 1
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtAnalista.Text) 
                || string.IsNullOrEmpty(txtActivo.Text))
            {
                MessageBox.Show("Debe llenar toda la informacion para continuar!! ");
                return;
                
            }
          
         
            dataGridView1.Rows.Add(txtID.Text, txtAnalista.Text, txtActivo.Text, txtRiesgo.Text, txtDaños.Text);
            txtID.Clear();
            txtAnalista.Clear();
            txtActivo.Clear();
            txtRiesgo.Clear();
            txtDaños.Clear();
            
        }

        private void btnAdd2_Click(object sender, EventArgs e) // Boton Agregar Tab 2
        {
            if (string.IsNullOrEmpty(cmbS.Text) || string.IsNullOrEmpty(cmbS.Text) || 
                string.IsNullOrEmpty(cmbP.Text) || string.IsNullOrEmpty(cmbA.Text) || 
                string.IsNullOrEmpty(cmbV.Text) || string.IsNullOrEmpty(cmbE.Text))
            {
                MessageBox.Show("Debe llenar toda la informacion para continuar!! ");
                return;

            }

            dataGridView2.Rows.Add(dataGridView1.Text, cmbS.Text, cmbF.Text, cmbP.Text, cmbA.Text, cmbV.Text, cmbV.Text);
            cmbS.Text = string.Empty;
            cmbF.Text = string.Empty;
            cmbP.Text = string.Empty;
            cmbA.Text = string.Empty;
            cmbV.Text = string.Empty;
            cmbE.Text = string.Empty;


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            lblDate2.Text = DateTime.Now.ToLongDateString();
        }

        private void btnSave_Click(object sender, EventArgs e) // Boton save tab 1
        {

        }
    }
    public class Riesgos
    {
        public ObjectId Id { get; set; } // LiteDB requiere un campo de identificación (ObjectId)
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Apellido { get; set; }
    }
}
