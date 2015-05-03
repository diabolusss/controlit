using UnityEngine;
using System.Collections;
using System;

public class UnityThinkGear : Headset {

    private AndroidJavaClass jc;
    private static AndroidJavaObject jo;

    public override void Connect() {
        if (jc == null) {
            jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        }
        if (jo == null) {
            jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

        }
        jo.Call("connectWithRaw");
    }
    public override void Disconnect() {
        jo.Call("disconnect");
    }
    public override int GetAttention() {
        return jo.Get<int>("attention");
    }
    public override int GetMeditation() {
        return jo.Get<int>("meditation");
    }
    public override int GetPoorSignalValue() {
        return jo.Get<int>("poorSignalValue");
    }
    public override float GetDelta() {
        return jo.Get<float>("delta");
    }
    public override float GetTheta() {
        return jo.Get<float>("theta");
    }
    public override float GetLowAlpha() {
        return jo.Get<float>("lowAlpha");
    }
    public override float GetHighAlpha() {
        return jo.Get<float>("highAlpha");
    }
    public override float GetLowBeta() {
        return jo.Get<float>("lowBeta");
    }
    public override float GetHighBeta() {
        return jo.Get<float>("highBeta");
    }
    public override float GetLowGamma() {
        return jo.Get<float>("lowGamma");
    }
    public override float GetHighGamma() {
        return jo.Get<float>("highGamma");
    }
    public override float GetRaw() {
        return jo.Get<float>("raw");
    }
    public override float GetBlink() {
        return jo.Get<float>("blink");
    }
    public override int GetHeartRate() {
        return jo.Get<int>("heartRate");
    }
    public override int GetRawCount() {
        return jo.Get<int>("rawCount");
    }
    public override int GetConnectState() {
        return jo.Get<int>("connectState");
    }

    public override string GetConnectString() {
        int state = jo.Get<int>("connectState");
        if (state == 0){
            return "STATE_IDLE";
        }
        else if (state == 1){
            return "STATE_CONNECTING";
        }
        else if (state == 2){
            return "STATE_CONNECTED";
        }
        else if (state == 3){
            return "STATE_NOT_FOUND";
        }
        else if (state == 4){
            return "STATE_NOT_PAIRED";
        }
        else if (state == 5){
            return "STATE_DISCONNECTED";
        }
        else if (state == 6){
            return "LOW_BATTERY";
        }
        else if (state == 7){
            return "BULETOOTH_ERROR";
        }

        return "";
    }

}