using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeSkill1 : ObjectSkill
{
    [SerializeField] private float maxSlimeCanSummon;

    [SerializeField] private GameObject slime;

    [SerializeField] private Transform initalSummonPos;

    [SerializeField] private Transform endSummonPos;
    protected override void ConstructSkill()
    {
        SummonSlime();
    }

    public void SummonSlime() {
        for (int i = 0; i < maxSlimeCanSummon; i++) {
            Instantiate(slime, GetRandomPosSummon(), Quaternion.identity);
        }
        
    }

    public Vector2 GetRandomPosSummon() {

        float randomX = Random.Range(initalSummonPos.position.x, endSummonPos.position.x);

        return new Vector2(randomX, transform.position.y);
    }
}
