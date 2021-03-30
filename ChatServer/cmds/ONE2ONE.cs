using System.Linq;
using Chat.Common;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace ChatServerLib.cmds
{
    public class ONE2ONE : CommandBase<ChatSession, StringRequestInfo>
    {
        /// <summary>
        /// 一对一发消息
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            var result = new MsgInfo(MsgType.SEND_RESULT);
            session.Logger.DebugFormat("{0} {1} {2}", session.UserName ?? "--", requestInfo.Key, requestInfo.Body);

            var frame = MsgFrame.Parse(requestInfo.Body);

            var toSession = session.AppServer.GetSessions(_ => _.UserName == frame.Target).FirstOrDefault();
            if (toSession == null)
            {
                result.Success = false;
                result.Message = "User is not online.";
                MsgUtil.Send(session, result);
                return;
            }

            MsgUtil.Send(toSession, frame);
        }
    }
}
