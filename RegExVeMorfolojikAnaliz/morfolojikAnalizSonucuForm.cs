using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegExVeMorfolojikAnaliz
{
    public partial class morfolojikAnalizSonucuForm : Form
    {
        public morfolojikAnalizSonucuForm(Dictionary<string, string> morfolojikAnaliz)
        {
            InitializeComponent();
            SonuclariGoster(morfolojikAnaliz);

        }


        public void SonuclariGoster(Dictionary<string, string> morfolojikAnaliz)
        {
            dataGridView1.DataSource = morfolojikAnaliz.Select(s => new { Sonuc = s }).ToList();
        }
    }
}
