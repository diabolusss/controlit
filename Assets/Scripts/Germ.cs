using UnityEngine;
using System.Collections;

public class Germ : MonoBehaviour {

    private bool hopping = true;
    private bool movingUp = true;
    private bool followingPlayer = false;

    private float speed;

    void Awake() {
        speed = Random.Range(5, 7);
    }
	
	void Update () {
        if (hopping == true) {
            if (movingUp == true) {

            }
        }
	}
}
