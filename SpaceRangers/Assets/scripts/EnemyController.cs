using UnityEngine;
using System.Collections;

public class EnemyController : AShip {

	public GameObject player;
	public Score score;
	public Animator anim; 

	public float timeToFire;
	private float timeToMove = 1.2f;
	Vector3 movement;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find ("Explosion").GetComponent<Animator> ();
		score = GameObject.Find ("Score text").GetComponent<Score>();
		player = GameObject.Find ("Player");

		InvokeRepeating ("MoveToAttack", 1, timeToMove);
		InvokeRepeating ("Fire", 2, timeToFire);
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			Death();
				}

	}
	void Fire()
	{
		GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
		bulletInstance.rigidbody.velocity = new Vector2(0, -2);
		bulletInstance.tag = "enemy_bullet";
	}
	public void Hurt()
	{
		health--;
	}
	void MoveToAttack()
	{
		//Random.seed = (int)(Time.time * 10);
		float offsetVertical = (float)Random.Range (0, 10) / 10;
		float offsetHorizontal = (float)Random.Range (-10, 10) / 10;
		print ("offsetVertical" + offsetVertical);
		print ("offsetHorizontal" + offsetHorizontal);
		if (this.rigidbody.position.y > 3) {
			movement = new Vector3 (0.0f, -1, 0.0f);
				} else {
			if(player.rigidbody.position.x + offsetHorizontal > rigidbody.position.x)
			{
				offsetHorizontal = 1;
			}else{
				offsetHorizontal = -1;
			}
			if(player.rigidbody.position.y + 1 + offsetVertical < rigidbody.position.y)
			{
				offsetVertical = 1;
			}
			movement = new Vector3(offsetHorizontal, offsetVertical, 0.0f);
				}
	}
	void FixedUpdate()
	{
		//MoveToAttack ();
		rigidbody.velocity = movement * speed;
		//rigidbody.velocity = (movement * speed);
	}
	void Death()
	{
		score.score += 100;
		Animator a = Instantiate (anim, rigidbody.position, rigidbody.rotation) as Animator;
		Destroy(this.gameObject);
		Destroy(a.gameObject, 0.3f);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "player_ship") {
						health = 0;
				}
	}
}
