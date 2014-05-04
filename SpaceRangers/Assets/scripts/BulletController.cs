using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	public string shooterTag;
	public GameObject player;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 4);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "enemy_ship" && gameObject.tag != "enemy_bullet") {
						other.gameObject.GetComponent<EnemyController> ().Hurt ();
						OnExplode ();
						Destroy (gameObject);
				} else if (other.tag == "player_ship" && gameObject.tag != "player_bullet") {
						other.gameObject.GetComponent<PlayerController> ().Hurt ();
						OnExplode ();
						Destroy (gameObject);
				}
	}
	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		//Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		
		// Instantiate the explosion where the rocket is with the random rotation.
		//Instantiate(explosion, transform.position, randomRotation);
	}
}
