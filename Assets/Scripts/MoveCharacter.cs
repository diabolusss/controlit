using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

    public GameObject player;
    public Animation playerAnim;

    private Vector3 moveTarget;
    private bool moving = false;
	
	// Update is called once per frame
	void Update () {
        if (moving == true) {
            playerAnim.Play("Walk");
            player.transform.position = Vector3.MoveTowards(player.transform.position, moveTarget, Time.deltaTime * 2);
        }
        if (player.transform.position == moveTarget) {
            moving = false;
            playerAnim.Play("Stand");
        }
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1<<8)){
                moveTarget = hit.point;
                moving = true;
            }
            player.transform.LookAt(moveTarget);

        }
	}
}
