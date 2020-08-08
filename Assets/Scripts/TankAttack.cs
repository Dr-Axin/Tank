using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour {

	public GameObject shellPrefab;//声明子弹预制体
	public KeyCode fireKey = KeyCode.Space;//声明开火按键
	private Transform firePosition; //声明开火位置
	public float shellSpeed = 15;//声明子弹速度

	public AudioClip shellAudio;

	// Use this for initialization
	void Start () {
		firePosition = transform.Find("FirePosition");//获取开火位置

	}
	
	// Update is called once per frame
	void Update () {
		//检测：如果按下fireKey按键，那么实例化子弹预制体并且出现在开火位置处
		if (Input.GetKeyDown(fireKey)) {
			//子弹实例化为go
			GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation);
			//子弹速度
			//子弹刚体的水平方向速度 = 自身的向前方向 * 子弹速度
			go.GetComponent<Rigidbody>().velocity = transform.forward * shellSpeed;
			//子弹发射音效
			AudioSource.PlayClipAtPoint(shellAudio, transform.position);
		}
	}
}
