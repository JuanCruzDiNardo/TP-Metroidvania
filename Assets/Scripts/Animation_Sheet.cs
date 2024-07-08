using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Sheet : MonoBehaviour
{
    public Estados nombre;

    public List<Sprite> spriteList;

    public SpriteRenderer spriteRenderer;

    public int index = 0;

    public float frames;

    public bool loopended = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimationStart()
    {
        loopended = false;
        InvokeRepeating("Load_Sprite", 0f, (float)1 / frames);
    }

    public void AnimationStop()
    {
        CancelInvoke("Load_Sprite");
    }

    public void Load_Sprite()
    {
        spriteRenderer.sprite = spriteList[index];
        index++;
        if (index == spriteList.Count)
        {
            index = 0;
            loopended = true;
        }
    }
}
