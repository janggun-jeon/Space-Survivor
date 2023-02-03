using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Monster
{
    float time;
    float curve;

    void Start()
    {
        base.Start();

        name = "Bat";
        speed = 3f;
        curve = 0.4f;
        
        CurveMove(0, 0f);
    }

    void Update()
    {
        base.Update();

        // 포물선 이동
        time += Time.deltaTime;
        if (time < 1f) { CurveMove(1, 1f - time); }
        else if (time < 2f) { CurveMove(2, time - 1f); }
        else { CurveMove(0, 0f); time = 0f; }
    }

    void CurveMove(int mode, float weight)
    {
        if (mode == 0)
        {
            weight = Random.Range(0, 2);
            xInput = (2f * Random.Range(1, 3) - 3f) * weight;
            weight = 1f - weight;
            yInput = (2f * Random.Range(1, 3) - 3f) * weight;

            xSpeed = xInput * speed;
            ySpeed = yInput * speed;

            monsterVelocity = new Vector2(xSpeed, ySpeed);
        }
        else if (mode == 1)
        {
            monsterVelocity = new Vector2(xSpeed + ySpeed * weight * curve, ySpeed - xSpeed * weight * curve);
        }
        else if (mode == 2)
        {
            monsterVelocity = new Vector2(xSpeed - ySpeed * weight * curve, ySpeed + xSpeed * weight * curve);
        }
        monsterRigidbody.velocity = monsterVelocity;
    }
}
