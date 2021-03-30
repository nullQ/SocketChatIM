# SuperSocketChat
### 说明
此程序使用 SuperSocket [SuperSocket](http://www.supersocket.net)。是一个简单的聊天室例子。服务器通过配置文件启动，使用了江大的 SuperSocket.SocketService.exe (在本程序中更名为 Run.exe) 来启动程序（或安装为服务）。

- 程序使用runtime为4.5

### 目前实现了基础的功能

- 加入聊天室
- 一对一发消息
- 群发消息
- 发送图片

> 对发送消息的大小没有做限制

### 使用说明

下面以本机测试 127.0.0.1 为例

程序默认端口是 9527

1. 打开客户端 ChatClient，输入服务器地址127.0.0.1，端口默认为9527，输入昵称
2. 成功加入后，服务器会返回当前在线的用户昵称列表，列表显示在左侧
3. 发消息，若选择了用户，则为一对一消息；否则为一对多(群发)消息
