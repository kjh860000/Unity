using UnityEngine;

public class WirelessEarPhone3 : WirelessEarPhone2
{
    public enum NoiseCancelType {Off,On,Around}
    public NoiseCancelType noiseCancelType;

    public void SetNoiseCancelType(NoiseCancelType type)
    {
        noiseCancelType = type;
    }

    public override void NoiseCancelling()
    {
        SetNoiseCancelType(noiseCancelType);

        base.NoiseCancelling();
    }
}
