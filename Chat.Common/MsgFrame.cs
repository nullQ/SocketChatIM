
using System;
namespace Chat.Common
{
    public class MsgFrame
    {
        /// <summary>
        /// 消息ID，最大为16777215 (0xFFFFFF)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 总数据量，最大为1048575 (0xFFFFF)
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 偏移量，最大为1048575 (0xFFFFF)
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 接收消息的用户，最大长度为16
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 数据，最长990
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 最大数据长度1023-16-6-5-5-2=990
        /// 2 是命令结束符 \r\n
        /// 为啥是1023？  我猜应该是有个数据结束符 \0
        /// </summary>
        public const int MAX_DATA_LENGTH = 1023 - 16 - 6 - 5 - 5 - 2;

        public override string ToString()
        {
            if (Target == null)
            {
                Target = "";
            }
            return string.Format("{4:X}{5}{0:X6}{1:X5}{2:X5}{3}", Id, Total, Offset, Data, Target.Length, Target.PadLeft(15, '0'));
        }

        public static MsgFrame Parse(string frame)
        {
            var dataLen = Convert.ToInt32(frame.Substring(0, 1), 16);
            var target = frame.Substring(16 - dataLen, dataLen);
            var id = Convert.ToInt32(frame.Substring(16, 6), 16);
            var total = Convert.ToInt32(frame.Substring(22, 5), 16);
            var offset = Convert.ToInt32(frame.Substring(27, 5), 16);
            var data = frame.Substring(32);

            return new MsgFrame
            {
                Id = id,
                Target = target,
                Total = total,
                Offset = offset,
                Data = data
            };
        }
    }
}
