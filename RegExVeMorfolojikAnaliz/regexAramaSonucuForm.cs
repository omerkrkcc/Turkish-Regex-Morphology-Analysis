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
    public partial class regexAramaSonucuForm : Form
    {
        public regexAramaSonucuForm(List<string> sonuclar)
        {
            InitializeComponent();
            regexSonucGoster(sonuclar);
        }

        public void regexSonucGoster(List<string> sonuclar)
        {
            dataGridView1.DataSource = sonuclar.Select(s => new { Sonuc = s }).ToList();
        }
    }
}
