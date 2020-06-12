using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DeadzoneEffect : MonoBehaviour
{
    private bool effectOn = false;
    [SerializeField] private UnityEngine.Rendering.VolumeProfile ppv;
    [SerializeField] private UnityEngine.Rendering.Universal.Vignette solarFlares;
    private bool GoingUp;
    [SerializeField] private float speed;
    [SerializeField] private float healthToLose;
    private float intensity;
    private float intensityZero;
    private Ship health;

    private void Start()
    {
        if (health == null) health = FindObjectOfType<Ship>();
        ppv.TryGet(out solarFlares);
        intensityZero = 0.0f ;
    }
    // Update is called once per frame
    void Update()
    {
        if (health == null) health = FindObjectOfType<Ship>();
        if (effectOn) HandleVignetteIntensity();
        else solarFlares.intensity.Override(intensityZero);
    }

    private void HandleVignetteIntensity()
    {
        if(GoingUp)
        {
            if (intensity >= 0.5f) GoingUp = false;
            intensity = new FloatParameter { value = Mathf.Lerp(solarFlares.intensity.GetValue<float>(), 1, Time.deltaTime * speed) };
        }
        else
        {
            if (intensity <= 0.25f) GoingUp = true;
            intensity = new FloatParameter { value = Mathf.Lerp(solarFlares.intensity.GetValue<float>(), 0, Time.deltaTime * speed) };
        }
        solarFlares.intensity.Override(intensity);
        health.Damage(Time.deltaTime * healthToLose);
    }

    public void TurnEffectOn()
    {
        effectOn = true;
    }
    public void TurnEffectOff()
    {
        effectOn = false;
    }
    public bool GetEffectOn()
    {
        return effectOn;
    }
}
