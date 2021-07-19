using UbityEngine;

public class SpecialEffexts : MonoBehaviour
{
	public ParticleSystem effect;//存储粒子特效

	private void Update(){
		//点击鼠标事件
		if (Input.GetMouseButtonDown(0)){
			effect.GetComponent<ParticleSystem>().gameObject.SetActive(true);
			effect.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
			effects.GetComponent<ParticleSystem>().Play();
		}
	
	}
}
/*2021年7月19日
 * 粒子系统的使用和制作
 * 关键在于层级的分明
 * 主副相机的使用
 * 代码逻辑则是注意
 * 直接将屏幕坐标赋值是不行的，需要用到坐标转换，游戏是3D的，而我们的屏幕是2D的
 ** 另外粒子系统的参数应该好好注意一下
还有就是粒系统是有底层的 ，又可以对应的实力化，方便程序的管理
 *
 *
 * */
