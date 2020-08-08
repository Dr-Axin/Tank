using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

	public float speed = 5;
	public float angularSpeed = 5;//角速度控制旋转（30度/秒）
	public float number = 1;//Tanks编号（区分不同的方向键盘控制）
	public AudioClip idleAudio;
	public AudioClip drivingAudio;

	private AudioSource audio;
	private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = this.GetComponent<Rigidbody>();//通过泛型明确类型
		audio = this.GetComponent("AudioSource") as AudioSource;//通过字符串转换用as进行强制类型转换为AudioSource
	} 

	//FixedUpdate在固定帧调用,一般关于位移的操作代码放在FixedUpdate中
	void FixedUpdate() {
		//控制前后行径
		float v = Input.GetAxis("VerticalPlayer" + number);//Vertical水平方向
		//刚体的水平方向（Tank前后） = 自身的前方向 * v（-1~1代表了前后方向）* 速度
		rigidbody.velocity = transform.forward * v * speed;

		//控制左右方向旋转
		float h = Input.GetAxis("HorizontalPlayer" + number);//Horizontal垂直方向
		//刚体垂直方向旋转（角速度） = 自身的竖直方向 * h（角度）* 角速度
		rigidbody.angularVelocity = transform.up * h * angularSpeed;

		//判断：如果Tank移动或者转向则播放行径音效，否则为静止音效
		if(Mathf.Abs(h) > 0.1 ||Mathf.Abs(v) > 0.1) { //Mathf.Abs()取绝对值
			audio.clip = drivingAudio;
			//判断若当前没有播放就进行播放
			if(audio.isPlaying == false)
			audio.Play();
		} else {
			audio.clip = idleAudio;
			if(audio.isPlaying == false)
			audio.Play();
		}
	} 
}
