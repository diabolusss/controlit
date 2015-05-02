using UnityEngine;
using System.Collections;

public class ConnectToHeadset : MonoBehaviour {

#if UNITY_ANDROID && !UNITY_EDITOR

    private UnityThinkGear unityThinkGear;

	void Start () {
        unityThinkGear = new UnityThinkGear();
        unityThinkGear.Start();
	}

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 50, 100), unityThinkGear.connectStr);
        GUI.Label(new Rect(10, 70, 50, 100), unityThinkGear.getMeditation().ToString());
        GUI.Label(new Rect(10, 110, 50, 100), unityThinkGear.getPoorSignalValue().ToString());
    }
#endif
}
