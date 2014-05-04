using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

	public float spawnTime = 3f;		
	public float spawnDelay = 2f;		
	public GameObject[] enemies;
	public Score score;
	private int lvl = 1;
	
	
	void Start ()
	{
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
		score = GameObject.Find ("Score text").GetComponent<Score>();
	}
	void Update()
	{
		if (score.score >= 1000 * lvl) {
			lvl++;
			spawnTime--;
            if (spawnTime > 0)
            {
                CancelInvoke();
                InvokeRepeating("Spawn", spawnDelay, spawnTime);
            }
				}
	}
	
	void Spawn ()
	{
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
	}
}
