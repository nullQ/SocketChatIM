namespace ChatClient
{
    /// <summary>
    /// 命令枚举
    /// </summary>
    public enum CMD
    {
        /// <summary>
        /// 加入聊天室
        /// </summary>
        JOIN,
        /// <summary>
        /// 一对一发消息
        /// </summary>
        ONE2ONE,
        /// <summary>
        /// 群发消息
        /// </summary>
        ONE2ALL,
        /// <summary>
        /// 退出聊天室
        /// </summary>
        QUIT
    }
}
