using UnityEngine;
using System.Collections;

public class AudioPlay : MonoBehaviour {

	public AudioClip clip;
	public AudioSource music;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		float pitch = Random.Range (0,20);

		pitch = music.pitch / 10;
		//music.

		if( music.time > 0.7f ) 
		{
			music.Stop();
			music.time = 0;

			music.Play();
		}


	}
}
