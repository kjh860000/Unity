using UnityEngine;

public class WirelessEarPhone2 : WirelessEarPhone
{
    //public float batterySize;
    //public bool isWirelessCharged;
    public bool isNoiseCancelling;

/*    public void Charged()
    {
        string msg = isWirelessCharged ? "��������" : "��������";
        Debug.Log(msg);
    }*/
    public virtual void NoiseCancelling()
    {
        isNoiseCancelling = !isNoiseCancelling;

        string msg = isNoiseCancelling ? "������ ĵ����on" : "������ ĵ����off";
        Debug.Log(msg);
    }
}
