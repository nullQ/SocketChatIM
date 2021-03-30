using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class MsgItem : UserControl
    {
        private MsgItem()
        {
            InitializeComponent();
        }

        public EventHandler<string> OnUserSelect;

        public static MsgItem Send(string msg, string target = null)
        {
            var isPrivate = true;
            if (string.IsNullOrWhiteSpace(target))
            {
                isPrivate = false;
                target = "所有人";
            }
            var item = new MsgItem
            {
                user = { Text = "" },
                time = { Text = DateTime.Now.ToShortTimeString() },
                lType = { Text = string.Format("[发给{0}]", target) },
                lPrivate = { Text = isPrivate ? "[私信]" : "[群发]" }
            };
            var ctrl = new Label
            {
                AutoSize = true,
                Text = msg,
                Left = 15,
                Top = 20,
                MaximumSize = new Size(item.Width, 0)
            };

            item.Controls.Add(ctrl);
            item.Height += ctrl.Height + 5;
            return item;
        }

        public static MsgItem Send(byte[] imgData, string target = null)
        {
            var isPrivate = true;
            if (string.IsNullOrWhiteSpace(target))
            {
                isPrivate = false;
                target = "所有人";
            }
            var item = new MsgItem
            {
                user = { Text = "" },
                time = { Text = DateTime.Now.ToShortTimeString() },
                lType = { Text = string.Format("[发给{0}]", target) },
                lPrivate = { Text = isPrivate ? "[私信]" : "[群发]" }
            };
            var img = new Bitmap(new MemoryStream(imgData));
            var maxWidth = 400;
            var width = img.Width > maxWidth ? maxWidth : img.Width;
            var height = (int)Math.Round(img.Height * (1.0 * width / img.Width));
            var ctrl = new PictureBox
            {
                Image = img,
                Left = 15,
                Top = 20,
                Width = width,
                Height = height,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            item.Controls.Add(ctrl);
            item.Height += ctrl.Height + 5;
            return item;
        }

        public static MsgItem Recv(string user, string msg, bool isPrivate)
        {
            var item = new MsgItem
            {
                user = { Text = user },
                time = { Text = DateTime.Now.ToShortTimeString() },
                lType = { Text = "来自" },
                lPrivate = { Text = isPrivate ? "[私信]" : "[群发]" }
            };
            var ctrl = new Label
            {
                AutoSize = true,
                Text = msg,
                Left = 15,
                Top = 20,
                MaximumSize = new Size(item.Width, 0)
            };

            item.Controls.Add(ctrl);
            item.Height += ctrl.Height + 5;
            return item;
        }

        public static MsgItem Recv(string user, byte[] imgData, bool isPrivate)
        {
            var item = new MsgItem
            {
                user = { Text = user },
                time = { Text = DateTime.Now.ToShortTimeString() },
                lType = { Text = "来自" },
                lPrivate = { Text = isPrivate ? "[私信]" : "[群发]" }
            };
            var img = new Bitmap(new MemoryStream(imgData));
            var maxWidth = 400;
            var width = img.Width > maxWidth ? maxWidth : img.Width;
            var height = (int)Math.Round(img.Height * (1.0 * width / img.Width));
            var ctrl = new PictureBox
            {
                Image = img,
                Left = 15,
                Top = 20,
                Width = width,
                Height = height,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            item.Controls.Add(ctrl);
            item.Height += ctrl.Height + 5;
            return item;
        }

        private void user_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnUserSelect != null)
            {
                OnUserSelect(user, user.Text);
            }
        }
    }
}
