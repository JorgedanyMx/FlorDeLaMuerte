using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data")]
public class PlayerData : ScriptableObject
{
    public bool hasLight = false;
    public bool hasLightv2 = false;
    public bool hasDoubleJump = false;
    public void ResetPlayerData()
    {
        hasLight = false;
        hasLightv2 = false;
        hasDoubleJump = false;
    }
}