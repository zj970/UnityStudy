//碰撞检测的条件
//两个都有触发器且最少有一个刚体
//刚体收到重力的作用
////可以用GetCommponent<Rigidbody>获取刚体组件
///再用Rigidbody.useGravity = false;禁用重力
///
///添加力则用Rigidbody.addForce()等方法添加方向力
///动画应该在动画机里面添加方法。
///
