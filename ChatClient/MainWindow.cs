using Chat.Common;
using SuperSocket.ClientEngine;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class MainWindow : Form
    {
        private AsyncTcpSession client;

        private static MsgCache Cache;

        public MainWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Cache = MsgCache.New(Guid.NewGuid().ToString());
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            if (bConnect.Text == "Disconnect")
            {
                if (client != null)
                {
                    client.Close();
                    client = null;
                }

                bConnect.Text = "Connect";
                return;
            }

            try
            {
                client = new AsyncTcpSession(new IPEndPoint(IPAddress.Parse(tServer.Text), Convert.ToInt32(tPort.Value)));
                #region // bind events
                client.Closed += client_Closed;
                client.Connected += client_Connected;
                client.DataReceived += client_DataReceived;
                client.Error += client_Error;
                #endregion
                AppendNotify("Connecting...");
                bConnect.Text = "Disconnect";
                client.Connect();
            }
            catch (Exception ex)
            {
                AppendNotify("Connect failed: " + ex.Message);
            }
        }

        private readonly StringBuilder buffer = new StringBuilder();

        private void client_DataReceived(object sender, DataEventArgs e)
        {
            // 这里要注意：
            // e.Length 是实际数据的长度
            // 如果直接使用 Encoding.UTF8.GetString(e.Data) 
            // 会读取到填充的\0字符，这会引起不可预知的意外
            var data = buffer + Encoding.UTF8.GetString(e.Data, 0, e.Length);

            buffer.Clear();

            var temp = data.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            switch (temp.Length)
            {
                case 0:
                    return;
                case 1:
                    data = temp[0];
                    break;
                default:
                    data = temp[0];
                    buffer.Append(temp[1]);
                    break;
            }

            var frame = MsgFrame.Parse(data);
            if (Cache.Check(frame))
            {
                return;
            }

            var msg = MsgInfo.FromFrame(Cache.Get(frame.Id));

            switch (msg.Type)
            {
                case MsgType.JOIN_RESULT: // 加入结果
                    // 加入成功
                    if (msg.Success)
                    {
                        // 更新标题
                        Text = "Client - " + tName.Text;
                        if (msg.Data != null && msg.Data.Length != 0)
                        {
                            list.Items.Clear();
                            var onlineusers = msg.Data.ToStr().Split(",".ToArray());
                            foreach (var item in onlineusers)
                            {
                                AddUser(item);
                            }
                        }
                        AppendNotify("U can enjoy the chat now");
                    }
                    else
                    {
                        client.Close();
                        bConnect.Text = "Connect";
                        AppendNotify(msg.Message);
                    }

                    break;
                case MsgType.NEW_JOIN: // 有新用户加入 
                    AppendNotify(string.Format("User {0} join", msg.FromUser));
                    AddUser(msg.FromUser);
                    break;
                case MsgType.SEND_RESULT: // 发送消息结果
                    if (!msg.Success)
                    {
                        AppendNotify(msg.Message);
                    }
                    break;
                case MsgType.MSG: // 收到消息
                    AppendMsg(msg, false);
                    break;
                case MsgType.QUIT: // 用户退出    
                    AppendNotify(string.Format("User {0} leave", msg.FromUser));
                    RemoveUser(msg.FromUser);
                    break;
            }
        }

        private void SetUser(string user, bool invoke = false)
        {
            if (invoke)
            {
                if (user == tName.Text)
                {
                    tbTarget.Clear();
                    return;
                }
                tbTarget.Text = user;
                return;
            }
            if (tbTarget.InvokeRequired)
            {
                tbTarget.Invoke(new MethodInvoker(() =>
                {
                    SetUser(user, true);
                }));
            }
            else
            {
                SetUser(user, true);
            }
        }

        private void AppendMsg(MsgInfo msg, bool send)
        {
            MsgItem item;
            if (send)
            {
                item = msg.Format == DataFormat.Image
                    ? MsgItem.Send(msg.Data, msg.TargetUser)
                    : MsgItem.Send(msg.Message, msg.TargetUser);
            }
            else
            {
                item = msg.Format == DataFormat.Image
                    ? MsgItem.Recv(msg.FromUser, msg.Data, msg.FromUser == tName.Text)
                    : MsgItem.Recv(msg.FromUser, msg.Message, msg.TargetUser == tName.Text);
            }

            item.Width = pnHistory.Width - 40;
            item.OnUserSelect = (sender, u) => SetUser(u);
            AppendItem(item);
        }

        private void AppendNotify(string msg)
        {
            var item = NotifyItem.New(msg);
            item.Width = pnHistory.Width - 40;
            AppendItem(item);
        }

        private void AppendItem(UserControl item)
        {
            if (pnHistory.InvokeRequired)
            {
                pnHistory.Invoke(new MethodInvoker(() =>
                {
                    pnHistory.Controls.Add(item);
                    var lb = new Panel
                    {
                        AutoSize = false,
                        Width = pnHistory.Width - 50,
                        Height = 5
                    };
                    pnHistory.Controls.Add(lb);
                    pnHistory.ScrollControlIntoView(lb);
                }));
            }
            else
            {
                pnHistory.Controls.Add(item);
                pnHistory.ScrollControlIntoView(item);
                var lb = new Panel
                {
                    AutoSize = false,
                    Width = pnHistory.Width - 50,
                    Height = 5
                };
                pnHistory.Controls.Add(lb);
                pnHistory.ScrollControlIntoView(lb);
            }
        }

        private void client_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            AppendNotify("Error:" + e.Exception.Message);
        }

        private void client_Connected(object sender, EventArgs e)
        {
            AppendNotify("Connected. Asking for join...");
            SendCmd(CMD.JOIN, new MsgInfo());
        }

        private void client_Closed(object sender, EventArgs e)
        {
            AppendNotify("Disconnected");
            bConnect.Text = "Connect";
            list.Items.Clear();
        }


        private const string CMD_FORMAT = "{0} {1}\r\n";

        /// <summary>
        /// 向服务器发送命令行协议数据(此函数会将数据以Base64[UTF-8]方式编码，在服务器读取后，需要解码使用)
        /// </summary>
        /// <param name="cmd">请求的命令 </param>
        /// <param name="msg">数据</param>
        private void SendCmd(CMD cmd, MsgInfo msg)
        {
            msg.FromUser = tName.Text;
            var frames = msg.ToFrame(cmd.ToString().Length + 1);

            foreach (var frame in frames)
            {
                var byteData = string.Format(CMD_FORMAT, cmd, frame).ToBin();
                client.Send(byteData, 0, byteData.Length);
            }
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0)
            {
                MessageBox.Show(this, "No user online.");
                return;
            }

            var msg = new MsgInfo(MsgType.MSG);
            var content = tMessage.Text;
            tMessage.Clear();

            msg.Message = content;

            if (string.IsNullOrWhiteSpace(tbTarget.Text))
            {
                SendCmd(CMD.ONE2ALL, msg);
            }
            else
            {
                msg.TargetUser = tbTarget.Text;
                SendCmd(CMD.ONE2ONE, msg);
            }

            AppendMsg(msg, true);
        }

        public void AddUser(string user)
        {
            Invoke((MethodInvoker)delegate
            {
                var row = new ListViewItem(new[] { user });
                list.Items.Add(row);
            });
        }

        public void RemoveUser(string user)
        {
            Invoke((MethodInvoker)delegate
            {
                var item = list.Items.Cast<ListViewItem>()
                    .FirstOrDefault(row => row.Text == user);
                if (item != null)
                {
                    list.Items.Remove(item);
                }
            });
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client == null) return;
            if (client.IsConnected)
            {
                client.Close();
            }
            client = null;
        }

        private void bPic_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                SendPicture(openFileDialog.FileName);
            }
        }

        private void SendPicture(string filename)
        {
            var buf = File.ReadAllBytes(filename);

            if (list.Items.Count == 0)
            {
                AppendNotify("No user online");
                return;
            }

            var msg = new MsgInfo(MsgType.MSG)
            {
                Format = DataFormat.Image,
                Message = tMessage.Text,
                Data = buf
            };

            tMessage.Clear();
            if (string.IsNullOrWhiteSpace(tbTarget.Text))
            {
                SendCmd(CMD.ONE2ALL, msg);
            }
            else
            {
                msg.TargetUser = tbTarget.Text;
                SendCmd(CMD.ONE2ONE, msg);
            }

            AppendMsg(msg, true);
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // 图片选择器的初始路径
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbTarget.Clear();
        }
        
        private void list_MouseClick(object sender, MouseEventArgs e)
        {
            var item = list.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                return;
            }

            tbTarget.Text = item.Text;
        }
    }
}
