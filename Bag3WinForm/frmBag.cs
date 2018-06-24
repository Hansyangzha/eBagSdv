using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bag3WinForm
{
    public partial class frmBag : Form
    {
        protected clsBag _Bag;

        public delegate void LoadBagFormDelegate(clsBag pBag);

        public static Dictionary<char, Delegate> _BagsForm = new Dictionary<char, Delegate>
        {
            {'N', new LoadBagFormDelegate(frmBagNew.Run)},
            {'U', new LoadBagFormDelegate(frmBagOld.Run)},
        };

        public static void DispatchWorkForm(clsBag prBag)
        {
            _BagsForm[prBag.bag_catergory].DynamicInvoke(prBag);
        }

        public frmBag()
        {
            InitializeComponent();
        }

        public void SetDetails(clsBag prBag)
        {
            _Bag = prBag;
            updateForm();
            ShowDialog();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                if (txtName.Enabled)
                    MessageBox.Show(await ServiceClient.InsertBagAsync(_Bag));
                else
                    MessageBox.Show(await ServiceClient.UpdateBagAsync(_Bag));

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            txtName.Text = _Bag.bag_name;
            txtName.Enabled = string.IsNullOrEmpty(_Bag.bag_name);
            txtColour.Text = _Bag.bag_colour;
            txtColour.Enabled = string.IsNullOrEmpty(_Bag.bag_colour);
            txtSize.Text = _Bag.bag_size;
            txtSize.Enabled = string.IsNullOrEmpty(_Bag.bag_size);
            txtPrice.Text = _Bag.bag_price.ToString();
        }

        protected virtual void pushData()
        {
            _Bag.bag_name = txtName.Text;
            _Bag.bag_colour = txtColour.Text;
            _Bag.bag_size = txtSize.Text;
            _Bag.bag_price = Convert.ToDecimal(txtPrice.Text);
        }

    }
}