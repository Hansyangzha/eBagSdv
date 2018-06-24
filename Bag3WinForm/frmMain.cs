using System;
using System.Windows.Forms;

namespace Bag3WinForm
{
    public sealed partial class frmMain : Form
    {   //Singleton
        private static readonly frmMain _Instance = new frmMain();

        private string shop_name = "Sihan Shop";

        public delegate void Notify(string prBagName);

        public event Notify BagNameChanged;

        private frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void updateTitle(string prBagName)
        {
            if (!string.IsNullOrEmpty(prBagName))
                Text = "Bags: " + prBagName;
        }

        public async void UpdateDisplay()
        {
            lstBrands.DataSource = null;
            lstBrands.DataSource = await ServiceClient.GetBrandNamesAsync();
            lstOrders.DataSource = null;
            lstOrders.DataSource = await ServiceClient.GetAllOrdersAsync();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmBag_brand._Instance.ShowDialog(new clsBrand());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new brand");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            clsBrand lcKey;

            lcKey = (clsBrand)lstBrands.SelectedItem;
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting brand", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    MessageBox.Show(await ServiceClient.DeleteBrandAsync(lcKey.brand_name));
                    lstBrands.ClearSelected();
                    UpdateDisplay();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleting brand");
                }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
            BagNameChanged += new Notify(updateTitle);
            BagNameChanged(_Instance.shop_name);
            updateTitle(_Instance.shop_name);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            _Instance.shop_name = new InputBox("Enter Bag Store:").Answer;
            BagNameChanged(_Instance.shop_name);
        }

        private void lstBrands_DoubleClick(object sender, EventArgs e)
        {
            clsBrand lcKey;

            lcKey = (clsBrand)lstBrands.SelectedItem;
            frmBag_brand._Instance.ShowDialog(lcKey);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            clsOrder lcKey;

            lcKey = (clsOrder)lstOrders.SelectedItem;
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    MessageBox.Show(await ServiceClient.DeleteOrderAsync(lcKey));
                    lstBrands.ClearSelected();
                    UpdateDisplay();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleting order");
                }
        }

        private void lstOrders_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsOrder lcKey;

                lcKey = (clsOrder)lstOrders.SelectedItem;

                MessageBox.Show(lcKey.AllInfo());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
