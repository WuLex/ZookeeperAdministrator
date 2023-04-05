# ZookeeperAdministrator
Zookeeper四字命令管理

进入到zookeeper的zoo.cfg中,在zoo.cfg中添加如下一行代码并保存退出

## 开启四字命令

4lw.commands.whitelist=*

然后我们进到zookeeper的bin目录进行重启zookeeper即可:

Linux系统中重启命令:
./zkServer.sh  restart

Windows系统中关闭先前的窗口,双击启动:
zkServer.cmd

## windows系统中需要调用netcat执行命令,如:echo mntr | nc localhost 2181

## 结果如图:

