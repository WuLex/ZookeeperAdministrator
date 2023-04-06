# ZookeeperAdministrator
Zookeeper四字命令管理，在3.5.3 中的新功能：四个字母的单词在使用前需要明确列入白名单。具体请参考集群配置章节中的`4lw.commands.whitelist` 。未来四字母命令将被弃用，请改用`AdminServer`。

进入到zookeeper的目录下找到`zoo.cfg`,在`zoo.cfg`中添加如下一行代码并保存退出

## 开启四字命令
```shell
4lw.commands.whitelist=*
```

然后我们进到`zookeeper`的`bin`目录进行重启`zookeeper`即可:

Linux系统中重启命令:

```shell
./zkServer.sh  restart
```

Windows系统中关闭先前的窗口,双击启动:

```shell
zkServer.cmd
```

## windows系统中需要调用`netcat`执行命令,如:`echo mntr | nc localhost 2181`

## 项目运行结果如图:
![在这里插入图片描述](https://raw.githubusercontent.com/WuLex/UsefulPicture/main/zookeepertool/result1.png)
![在这里插入图片描述](https://raw.githubusercontent.com/WuLex/UsefulPicture/main/zookeepertool/result2.png)


