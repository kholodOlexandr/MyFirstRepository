using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private PlayerController player;
	private SpriteRenderer healthBar;
	private Vector3 healthScale;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		healthBar = GameObject.Find("healthBar").GetComponent<SpriteRenderer>();
		healthScale = healthBar.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.transform.localScale = new Vector3(1, healthScale.x * player.health * 0.4f, 1);
	}
}
