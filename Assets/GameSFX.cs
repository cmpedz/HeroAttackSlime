using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSFX", menuName ="Music/GameSFX")]
public class GameSFX : ScriptableObject
{

    public AudioClip playerAttack;

    public AudioClip slimeAttack;

    public AudioClip slimeHurt;

    public AudioClip slimeDied;

    public AudioClip BgMusic;

    public AudioClip kingSlimeJump;

    public AudioClip kingSlimeUseSpecialSkill;

}
