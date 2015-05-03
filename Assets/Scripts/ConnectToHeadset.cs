using UnityEngine;
using System.Collections;

public class ConnectToHeadset : MonoBehaviour {

    Headset headset;
    GUIStyle style = new GUIStyle();

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
        GUI.Label(new Rect(10, 10, 200, 50), headset.GetConnectString(), style);
        GUI.Label(new Rect(10, 60, 50, 50), headset.GetMeditation().ToString(), style);
        GUI.Label(new Rect(10, 110, 50, 50), headset.GetPoorSignalValue().ToString(), style);
    }


    void Update() {
        CheckMeditation();
    }

    public Material monsterMat;

    void CheckMeditation() {
        int meditation = headset.GetMeditation();

        if (meditation >= 50) {
            monsterMat.SetFloat("_Blend", Mathf.Clamp01(monsterMat.GetFloat("_Blend") + 0.01f));
        }
        else  {
            monsterMat.SetFloat("_Blend", Mathf.Clamp01(monsterMat.GetFloat("_Blend") - 0.01f));
        }
    }

}
