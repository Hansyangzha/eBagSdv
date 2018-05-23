using System;
using System.Windows.Forms;

namespace Bag3WinForm
{
    public sealed partial class frmMain : Form
    {   //Singleton
        private static readonly frmMain _Instance = new frmMain();

       // private Bagbrand _BrandList = new clsBrandList();

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
                Text = "Bag (v3 C) - " + prBagName;
        }

        public async void UpdateDisplay()
        {
            lstBrands.DataSource = null;

            lstBrands.DataSource = await ServiceClient.GetBrandNamesAsync();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmBrand.Run(new clsBrand(_BrandList));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error adding new brand");
            //}
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstBrands.SelectedItem);

            frmBag_brand._Instance.ShowDialog(lcKey);

            //if (lcKey != null)
            //    try
            //    {
            //        frmBrand.Run(_BrandList[lcKey]);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "This should never occur");
            //    }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    _BrandList.Save();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "File Save Error");
            //}
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstBrands.SelectedItem);
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting artist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                //    _BrandList.Remove(lcKey);
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
            //try
            //{
            //    _BrandList = clsBrandList.RetrieveArtistList();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "File retrieve error");
            //}
            UpdateDisplay();
            //BagNameChanged += new Notify(updateTitle);
            //BagNameChanged(_BrandList.GalleryName);
            //updateTitle(_ArtistList.GalleryName);
        }

        private void btnGalName_Click(object sender, EventArgs e)
        {
            //_BrandList.BagName = new InputBox("Enter Bag Name:").Answer;
            //BagNameChanged(_BrandList.GalleryName);
        }

        private void lstArtists_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
