using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BGScrollData
{
    public Renderer RendererForScroll;
    public float Speed;
    public float OffsetX;
}

public class BG_Scroller : MonoBehaviour
{
    [SerializeField]    //Unity tool �ȿ��� ���� �����ϰ� ����ڴ�, Inspector �κп��� �ǵ帱 �� �ְ�!
    BGScrollData[] ScrollDatas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScroll();
    }

    void UpdateScroll()
    {
        for(int i=0; i<ScrollDatas.Length; i++)
        {
            SetTextureOffset(ScrollDatas[i]);
        }
    }

    void SetTextureOffset(BGScrollData scrollData)
    {
        scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime;
        if (scrollData.OffsetX > 1)
            scrollData.OffsetX = scrollData.OffsetX % 1.0f;
        Vector2 Offset = new Vector2(scrollData.OffsetX, 0);
        scrollData.RendererForScroll.material.SetTextureOffset("_MainTex", Offset);
    }
}
