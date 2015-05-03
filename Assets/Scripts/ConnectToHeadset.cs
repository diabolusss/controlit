using UnityEngine;
using System.Collections;

public class ConnectToHeadset : MonoBehaviour {

    Headset headset;
    GUIStyle style = new GUIStyle();

    public Transform meditationBar;

    void Awake() {
        style.fontSize = 30;
        style.normal.textColor = Color.white;
    }

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
        //GUI.Label(new Rect(10, 10, 200, 50), headset.GetConnectString(), style);
        GUI.Label(new Rect(10, 60, 50, 50), meditation.ToString(), style);
        //GUI.Label(new Rect(10, 110, 50, 50), headset.GetPoorSignalValue().ToString(), style);
    }


    void Update() {
        CheckMeditation();
    }

    public Material monsterMat;
    int meditation = 0;

    void CheckMeditation() {
        meditation = headset.GetMeditation();
        float scale = (float)meditation / 20;
        meditationBar.localScale = new Vector3(scale, meditationBar.localScale.y, meditationBar.localScale.z);
        meditationBar.position = new Vector3((scale / 2) - 2.5f, meditationBar.position.y, meditationBar.position.z);

    }

}
