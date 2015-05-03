using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

    public GameObject player;
    public Animation playerAnim;
    private Vector3 playerInitialPosition;
    private Vector3 playerInitialRotation;

    public Transform cameraTransform;
    private Vector3 cameraInitialPosition;
    private Vector3 cameraInitialRotation;

    private Vector3 moveTarget;
    private bool moving = false;

    public GameObject sink;
    private Renderer sinkRenderer;
    public GameObject toilet;
    private Renderer toiletRenderer;
    public GameObject tub;
    private Renderer tubRenderer;
    float offset = 0;
    public Transform sinkLookAt;
    public Transform toiletLookAt;
    public Transform tubLookAt;
    public Transform sinkMoveTo;
    public Transform toiletMoveTo;
    public Transform tubMoveTo;

    private Transform cameraInitialTransform;
    public Transform sinkCameraMoveTo;      // -1.3, 1.26, -4.63    11, 38, 0
    public Transform toiletCameraMoveTo;    // 0, 1.1, -5           11, 310, 0
    public Transform tubCameraMoveTo;       // .95, 1.7, -6.75      11, 18, 0
    private Transform cameraMoveTarget;
    private bool cameraMoving = false;


    private enum Location { Start, Sink, Toilet, Tub }
    private Location location = Location.Start;

    void Awake() {
        sinkRenderer = sink.GetComponent<Renderer>() as Renderer;
        toiletRenderer = toilet.GetComponent<Renderer>() as Renderer;
        tubRenderer = tub.GetComponent<Renderer>() as Renderer;
        GameObject go = new GameObject();
        go.transform.position = cameraTransform.position;
        go.transform.rotation = cameraTransform.rotation;
        cameraInitialTransform = go.transform;
        cameraMoveTarget = cameraInitialTransform;
        
        playerInitialPosition = player.transform.position;
        playerInitialRotation = player.transform.eulerAngles;
    }



    void Update () {
        SetTexture();
        Walk();
        SetCamera();
	}

    float rotateSpeed = 53;
    float moveSpeed = 4;

    void SetCamera() {
        if (cameraMoving == true){
            if (location == Location.Toilet) {
                rotateSpeed = 53;
                moveSpeed = 4;
            }
            else if (location == Location.Sink) {
                rotateSpeed = 35;
                moveSpeed = 4;
            }
            else if (location == Location.Tub) {
                rotateSpeed = 32;
                moveSpeed = 4;
            }
            cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, cameraMoveTarget.position, Time.deltaTime * moveSpeed);
            float x = Mathf.MoveTowardsAngle(cameraTransform.eulerAngles.x, cameraMoveTarget.eulerAngles.x, Time.deltaTime * rotateSpeed);
            float y = Mathf.MoveTowardsAngle(cameraTransform.eulerAngles.y, cameraMoveTarget.eulerAngles.y, Time.deltaTime * rotateSpeed);
            float z = Mathf.MoveTowardsAngle(cameraTransform.eulerAngles.z, cameraMoveTarget.eulerAngles.z, Time.deltaTime * rotateSpeed);
            cameraTransform.eulerAngles = new Vector3(x, y, z);
            if (Vector3.Distance(cameraTransform.position, cameraMoveTarget.position) < 0.02f) {
                cameraMoving = false;
            }
        }
    }

    void SetTexture() {
        offset += Time.deltaTime / 5;
        if (offset > 1){ offset -= 1; }
        if (location == Location.Sink) {
            sinkRenderer.material.SetTextureOffset("_PathTex", new Vector2(offset, 0));
            sinkRenderer.material.SetTextureOffset("_PathMask", new Vector2(offset, 0));
        }
        else if (location == Location.Toilet) {
            toiletRenderer.material.SetTextureOffset("_PathTex", new Vector2(offset, 0));
            toiletRenderer.material.SetTextureOffset("_PathMask", new Vector2(offset, 0));
        }
        else if (location == Location.Tub) {
            tubRenderer.material.SetTextureOffset("_PathTex", new Vector2(offset, 0));
            tubRenderer.material.SetTextureOffset("_PathMask", new Vector2(offset, 0));
        }
    }

    void ResetTextures() {
        offset = 0;
        sinkRenderer.material.SetTextureOffset("_PathTex", new Vector2(0, 0));
        sinkRenderer.material.SetTextureOffset("_PathMask", new Vector2(0, 0));
        toiletRenderer.material.SetTextureOffset("_PathTex", new Vector2(0, 0));
        toiletRenderer.material.SetTextureOffset("_PathMask", new Vector2(0, 0));
        tubRenderer.material.SetTextureOffset("_PathTex", new Vector2(0, 0));
        tubRenderer.material.SetTextureOffset("_PathMask", new Vector2(0, 0));

    }

    void Walk() {
        if (moving == true) {
            playerAnim.Play("Walk");
            player.transform.position = Vector3.MoveTowards(player.transform.position, moveTarget, Time.deltaTime * 2);
        }
        if (player.transform.position == moveTarget && moving == true) {
            moving = false;
            cameraMoving = true;
            WalkTo(location);
            playerAnim.Play("Stand");
            playerAnim["Stand"].speed = 0;
        }
        if (Input.GetMouseButtonDown(0) && location == Location.Start && moving == false && cameraMoving == false) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1 << 8)) {
                if (hit.collider.gameObject.name == "Toilet Target") {
                    moving = true;
                    WalkTo(Location.Toilet);
                }
                else if (hit.collider.gameObject.name == "Sink Target") {
                    moving = true;
                    WalkTo(Location.Sink);
                }
                else if (hit.collider.gameObject.name == "Tub Target") {
                    moving = true;
                    WalkTo(Location.Tub);
                }
                //moveTarget = new Vector3(hit.point.x, 0, hit.point.z);
            }
        }

        else if (Input.GetMouseButtonDown(0) && location != Location.Start && moving == false && cameraMoving == false) {
            moving = true;
            WalkTo(Location.Start);
        }
    }

    void WalkTo(Location newLocation) {
        NewTarget(newLocation);
        if (location == Location.Tub) {
            moveTarget = tubMoveTo.position;
            cameraMoveTarget = tubCameraMoveTo;
            if (moving == true) {
                player.transform.LookAt(new Vector3(moveTarget.x, 0, moveTarget.z));
            }
            else {
                player.transform.LookAt(new Vector3(tubLookAt.position.x, 0, tubLookAt.position.z));
            }
        }
        else if (location == Location.Sink) {
            moveTarget = sinkMoveTo.position;
            cameraMoveTarget = sinkCameraMoveTo;
            if (moving == true) {
                player.transform.LookAt(new Vector3(moveTarget.x, 0, moveTarget.z));
            }
            else {
                player.transform.LookAt(new Vector3(sinkLookAt.position.x, 0, sinkLookAt.position.z));
            }
        }
        else if (location == Location.Toilet) {
            moveTarget = toiletMoveTo.position;
            cameraMoveTarget = toiletCameraMoveTo;
            if (moving == true) {
                player.transform.LookAt(new Vector3(moveTarget.x, 0, moveTarget.z));
            }
            else {
                player.transform.LookAt(new Vector3(toiletLookAt.position.x, 0, toiletLookAt.position.z));
            }
        }
        else if (location == Location.Start) {
            moveTarget = playerInitialPosition;
            cameraMoveTarget = cameraInitialTransform;
            cameraMoving = true;
            if (moving == true) {
                player.transform.LookAt(new Vector3(moveTarget.x, 0, moveTarget.z));
            }
            else {
                player.transform.eulerAngles = playerInitialRotation;
            }
        }
        player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);

    }

    void NewTarget(Location newLocation) {
        if (newLocation == location) {
            return;
        }
        else {
            cameraMoving = false;
            location = newLocation;
            ResetTextures();
        }
    }
}
