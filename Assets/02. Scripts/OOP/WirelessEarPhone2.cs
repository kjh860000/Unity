using UnityEngine;

public class WirelessEarPhone2 : WirelessEarPhone
{
    //public float batterySize;
    //public bool isWirelessCharged;
    public bool isNoiseCancelling;

/*    public void Charged()
    {
        string msg = isWirelessCharged ? "무선충전" : "유선충전";
        Debug.Log(msg);
    }*/
    public virtual void NoiseCancelling()
    {
        isNoiseCancelling = !isNoiseCancelling;

        string msg = isNoiseCancelling ? "노이즈 캔슬링on" : "노이즈 캔슬링off";
        Debug.Log(msg);
    }
}
