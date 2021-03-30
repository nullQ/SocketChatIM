using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace ChatServerLib.cmds
{
    public class QUIT : CommandBase<ChatSession, StringRequestInfo>
    {
        /// <summary>
        /// 用户退出聊天
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            session.Logger.DebugFormat("Got command: {0}=>{1}", requestInfo.Key, requestInfo.Body);

            session.Close(SuperSocket.SocketBase.CloseReason.ClientClosing);
        }
    }
}
