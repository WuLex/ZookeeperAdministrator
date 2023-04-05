using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZookeeperAdministrator.Models
{
    public class ZooKeeperStatus
    {
        public string Version { get; set; } // ZooKeeper 版本号
        public List<ClientInfo> Clients { get; set; } // 客户端连接信息
        public LatencyInfo Latency { get; set; } // 延迟信息
        public int Received { get; set; } // 接收到的消息数
        public int Sent { get; set; } // 发送的消息数
        public int Connections { get; set; } // 客户端连接数
        public int Outstanding { get; set; } // 挂起的请求数
        public long Zxid { get; set; } // ZooKeeper 事务 ID
        public string Mode { get; set; } // ZooKeeper 的模式，单机模式或集群模式
        public int NodeCount { get; set; } // ZooKeeper 中节点的数量

        public class ClientInfo
        {
            public string Ip { get; set; } // 客户端 IP 地址
            public int Port { get; set; } // 客户端端口号
            public int Queued { get; set; } // 队列中的请求数
            public int Recved { get; set; } // 接收到的请求数
            public int Sent { get; set; } // 发送的响应数
        }

        public class LatencyInfo
        {
            public int Min { get; set; } // 最小延迟
            public int Avg { get; set; } // 平均延迟
            public int Max { get; set; } // 最大延迟
        }
    }
}
