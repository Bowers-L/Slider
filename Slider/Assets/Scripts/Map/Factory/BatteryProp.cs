using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryProp : MonoBehaviour
{
    //[SerializeField] private SpriteSwapper spriteSwapper;

    private bool isGateEnabled;
    private bool isDiodeEnabled;

    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite enabledSprite;
    [SerializeField] private Sprite poweredSprite;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem particlesBurst;
    [SerializeField] private ParticleSystem particlesConducting;


    public void SetGateEnabled(bool value)
    {
        if (value && !isGateEnabled)
        {
            particlesBurst.Play();
        }

        isGateEnabled = value;
        UpdateSprite();
    }

    public void SetDiodeEnabled(bool value)
    {
        if (value)
        {
            particlesConducting.Play();
            if (!isDiodeEnabled)
            {
                particlesBurst.Play();
            }
        }
        else
        {
            particlesConducting.Stop();
        }

        isDiodeEnabled = value;
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        if (isDiodeEnabled)
        {
            spriteRenderer.sprite = poweredSprite;
        }
        else if (isGateEnabled)
        {
            spriteRenderer.sprite = enabledSprite;
        }
        else
        {
            spriteRenderer.sprite = offSprite;
        }
    }
}