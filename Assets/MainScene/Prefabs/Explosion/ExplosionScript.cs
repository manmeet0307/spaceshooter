using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour{

	
	
	public delegate void OnCompleteAnimation(); 

	private void Awake(){
		anim = GetComponent<Animator>();

	}


	public void EndedExplosion(){
		callback();
	}
	
	


	public void show(OnCompleteAnimation callback){
		//transition from idle state to explode
		anim.SetTrigger("Explode");
		this.callback = callback;
	}
	
	
	
	private Animator anim;
	private OnCompleteAnimation callback;

}
