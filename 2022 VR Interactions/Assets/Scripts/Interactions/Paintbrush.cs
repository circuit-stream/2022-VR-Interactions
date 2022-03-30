using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class Paintbrush : XRGrabInteractable
{
    public GameObject paintPrefab;
    public Color color;
    private GameObject spawnedPaint;
    private PaintbrushTip paintbrushTip;
    private bool triggerDown;
    private float triggerHeldTime;

    
    void Start()
    {
        activated.AddListener(TriggerPulled);
        deactivated.AddListener(TriggerReleased);
        paintbrushTip = GetComponentInChildren<PaintbrushTip>();
    }

    
    void Update()
    {
        if (triggerDown)
        {
            triggerHeldTime += Time.deltaTime;

            if (spawnedPaint)
            {
                spawnedPaint.transform.position = paintbrushTip.transform.position;
            }
        }
    }

    private void TriggerPulled(ActivateEventArgs args)
    {
        spawnedPaint = Instantiate(paintPrefab, paintbrushTip.gameObject.transform.position, paintbrushTip.gameObject.transform.rotation);
        Material trailMaterial = spawnedPaint.GetComponent<TrailRenderer>().material;
        trailMaterial.color = paintbrushTip.color;
        triggerDown = true;
    }

    private void TriggerReleased(DeactivateEventArgs args)
    {
        spawnedPaint.transform.position = spawnedPaint.transform.position;
        spawnedPaint = null;
        triggerDown = false;
    }
}
