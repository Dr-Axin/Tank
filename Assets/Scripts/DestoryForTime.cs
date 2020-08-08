using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryForTime : MonoBehaviour {

	public float time;//声明时间

	// Use this for initialization
	void Start() {
		Destroy(this.gameObject, time);//子弹定时销毁
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
