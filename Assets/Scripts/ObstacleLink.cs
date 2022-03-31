using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLink : MonoBehaviour
{
    public GameObject obstacle;

    private void OnCollisionEnter2D(Collision2D collision) 
	{
		// Player is the female character.
		if (collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("Male")) {
            Destroy(obstacle);
		}
	}


    // Update is called once per frame
    void Update()
    {
        
    }
}
