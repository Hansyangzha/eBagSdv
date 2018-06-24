namespace Bag3WinForm
{
    public sealed partial class frmBagNew : Bag3WinForm.frmBag
    {   //Singleton
        private static readonly frmBagNew Instance = new frmBagNew();

        private frmBagNew()
        {
            InitializeComponent();
        }

        public static void Run(clsBag prBag)
        {
            Instance.SetDetails(prBag);
        }

        protected override void updateForm()
        {
            base.updateForm();
            txtWaranty.Text = _Bag.bag_warranty;
        }

        protected override void pushData()
        {
            base.pushData();
            _Bag.bag_warranty = txtWaranty.Text;
            _Bag.bag_condition = "";
        }

    }
}

