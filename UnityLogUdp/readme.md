## Unity 日志UDP发送模块

这个模块仅示例如何发送`Unity`日志到`UnityLogViewer`工具，可以直接放到工程里使用，也可以在上面进行修改。

- LogUdpModule.Open() 开启日志监听发送
- LogUdpModule.Close() 关闭日志监听发送

## 使用说明
Unity 端是UDP服务端，`UnityLogViewer` 是UDP客户端，在工具上输入服务端的IP地址，工具会每2秒去发送UDP校验到服务端，当服务端收到校验，就知道客户端的地址，之后就会将日志文本发送到客户端，工具就会显示日志。

### 步骤
1. 启动工具，【远端】→【UDP Unity 日志】
1. 输入远端服务端的IP地址回车
1. 启动 Unity 游戏