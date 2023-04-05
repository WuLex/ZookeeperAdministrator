namespace ZookeeperAdministrator.Models
{
    public class ZooKeeperEnvironmentInfo
    {
        public string ZooKeeperVersion { get; set; } // ZooKeeper版本号
        public string HostName { get; set; } // 主机名
        public string JavaVersion { get; set; } // Java版本号
        public string JavaVendor { get; set; } // Java供应商
        public string JavaHome { get; set; } // Java安装目录
        public string JavaClassPath { get; set; } // Java类路径
        public string JavaLibraryPath { get; set; } // Java库路径
        public string JavaIoTmpDir { get; set; } // Java临时文件目录
        public string JavaCompiler { get; set; } // Java编译器
        public string OsName { get; set; } // 操作系统名称
        public string OsArch { get; set; } // 操作系统架构
        public string OsVersion { get; set; } // 操作系统版本号
        public string UserName { get; set; } // 用户名
        public string UserHome { get; set; } // 用户主目录
        public string UserDir { get; set; } // 用户当前工作目录
        public string OsMemoryFree { get; set; } // 操作系统空闲内存
        public string OsMemoryMax { get; set; } // 操作系统总内存
        public string OsMemoryTotal { get; set; } // 操作系统总内存
    }
}