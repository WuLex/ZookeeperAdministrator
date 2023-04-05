using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZookeeperAdministrator.Models
{
    public class ZooKeeperServerConfig
    {
        public int ClientPort { get; set; } // 客户端连接端口号
        public string DataDir { get; set; } // ZooKeeper数据目录
        public string DataLogDir { get; set; } // ZooKeeper日志目录
        public int TickTime { get; set; } // ZooKeeper使用的基本时间单元，以毫秒为单位
        public int InitLimit { get; set; } // ZooKeeper集合中的初始同步限制，以时间单位指定
        public int SyncLimit { get; set; } // ZooKeeper集合中的同步限制，以时间单位指定
        public int MaxClientCnxns { get; set; } // 一个客户端IP地址可以拥有的最大并发连接数
        public int MaxSessionTimeout { get; set; } // 客户端可以设置的最大会话超时时间，以毫秒为单位
        public int MinSessionTimeout { get; set; } // 客户端可以设置的最小会话超时时间，以毫秒为单位
        public List<ServerInfo> Servers { get; set; } // ZooKeeper服务器列表
        public int AutopurgePurgeInterval { get; set; } // 删除快照和日志文件的时间间隔，以小时为单位
        public int AutopurgeSnapRetainCount { get; set; } // 保留的快照文件数量
    }

    public class ServerInfo
    {
        public int Id { get; set; } // 服务器ID
        public string Host { get; set; } // IP地址
        public int QuorumPort { get; set; } // Quorum通信端口
        public int ElectionPort { get; set; } // 选举通信端口
    }
}
