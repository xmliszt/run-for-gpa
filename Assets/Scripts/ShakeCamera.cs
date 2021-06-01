using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class ShakeCamera : MonoBehaviour
{
    public Camera cameraToShake;
    public ShakePreset presets;

    private Shaker shaker;
    private ShakeInstance shakeInstance;
    private void Awake()
    {
        shaker = cameraToShake.GetComponent<Shaker>();
    }

    public void StartShaking()
    {
        if (shakeInstance != null)
        {
            shakeInstance.Start(1f);
        } else
        {
            shakeInstance = shaker.Shake(presets);
        }
    }

    public void StopShaking()
    {
        shakeInstance.Stop(1f, false);
    }
}
