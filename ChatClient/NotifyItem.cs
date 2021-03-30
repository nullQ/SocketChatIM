using System.Windows.Forms;

namespace ChatClient
{
    public partial class NotifyItem : UserControl
    {
        private NotifyItem()
        {
            InitializeComponent();
        }

        public static NotifyItem New(string msg)
        {
            var item = new NotifyItem { lbText = { Text = msg } };
            return item;
        }
    }
}
