using UnityEngine;
using System.Collections;

public class ConnectToHeadset : MonoBehaviour {

    Headset headset;

#if UNITY_ANDROID && !UNITY_EDITOR

	void Start () {
        headset = new UnityThinkGear();
        headset.Connect();
	}

#else

    void Start() {
        headset = new RandomizedHeadset();
        headset.Connect();
    }

#endif
    void OnGUI() {
        GUI.Label(new Rect(10, 10, 200, 50), headset.GetConnectString());
        GUI.Label(new Rect(10, 60, 50, 50), headset.GetMeditation().ToString());
        GUI.Label(new Rect(10, 110, 50, 50), headset.GetPoorSignalValue().ToString());
    }

}
