using System;
using System.Linq;
using Chat.Common;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace ChatServerLib.cmds
{
    /// <summary>
    /// 加入聊天
    /// </summary>
    public class JOIN : CommandBase<ChatSession, StringRequestInfo>
    {

        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            var result = new MsgInfo(MsgType.JOIN_RESULT);
            var frame = MsgFrame.Parse(requestInfo.Body);

            var msg = MsgInfo.FromFrame(new[] {frame});

            var username = msg.FromUser;

            // 用户未输入昵称
            if (string.IsNullOrWhiteSpace(username))
            {
                result.Success = false;
                result.Message = "Please enter your Nickname.";
                MsgUtil.Send(session, result);
                return;
            }


            var sessions = session.AppServer.GetSessions(_ => !string.IsNullOrWhiteSpace(_.UserName)).ToList();

            // 昵称已经存在
            if (sessions.Any(_ => _.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                result.Success = false;
                result.Message = "Nickname [" + username + "] exists, please get another one.";
                MsgUtil.Send(session, result);
                return;
            }


            // 昵称不存在，可以加入聊天
            session.UserName = username;

            // 返回当前的用户列表
            var users = sessions.Where(sess => sess.SessionID != session.SessionID)
                .Select(sess => sess.UserName);
            result.Data = string.Join(",", users).ToBin();
            MsgUtil.Send(session, result);

            // 通知其它用户
            MsgUtil.SendAll(session, new MsgInfo(MsgType.NEW_JOIN)
            {
                FromUser = session.UserName
            });
        }
    }
}
