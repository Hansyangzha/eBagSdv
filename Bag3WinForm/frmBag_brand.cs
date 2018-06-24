using System;
using System.Windows.Forms;

namespace Bag3WinForm
{
    public sealed partial class frmBag_brand : Form
    {
        public static readonly frmBag_brand _Instance = new frmBag_brand();
        private clsBrand _brand;
        private frmBag_brand()
        {
            InitializeComponent();
        }

        public void ShowDialog(clsBrand prBrand)
        {
            _brand = prBrand;
            lstBags.DataSource = null;
            textBox1.Enabled = true;
            if (!string.IsNullOrEmpty(_brand.brand_name))
            {
                textBox1.Enabled = false;
                UpdateDisplay();
            }
            textBox1.Text = _brand.brand_name;
            textBox2.Text = _brand.brand_description;
            _Instance.Show();
        }

        public async void UpdateDisplay()
        {
            try
            {
                lstBags.DataSource = null;
                lstBags.DataSource = await ServiceClient.GetBrandBagsAsync(_brand.brand_name);
            }
            catch (Exception ex)
            {
                //dfg
            }
        }

        private void pushData()
        {
            _brand.brand_name = textBox1.Text;
            _brand.brand_description = textBox2.Text;
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                pushData();
                if (textBox1.Enabled)
                {
                    MessageBox.Show(await ServiceClient.InsertBrandAsync(_brand));
                    frmMain.Instance.UpdateDisplay();
                    textBox1.Enabled = false;
                }
                else
                    MessageBox.Show(await ServiceClient.UpdateBrandAsync(_brand));

                _Instance.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int lcIndex = lstBags.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting bag", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(await ServiceClient.DeleteBagAsync(lstBags.SelectedItem as clsBag));
                _Instance.UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
        }

        private async void add_Click(object sender, EventArgs e)
        {
            try
            {
                string lcReply = new InputBox(clsBag.FACTORY_PROMPT).Answer;
                if (!string.IsNullOrEmpty(lcReply)) // not cancelled?
                {
                    clsBag lcBag = clsBag.NewWork(lcReply[0]);
                    if (lcBag != null) // valid bag created?
                    {
                        if (textBox1.Enabled)       // new bag not saved?
                        {
                            pushData();
                            await ServiceClient.InsertBrandAsync(_brand);
                            textBox1.Enabled = false;
                        }
                        lcBag.bag_brand_id = _brand.brand_name;
                        frmBag.DispatchWorkForm(lcBag);
                        if (!string.IsNullOrEmpty(lcBag.bag_name)) // not cancelled?
                        {
                            _Instance.UpdateDisplay();
                            frmMain.Instance.UpdateDisplay();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void lstBags_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmBag.DispatchWorkForm(lstBags.SelectedValue as clsBag);
                _Instance.UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
