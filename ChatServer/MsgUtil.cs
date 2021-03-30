using Chat.Common;
using SuperSocket.SocketBase.Protocol;

namespace ChatServerLib
{
    class MsgUtil
    {
        public static void Send(ChatSession session, MsgFrame frame)
        {
            var temp = frame.ToString();

            session.Send(temp);
        }
        public static void Send(ChatSession session, MsgInfo msg)
        {
            var frames = msg.ToFrame();

            foreach (var frame in frames)
            {
                Send(session, frame);
            }
        }

        public static void SendAll(ChatSession session, MsgInfo msg)
        {
            foreach (var chatSession in session.AppServer.GetSessions(sess => sess.SessionID != session.SessionID))
            {
                Send(chatSession, msg);
            }
        }

        public static void SendAll(ChatSession session, MsgFrame frame)
        {
            foreach (var chatSession in session.AppServer.GetSessions(sess => sess.SessionID != session.SessionID))
            {
                Send(chatSession, frame);
            }
        }

        public static void SendResoveFailed(ChatSession session, MsgInfo msg, StringRequestInfo requestInfo)
        {
            session.Logger.DebugFormat("Got command: {0}=>{1}", requestInfo.Key, requestInfo.Body);

            msg.Success = false;
            msg.Message = string.Format("Invalid request({0}): cannot parse data", requestInfo.Key);
            Send(session, msg);
        }
    }
}
