using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public Transform player1;
	public Transform player2;

	private Camera camera;//声明相机组件
	private Vector3 offset;//声明偏移量

	// Use this for initialization
	void Start () {
		//相机的偏移量 = 自身的位置-Tank的中心位置（使相机视角始终保持在两个Tank的中心位置）
		offset = transform.position - (player1.position + player2.position)/2;
		//得到相机组件
		camera = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		//判断：若有任何一方Tank被销毁那么直接返回，不做视野跟随
		//不做判断时，因为一方Tank被销毁会产生空指针而报错
		if (player1 == null || player2 == null) return;
		//控制相机视角位置
		//相机位置 = Tank中心位置 + 偏移量
		transform.position = (player1.position + player2.position) / 2 + offset;
		//控制相机视角缩放
		//确定Tank之间的距离
		float distance = Vector3.Distance(player1.position, player2.position);
		//缩放的比例 = Tank距离 * 缩放比例（相机视角大小/Tank间距离 = 7/(8+2)）
		float size = distance * 0.7f;
		//相机的缩放比例
		camera.orthographicSize = size;//相机的正交大小 = 缩放比例

	}
}
