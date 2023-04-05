using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZookeeperAdministrator.Models
{
    public class ZooKeeperMonitor
    {
        public string Version { get; set; } // ZooKeeper 版本号
        public int AvgLatency { get; set; } // 平均延迟
        public int MaxLatency { get; set; } // 最大延迟
        public int MinLatency { get; set; } // 最小延迟
        public int PacketsReceived { get; set; } // 接收到的消息数
        public int PacketsSent { get; set; } // 发送的消息数
        public int NumAliveConnections { get; set; } // 存活的客户端连接数
        public int OutstandingRequests { get; set; } // 挂起的请求数
        public string ServerState { get; set; } // ZooKeeper 服务器状态
        public int ZnodeCount { get; set; } // ZooKeeper 中节点的数量
        public int WatchCount { get; set; } // 注册的 Watcher 的数量
        public int EphemeralsCount { get; set; } // 临时节点的数量
        public int ApproximateDataSize { get; set; } // 节点数据的大约大小
        public int OpenFileDescriptorCount { get; set; } // 已打开的文件描述符数量
        public int MaxFileDescriptorCount { get; set; } // 最大文件描述符数量
    }
}
