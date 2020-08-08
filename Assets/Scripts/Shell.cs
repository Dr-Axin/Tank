using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

	public GameObject shellExplositionPrefab;//声明爆炸效果预制体
	public AudioClip shellExplositionAudio;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//子弹碰撞检测
	public void OnTriggerEnter(Collider collider) {
		//子弹爆炸音效
		AudioSource.PlayClipAtPoint(shellExplositionAudio,transform.position);
		//碰撞发生时实例化爆炸效果在子弹的位置
		GameObject.Instantiate(shellExplositionPrefab, transform.position, transform.rotation);
		GameObject.Destroy(this.gameObject);//销毁子弹

		//检测是否与Tank发生碰撞
		if(collider.tag == "Tank") {
			collider.SendMessage("TakeDamage");//发生碰撞后发送一条消息给Tank
		}
	}
}
