//Unity3D控制物体移动
void Update(){
	//控制移动
	float h = Input.GetAxisRaw("Horizontal");
	float v = Input.GetAxisRaw("Vertical");
	//前提是由刚体
	//也可以人为设置时间间隔速度
	rigidbody.MovePosition(transform.posion + new Vector(h,0,v) * speed * Time.deltaTime);
	//移动角度

}


