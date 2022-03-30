using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintbrushTip : MonoBehaviour
{
    public Color color;

    public void ChangePaint(Image image)
    {
        color = image.color;
    }
}