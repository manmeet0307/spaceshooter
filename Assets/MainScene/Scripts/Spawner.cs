using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{



	
	
	public Transform spawnPoint;

	public float minDistance;
	public float startDelay;
	
	[Range(0.5f,10.0f)]
	public float generalDelay;
	
	[Range(0.0f,1.0f)]
	public float decreaseRate;


	public GameObject prefab;
	
	
	
		
	private float lastTime;


	private void Awake(){
		lastTime = Time.realtimeSinceStartup;
		
	}

	void Start (){

		StartCoroutine(spawning());

	}

	IEnumerator spawning(){

		
		yield return new WaitForSeconds(startDelay);




		
		Vector3 prevpos = Vector3.zero;

		while (true){

			var pos = new Vector3(Random.Range(-spawnPoint.position.x,spawnPoint.position.x),spawnPoint.position.y,spawnPoint.position.z);
			if (Mathf.Abs(pos.x - prevpos.x )<= minDistance){	
				pos.x = prevpos.x +(pos.x-prevpos.x)<=0?-minDistance:minDistance;
			}
			
			
			pos.x = Mathf.Clamp(pos.x,-Mathf.Abs(spawnPoint.position.x),Mathf.Abs(spawnPoint.position.x));

			
			prevpos = pos;

			Instantiate(prefab,pos,Quaternion.identity,null);
			
			yield return new WaitForSeconds(generalDelay);
			
			
		}
		
	}


	private void Update(){
	
		if (Time.realtimeSinceStartup - lastTime >= 10){
			generalDelay = Mathf.Max(0.5f,(1-decreaseRate)*generalDelay);
			lastTime = Time.realtimeSinceStartup;
				
		}

	}

	
}
