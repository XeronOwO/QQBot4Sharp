<div align="center">

# QQBot4Sharp
一个基于 [QQ官方机器人API](https://bot.q.qq.com/wiki/) 的 [C# .NET Standard 2.1](https://github.com/dotnet/dotnet) 异步封装库

</div>

## 说明
本项目基于 [QQ官方机器人文档](https://bot.q.qq.com/wiki/) 编写，是对QQ官方API的异步封装库，使 .NET 开发者能更便捷、快速地使用QQ官方API来编写属于自己的机器人。  
本项目中有很多已实现但未测试的功能，如果有bug，请在issues中提出，但不一定能得到修复。别问，问就是啥功能都要申请，我懒得写申请，或者是写了也没资格使用功能。结果很多功能都没法DEBUG，只能凭感觉开发。~~老子是来写机器人的，又不是来写申请文案的，麻烦得要死。~~  
**注：本项目不提供创建机器人、机器人功能申请等服务，需要您自行前往 [QQ开放平台](https://q.qq.com/#/app/bot) 注册、创建自己的机器人，并申请相关功能。**  

## 安装
方法一：QQBot4Sharp 已发布到 [NuGet](https://www.nuget.org/packages/QQBot4Sharp) ，可以通过相关工具安装到您的项目  
方法二：从 [Releases](https://github.com/XeronOwO/QQBot4Sharp/releases) 中下载 .nupkg 并安装到您的项目  
方法三：通过 git clone 项目到本地，添加项目引用到您的项目

## 使用方法
见 [QQBot4Sharp.Test/Program.cs](QQBot4Sharp.Test/Program.cs) 。

## 已实现功能

<Details>
<summary>事件</summary>

| 名称 | 描述 | 状态 |
| --- | --- | :---: |
| OnReadyAsync | 可以理解为Bot已上线<br/>鉴权成功后，QQ 后台会下发一个 Ready Event | 🟢 |
| OnC2CMessageCreateAsync | 单聊消息<br/>用户在单聊发送消息给机器人 | 🟣 |
| OnGroupAtMessageCreateAsync | 群聊@机器人<br/>用户在群内@机器人发动的消息 | 🟣 |
| OnDirectMessageCreateAsync | 频道私信消息<br/>用户在频道私信给机器人发送的消息 | 🟢 |
| OnAtMessageCreateAsync | 文字子频道@机器人<br/>用户在文字子频道内@机器人发送的消息 | 🟢 |
| OnMessageCreateAsync | 文字子频道全量消息（私域）<br/>用户在文字子频道内发送的所有聊天消息（私域） | 🟢 |
| OnMessageReactionAddAsync | 用户对消息进行表情表态时 | 🟢 |
| OnMessageReactionRemoveAsync | 用户对消息进行取消表情表态时 | 🟢 |
| OnInteractionCreateAsync | 用户点击了消息体的回调按钮 | 🟣 |
| OnGuildCreateAsync | 机器人被加入到某个频道的时候 | 🟢 |
| OnGuildUpdateAsync | 频道信息变更 | 🟢 |
| OnGuildDeleteAsync | 频道被解散、机器人被移除 | 🟢 |
| OnChannelCreateAsync | 子频道被创建 | 🟢 |
| OnChannelUpdateAsync | 子频道信息变更 | 🟢 |
| OnChannelDeleteAsync | 子频道被删除 | 🟢 |
| 敬请期待。。。 | 敬请期待。。。 | 🔴 |

</Details>
<Details>
<summary>API</summary>

| 名称 | 描述 | 状态 |
| --- | --- | :---: |
| SendUserMessageAsync | 发送单聊消息 | 🟣 |
| SendGroupMessageAsync | 发送群聊消息 | 🟣 |
| SendChannelMessageAsync | 发送文字子频道消息<br/>注意：如果消息需要审核，会抛出异常，详见 <a href="https://bot.q.qq.com/wiki/develop/api/openapi/error/error.html#%E9%94%99%E8%AF%AF%E7%A0%81%E5%A4%84%E7%90%86">错误码处理</a> 304023与304024 | 🟢 |
| CreateDirectMessageSessionAsync | 创建频道私信会话<br/>用于机器人和在同一个频道内的成员创建私信会话。 | 🟢 |
| SendDirectMessageAsync | 发送频道私信消息，需要先调用<see cref="CreateDirectMessageSessionAsync(DirectMessageSessionCreateInfo)"/>创建私信会话，再调用此接口发送消息，否则会报错<br/>注意：如果消息需要审核，会抛出异常，详见 <a href="https://bot.q.qq.com/wiki/develop/api/openapi/error/error.html#%E9%94%99%E8%AF%AF%E7%A0%81%E5%A4%84%E7%90%86">错误码处理</a> 304023与304024 | 🟢 |
| UploadUserMediaAsync | 上传富媒体文件（用于单聊） | 🟣 |
| UploadGroupMediaAsync | 上传富媒体文件（用于群聊） | 🟣 |
| DeleteChannelMessageAsync | 撤回文字子频道消息 | 🟢 |
| DeleteDirectMessageAsync | 撤回频道私信消息 | 🟢 |
| SetEmojiReactionAsync | 机器人发表表情表态 | 🟢 |
| DeleteEmojiReactionAsync | 删除机器人发表的表情表态 | 🟢 |
| GetEmojiReactionAsync | 获取消息表情表态的用户列表 | 🟢 |
| RespondToInteractionAsync | 回应交互事件<br/>由于 websocket 推送事件是单向的，开发者收到事件之后，需要进行一次"回应"，告知QQ后台，事件已经收到，否则客户端会一直处于loading状态，直到超时 | 🟣 |
| GetCurrentUserAsync | 获取当前用户（机器人）信息 | 🟢 |
| GetGuildsAsync | 获取当前用户（机器人）所加入的频道列表 | 🟤API死循环 |
| GetGuildAsync | 获取指定频道的信息 | 🟢 |
| GetChannelsAsync | 获取指定频道的所有子频道信息 | 🟢 |
| GetChannelAsync | 获取指定子频道详细信息 | 🟢 |
| CreateChannelAsync | 创建子频道 | 🟢 |
| ModifyChannelAsync | 修改子频道信息 | 🟢 |
| DeleteChannelAsync | 删除子频道 | 🟢 |
| 敬请期待。。。 | 敬请期待。。。 | 🔴 |

</Details>

| 状态 | 说明 |
| :---: | :---: |
| 🟢 | 已完成 |
| 🟡 | 正在完成 |
| 🔴 | 未完成 |
| 🟣 | 已完成但未测试 |
| 🟤 | 存在BUG待修复 |

## 开源协议
[MIT License](LICENSE.txt)
```txt
MIT License
Copyright (c) 2023 XeronOwO

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

```
