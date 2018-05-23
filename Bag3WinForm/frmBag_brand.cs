using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bag3WinForm
{
    public sealed partial class frmBag_brand : Form
    {
        public static readonly frmBag_brand _Instance = new frmBag_brand();
        private string _brandName;
        private frmBag_brand()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string prBrandName)
        {
            _brandName = prBrandName;

            return ShowDialog();

        }

    }
}
