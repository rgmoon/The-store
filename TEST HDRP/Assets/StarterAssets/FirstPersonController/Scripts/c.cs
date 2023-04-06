using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c : MonoBehaviour
{
    public Vector3 camerapos;
    public float shakeDuration = 0.5f; 
    public AnimationCurve shakeamount;
    public AnimationCurve shaketime;
    float shaketimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shaketimer > 0)
        {
            // 計算晃動幅度，使用強度曲線和速度曲線調整幅度
            float intensity = shakeamount.Evaluate(shaketimer / shakeDuration);
            float speed = shaketime.Evaluate(shaketimer / shakeDuration);

            // 在鏡頭的初始位置上加上一個隨機偏移量，用於產生晃動效果
            transform.position = camerapos + Random.insideUnitSphere * intensity;

            // 減少計時器
            shaketimer -= Time.deltaTime * speed;
        }
        else
        {
            // 如果計時器小於或等於零，則將鏡頭位置重置為初始位置
            transform.position = camerapos;
        }
        
    }
        public void Shake()
    {
        camerapos = transform.position;
        shaketimer = shakeDuration;
    }
}
