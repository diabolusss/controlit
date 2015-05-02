using UnityEngine;
using System.Collections;
using System;

public class UnityThinkGear {

    private AndroidJavaClass jc;
    private static AndroidJavaObject jo;

    public string connectStr = "Nothing!";

    // Use this for initialization
    public void Start() {
        jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        connect();
    }

    public void connect() {/*
      * 连接，并且发送RawData
      */
        jo.Call("connectWithRaw");
        connectStr = "connect!!!!";
    }
    public void disconnect() {
        jo.Call("disconnect");
    }
    public int getAttention() {
        return jo.Get<int>("attention");
    }
    public int getMeditation() {
        return jo.Get<int>("meditation");
    }
    public int getPoorSignalValue() {
        return jo.Get<int>("poorSignalValue");
    }
    public float getDelta() {
        return jo.Get<float>("delta");
    }
    public float getTheta() {
        return jo.Get<float>("theta");
    }
    public float getLowAlpha() {
        return jo.Get<float>("lowAlpha");
    }
    public float getHighAlpha() {
        return jo.Get<float>("highAlpha");
    }
    public float getLowBeta() {
        return jo.Get<float>("lowBeta");
    }
    public float getHighBeta() {
        return jo.Get<float>("highBeta");
    }
    public float getLowGamma() {
        return jo.Get<float>("lowGamma");
    }
    public float getHighGamma() {
        return jo.Get<float>("highGamma");
    }
    public float getRaw() {
        return jo.Get<float>("raw");
    }
    public float getBlink() {
        return jo.Get<float>("blink");
    }
    public int getHeartRate() {
        return jo.Get<int>("heartRate");
    }
    public int getRawCount() {
        return jo.Get<int>("rawCount");
    }
    public int getConnectState() {/*	Jar包中对连接状态的定义
      * public static final int STATE_IDLE = 0;
      * public static final int STATE_CONNECTING = 1;
      * public static final int STATE_CONNECTED = 2;
      * public static final int STATE_NOT_FOUND = 3;
      * public static final int STATE_NOT_PAIRED = 4;
      * public static final int STATE_DISCONNECTED = 5;
      * public static final int LOW_BATTERY = 6;
      * public static final int BULETOOTH_ERROR = 7;
     */
        return jo.Get<int>("connectState");
    }

}
