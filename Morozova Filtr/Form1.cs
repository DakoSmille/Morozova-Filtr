using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Morozova_Filtr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Model1 database = new Model1();

        List<Pavilion> pavilions = new List<Pavilion>();
        List<Pavilion> PavilionsChange = new List<Pavilion>();
        List<string> pavilionsProp = new List<string>();

        private void loadstartData()
        {
            pavilionBindingSource.DataSource = PavilionsChange;
        }

        private void LoadDataCombo()
        {
            pavilionsProp = typeof(Pavilion).GetProperties().Select(x => x.Name).ToList();
            pavilionsProp.RemoveRange(pavilionsProp.Count - 2, 2);
            comboBoxOrderBy.DataSource = pavilionsProp;
            comboBoxOrderBy.SelectedIndex = 0;
        }

        private void LoadOrder()
        {
            if (checkBoxDesc.Checked == false)
            {
                switch (comboBoxOrderBy.SelectedItem)
                {
                    case "Num_pav": PavilionsChange = PavilionsChange.OrderBy(p => p.Num_pav).ToList(); break;
                    case "ID_mall": PavilionsChange = PavilionsChange.OrderBy(p => p.ID_mall).ToList(); break;
                    case "Floor": PavilionsChange = PavilionsChange.OrderBy(p => p.Floor).ToList(); break;
                    case "Status": PavilionsChange = PavilionsChange.OrderBy(p => p.Status).ToList(); break;
                    case "Square": PavilionsChange = PavilionsChange.OrderBy(p => p.Square).ToList(); break;
                    case "Cost_meter": PavilionsChange = PavilionsChange.OrderBy(p => p.Cost_meter).ToList(); break;
                    case "Coeff_cost": PavilionsChange = PavilionsChange.OrderBy(p => p.Coeff_cost).ToList(); break;
                }
            }
            else if (checkBoxDesc.Checked == true)
            {
                switch (comboBoxOrderBy.SelectedItem)
                { 
                    case "Num_pav": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Num_pav).ToList(); break;
                    case "ID_mall": PavilionsChange = PavilionsChange.OrderByDescending(p => p.ID_mall).ToList(); break;
                    case "Floor": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Floor).ToList(); break;
                    case "Status": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Status).ToList(); break;
                    case "Square": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Square).ToList(); break;
                    case "Cost_meter": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Cost_meter).ToList(); break;
                    case "Coeff_cost": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Coeff_cost).ToList(); break;
                }
            }

            loadstartData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PavilionsChange = pavilions = database.Pavilion.ToList();
            loadstartData();
            LoadDataCombo();
        }

        private void Data_changes(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PavilionsChange = pavilions.Where(x => x.Status.Contains(textBox1.Text)).ToList();
            LoadOrder();
        }
    }
}
