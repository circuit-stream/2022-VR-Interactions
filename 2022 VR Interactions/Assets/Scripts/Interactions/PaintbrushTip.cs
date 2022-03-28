using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintbrushTip : MonoBehaviour
{
    public Material paint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Paint")
        {
            paint = other.GetComponent<Renderer>().material;
            this.GetComponent<Renderer>().material = paint;
        }
        else if (other.tag == "Paintable")
        {
            other.GetComponent<Renderer>().material = paint;
        }
    }
}