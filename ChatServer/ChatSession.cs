using Chat.Common;
using SuperSocket.SocketBase;

namespace ChatServerLib
{
    /// <summary>
    /// 连接会话
    /// </summary>
    public class ChatSession : AppSession<ChatSession>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get;
            set;
        }
        
        protected override void HandleUnknownRequest(SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
            MsgUtil.Send(this, new MsgInfo(MsgType.SEND_RESULT)
            {
                Success = false,
                Message = "Unknown request: " + requestInfo.Key
            });
        }

        //protected override void OnSessionStarted()
        //{
        //    base.OnSessionStarted();
        //}

        protected override void OnSessionClosed(CloseReason reason)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                Logger.DebugFormat("user {0} quit.", UserName);
                MsgUtil.SendAll(this, new MsgInfo(MsgType.QUIT)
                {
                    FromUser = UserName
                });
            }

            base.OnSessionClosed(reason);
        }
    }
}
