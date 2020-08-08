using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankHealth : MonoBehaviour {

	public GameObject TankExplositionProfab;//Tank预制体
	public int hp = 100;//声明Tank血量
	public Slider hpSlider;//hp血量线

	private int hpTotal;
	public AudioClip TankAudioExplosition;


	// Use this for initialization
	void Start () {
		hpTotal = hp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//收到消息
	void TakeDamage() {

		//检测当前血量， <=0时自动返回
		if (hp <= 0) return;
		//随机减少血量在10-20之间
		hp -= Random.Range(10, 20);

		//hpSlider控制血量线，其中value的值为0-1，所以要将血量换算成比例，因此：
		//血量线 = 当前血量/总血量值（因为hp为int型，而value为float型，因此需要强转）
		hpSlider.value = (float)hp / hpTotal;

		//受到伤害后检测hp值，然后控制死亡效果
		if (hp <= 0) {
			//Tank爆炸音效
			AudioSource.PlayClipAtPoint(TankAudioExplosition, transform.position);
			//实例化Tank销毁效果(将爆炸效果向上位移1的长度)
			GameObject.Instantiate(TankExplositionProfab, transform.position + Vector3.up, transform.rotation);
			//销毁物体（在产生音效之后销毁）
			GameObject.Destroy(this.gameObject);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


		}
	}
}
