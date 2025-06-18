using UnityEngine;

public class WirelessEarPhone : EarPhone
{
    public float batterySize;
    public bool isWirelessCharged;

    public void Charged()
    {
        string msg = isWirelessCharged ? "��������" : "��������";
        Debug.Log(msg);
    }
}
