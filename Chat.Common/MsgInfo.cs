
using System;
using System.Text;

namespace Chat.Common
{
    public class MsgInfo
    {
        /// <summary>
        /// 消息计数器
        /// </summary>
        private static int Counter;

        /// <summary>
        /// 数据格式
        /// </summary>
        public DataFormat Format
        {
            get;
            set;
        }

        /// <summary>
        /// 目标用户ID，使用-1表示所有用户
        /// </summary>
        public string TargetUser
        {
            get;
            set;
        }

        /// <summary>
        /// 来源用户ID
        /// </summary>
        public string FromUser
        {
            get;
            set;
        }

        /// <summary>
        /// 处理是否成功
        /// </summary>
        public bool Success
        {
            get;
            set;
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgType Type
        {
            get;
            set;
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// 数据内容
        /// </summary>
        public byte[] Data
        {
            get;
            set;
        }

        public MsgInfo()
        {
            Success = true;
        }

        public MsgInfo(MsgType type)
        {
            Success = true;
            Type = type;
        }

        public override string ToString()
        {
            return JSON.EncodeObject(this);
        }

        public static MsgInfo Parse(string msg)
        {
            try
            {
                var info = JSON.DecodeObject<MsgInfo>(msg);

                return info;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public MsgFrame[] ToFrame(int headerLength = 0)
        {
            var msg = this;
            var dataBuf = msg.ToString();
            var dataLen = dataBuf.Length;
            var frameLen = MsgFrame.MAX_DATA_LENGTH - headerLength;

            var frameCount = (int)Math.Ceiling(dataLen * 1.0 / frameLen);
            var frames = new MsgFrame[frameCount];

            var id = Counter++;
            for (var i = 0; i < frameCount; i++)
            {
                var takeLength = dataLen >= frameLen ? frameLen : dataLen;

                frames[i] = new MsgFrame
                {
                    Id = id,
                    Target = msg.TargetUser,
                    Total = frameCount,
                    Offset = i,
                    Data = dataBuf.Substring(i * frameLen, takeLength)
                };
                dataLen -= takeLength;
            }

            return frames;
        }

        public static MsgInfo FromFrame(MsgFrame[] frames)
        {
            var buf = new StringBuilder();
            foreach (var frame in frames)
            {
                buf.Append(frame.Data);
            }

            return Parse(buf.ToString());
        }
    }
}
