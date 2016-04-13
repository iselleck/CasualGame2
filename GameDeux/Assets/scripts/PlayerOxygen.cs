using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerOxygen : MonoBehaviour {
	public int startingOx;
	public float currentOx;
	public Slider oxyLvl; 
	private float time;

	// Use this for initialization
	void Start () {

		currentOx = startingOx;
	
	}
	
	// Update is called once per frame
	void Update () {
		oxyLvl.value = currentOx; 

		currentOx -= 1 * Time.deltaTime;
	}
}
