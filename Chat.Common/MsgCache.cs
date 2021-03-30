
using System.Collections.Generic;
using System.Linq;

namespace Chat.Common
{
    public class MsgCache
    {
        /// <summary>
        /// 键为消息序号
        /// 值为消息的分片信息
        /// </summary>
        private Dictionary<int, List<MsgFrame>> Cache;

        public string Identity { private set; get; }
        private MsgCache()
        {
            Cache = new Dictionary<int, List<MsgFrame>>();
        }

        public static MsgCache New(string identity)
        {
            return new MsgCache
            {
                Identity = identity
            };
        }

        /// <summary>
        /// 不需要缓存时返回false，需要时返回true
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public bool Check(MsgFrame frame)
        {
            List<MsgFrame> list;
            if (!Cache.ContainsKey(frame.Id))
            {
                list = new List<MsgFrame>(frame.Total);
                Cache.Add(frame.Id, list);
            }

            list = Cache[frame.Id];
            list.Add(frame);

            return list.Count != frame.Total;
        }

        public MsgFrame[] Get(int id)
        {
            var frames = Cache[id].OrderBy(f=>f.Offset);
            Cache.Remove(id);
            return frames.ToArray();
        }
    }
}
