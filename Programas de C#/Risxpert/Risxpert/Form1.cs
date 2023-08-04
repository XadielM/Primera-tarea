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
            new Riesgos { ID = 001}
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


            dataGridView1.Rows.Add(DateTime.Now, txtID.Text, txtAnalista.Text, txtActivo.Text, txtRiesgo.Text, txtDaños.Text);
            txtID.Clear();
            txtAnalista.Clear();
            txtActivo.Clear();
            txtRiesgo.Clear();
            txtDaños.Clear();

        }


        private void tabPage2_Click(object sender, EventArgs e) // Fecha
        {
            lblDate2.Text = DateTime.Now.ToLongDateString();
        }



        public class Riesgos
        {
            public ObjectId Id { get; set; } // LiteDB requiere un campo de identificación (ObjectId)
            public int ID { get; set; }
            public int Analista { get; set; }
            public string Activo { get; set; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //Transfer de Data GV Tab 1
        {
            string col = dataGridView1.Columns[e.ColumnIndex].Name;
            if (col == "Transfer")
            {
                dataGridView2.Rows.Add(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }

            MessageBox.Show("Su informacion ha sido transferida exitosamente!");
        }

        private void btnDelete_Click(object sender, EventArgs e) //Boton borrar de la fase 1
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void btnDelete2_Click(object sender, EventArgs e) //Boton borrar de la fase 2
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(rowIndex);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) //Transfer de Data GV Tab 2
        {
            string col = dataGridView2.Columns[e.ColumnIndex].Name;
            if (col == "Transfer2")
            {
                dataGridView3.Rows.Add(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString(), dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString(), dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString(), dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString(), dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString(), dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString());
            }

            foreach(DataGridViewRow row in dataGridView3.Rows)
                row.Cells["I"].Value = Convert.ToDouble(row.Cells["F3"].Value) * Convert.ToDouble(row.Cells["S3"].Value);

            foreach (DataGridViewRow row in dataGridView3.Rows)
                row.Cells["D"].Value = Convert.ToDouble(row.Cells["P3"].Value) * Convert.ToDouble(row.Cells["E3"].Value);

            foreach (DataGridViewRow row in dataGridView3.Rows)
                row.Cells["C"].Value = Convert.ToDouble(row.Cells["I"].Value) + Convert.ToDouble(row.Cells["D"].Value);

            foreach(DataGridViewRow row in dataGridView3.Rows)
                row.Cells["Pb"].Value = Convert.ToDouble(row.Cells["A3"].Value) * Convert.ToDouble(row.Cells["V3"].Value);

            foreach(DataGridViewRow row in dataGridView3.Rows)
                row.Cells["ER"].Value = Convert.ToDouble(row.Cells["C"].Value) * Convert.ToDouble(row.Cells["Pb"].Value);
        }

        private void btnDelete3_Click(object sender, EventArgs e) //Boton borrar de la fase 3
        {
            int rowIndex = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(rowIndex);
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //Realizando las operaciones matematicas en la tab 3
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
                row.Cells["I"].Value = Convert.ToDouble(row.Cells["F3"].Value) * Convert.ToDouble(row.Cells["S3"].Value);
            
            foreach (DataGridViewRow row in dataGridView3.Rows)
                row.Cells["D"].Value = Convert.ToDouble(row.Cells["P3"].Value) * Convert.ToDouble(row.Cells["E3"].Value);

            foreach (DataGridViewRow row in dataGridView3.Rows)
                row.Cells["C"].Value = Convert.ToDouble(row.Cells["I"].Value) + Convert.ToDouble(row.Cells["D"].Value);

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string col = dataGridView3.Columns[e.ColumnIndex].Name;
            if (col == "Resultado")
            {
                dataGridView3.Rows.Add(dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
        }
    }
}
