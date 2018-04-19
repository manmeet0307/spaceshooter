using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour{




	//TODO move health to scripable object for different bullets
	public int health = 1;
	public float bulletSpeed = 5;


	

	public static GameObject CreateBullet(GameObject bulletPrefab,GameObject firer,Vector3 delta){

		GameObject g = Instantiate(bulletPrefab, firer.transform.position+delta, Quaternion.identity, null);
		g.GetComponent<BulletScript>().firer = firer;
		return g;

	}

	public GameObject getFirer(){
		return firer;
	}


	private void OnTriggerEnter2D(Collider2D other){
		//decrease health only if not colliding with firer
		if (health > 0 && other.gameObject!=firer){
			health--;
		}

	}



	void Update (){
		if (health == 0){
			--health;
			Destroy(gameObject);
		}
		else if (health > 0){

			transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
		}
	}
	private GameObject firer;

}
