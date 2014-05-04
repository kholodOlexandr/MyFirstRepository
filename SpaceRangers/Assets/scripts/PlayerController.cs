using UnityEngine;
using System.Collections;

public class PlayerController : AShip
{

	private Vector3 rotateVector;
	public Animator anim;
    bool isDead = false;
	void Start()
	{
		anim = GameObject.Find ("Explosion").GetComponent<Animator> ();
		health = 5;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (rigidbody.position.y > 3.5 && moveVertical > 0 || rigidbody.position.y < -3.2 && moveVertical < 0) {
			moveVertical = 0.0f;
				}
		if (rigidbody.position.x > 5 && moveHorizontal > 0 || rigidbody.position.x < -5 && moveHorizontal < 0) {
			moveHorizontal = 0.0f;
		}
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;

	}
	void Update()
	{
		if (health <= 0) {
            if (!isDead)
            {
                isDead = true;
                speed = 0;
                Death();
            }
		}
		else if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
			bulletInstance.rigidbody.velocity = new Vector2(0, 2);
			bulletInstance.tag = "player_bullet";
		}
	}
	public void Hurt()
	{
		health--;
	}
	void Death()
	{

		GameObject[] box = GameObject.FindGameObjectsWithTag ("enemy_ship");
		foreach (GameObject go in box) {
			Destroy(go);
				}
		GameObject eb = GameObject.Find ("Enemies");
		Destroy (eb);
		Animator a = Instantiate (anim, new Vector3(rigidbody.position.x, rigidbody.position.y + 0.3f, 0.0f), rigidbody.rotation) as Animator;
		Animator b = Instantiate (anim, new Vector3(rigidbody.position.x + 0.3f, rigidbody.position.y -0.3f, 0.0f), rigidbody.rotation) as Animator;
		Animator c = Instantiate (anim, new Vector3(rigidbody.position.x -0.3f, rigidbody.position.y -0.3f, 0.0f), rigidbody.rotation) as Animator;
		Destroy(this.gameObject, 2.0f);
		Destroy(a.gameObject, 1f);
		Destroy(b.gameObject, 1f);
		Destroy(c.gameObject, 1f);
		Invoke ("SceneChange", 1.0f);

	}
	void SceneChange()
	{
		print("in SceneChange");
		Application.LoadLevel (0);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "enemy_ship") {
						health--;
				}
	}

}
