using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairUIFollowMouse : MonoBehaviour
{
    public Canvas canv;
    RectTransform rt;
    // Start is called before the first frame update
    void Awake()
    {
        rt = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canv.transform as RectTransform, Input.mousePosition, canv.worldCamera, out pos);
        transform.position = canv.transform.TransformPoint(pos);
        //rt.anchoredPosition = Input.mousePosition;
    }
}
