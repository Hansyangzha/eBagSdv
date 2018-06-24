namespace Bag3WinForm
{
    public sealed partial class frmBagOld : Bag3WinForm.frmBag
    {   //Singleton
        public static readonly frmBagOld Instance = new frmBagOld();

        private frmBagOld()
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
            txtCondition.Text = _Bag.bag_condition;
        }

        protected override void pushData()
        {
            base.pushData();
            _Bag.bag_condition = txtCondition.Text;
            _Bag.bag_warranty = "";
        }
    }
}

