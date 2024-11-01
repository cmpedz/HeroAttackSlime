using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSkillsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<ObjectSkill> objectSkills = new List<ObjectSkill>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ObjectSkill skill in objectSkills) { 
            skill.UseSkill();
        }
    }
}
