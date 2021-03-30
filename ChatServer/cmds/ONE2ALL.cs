using Chat.Common;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace ChatServerLib.cmds
{
    /// <summary>
    /// 群发消息
    /// </summary>
    public class ONE2ALL : CommandBase<ChatSession, StringRequestInfo>
    {

        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            var frame = MsgFrame.Parse(requestInfo.Body);
            session.Logger.DebugFormat("{0} {1} {2}", session.UserName ?? "--", requestInfo.Key, requestInfo.Body);
            MsgUtil.SendAll(session, frame);
        }
    }
}
