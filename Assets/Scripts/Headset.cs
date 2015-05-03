using UnityEngine;
using System.Collections;
using System;

public abstract class Headset {

    public abstract void Connect();
    public abstract void Disconnect();
    public abstract int GetAttention();
    public abstract int GetMeditation();
    public abstract int GetPoorSignalValue();
    public abstract float GetDelta();
    public abstract float GetTheta();
    public abstract float GetLowAlpha();
    public abstract float GetHighAlpha();
    public abstract float GetLowBeta();
    public abstract float GetHighBeta();
    public abstract float GetLowGamma();
    public abstract float GetHighGamma();
    public abstract float GetRaw();
    public abstract float GetBlink();
    public abstract int GetHeartRate();
    public abstract int GetRawCount();
    public abstract int GetConnectState();
    public abstract string GetConnectString();

}
