using UnityEngine;

public class WirelessEarPhone : EarPhone
{
    public float batterySize;
    public bool isWirelessCharged;

    public void Charged()
    {
        string msg = isWirelessCharged ? "무선충전" : "유선충전";
        Debug.Log(msg);
    }
}
