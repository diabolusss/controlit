using UnityEngine;
using System.Collections;

public class RandomizedHeadset : Headset {

    private int attention = 0;
    private int meditation = 0;
    private int poorSignal = 0;
    private float delta = 0;
    private float theta = 0;
    private float lowAlpha = 0;
    private float highAlpha = 0;
    private float lowBeta = 0;
    private float highBeta = 0;
    private float lowGamma = 0;
    private float highGamma = 0;
    private float raw = 0;
    private float blink = 0;
    private int heartRate = 0;
    private int rawCount = 0;

    private int intTrend = 1;
    private int floatTrend = 1;

    private int RandomInt(int value) {
        int newValue = value + (Random.Range(0, 3) * intTrend);
        if (newValue > 100 || newValue < 0){
            intTrend *= -1;
        }
        return Mathf.Clamp(newValue, 0, 100);
    }

    private float RandomFloat(float value) {
        float newValue = value + (Random.Range(0, 5f) * floatTrend);
        if (newValue > 100 || newValue < 0) {
            floatTrend *= -1;
        }
        return Mathf.Clamp(newValue, -255, 255);
    }

    public override void Connect() {

    }
    public override void Disconnect() {

    }

    public override int GetAttention() {
        attention = RandomInt(attention);
        return attention;
    }
    public override int GetMeditation() {
        meditation = RandomInt(meditation);
        return meditation;
    }
    public override int GetPoorSignalValue() {
        poorSignal = RandomInt(poorSignal);
        return poorSignal;
    }
    public override float GetDelta() {
        delta = RandomFloat(delta);
        return delta;
    }
    public override float GetTheta() {
        theta = RandomFloat(theta);
        return theta;
    }
    public override float GetLowAlpha() {
        lowAlpha = RandomFloat(lowAlpha);
        return lowAlpha;
    }
    public override float GetHighAlpha() {
        highAlpha = RandomFloat(highAlpha);
        return highAlpha;
    }
    public override float GetLowBeta() {
        lowBeta = RandomFloat(lowBeta);
        return lowBeta;
    }
    public override float GetHighBeta() {
        highBeta = RandomFloat(highBeta);
        return highBeta;
    }
    public override float GetLowGamma() {
        delta = RandomFloat(delta);
        return delta;
    }
    public override float GetHighGamma() {
        highGamma = RandomFloat(highGamma);
        return highGamma;
    }
    public override float GetRaw() {
        raw = RandomFloat(raw);
        return raw;
    }
    public override float GetBlink() {
        blink = RandomFloat(blink);
        return blink;
    }
    public override int GetHeartRate() {
        heartRate = RandomInt(heartRate);
        return heartRate;
    }
    public override int GetRawCount() {
        rawCount++;
        return rawCount;
    }
    public override int GetConnectState() {
        return 2;
    }

    public override string GetConnectString() {
        return "STATE_RANDOM";
    }

}