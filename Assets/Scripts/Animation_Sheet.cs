using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Sheet : MonoBehaviour
{
    public Estados nombre;

    public List<Sprite> spriteList;

    public SpriteRenderer spriteRenderer;

    public int index = 0;

    public float frames = 24;

    public bool loopended = false;
    public bool loop = true;

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
        index = 0;
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
            if (loop)
                index = 0;
            else
                index--;

            loopended = true;
        }
    }
}
