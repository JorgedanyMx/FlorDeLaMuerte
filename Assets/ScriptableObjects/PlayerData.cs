using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data")]
public class PlayerData : ScriptableObject
{
    public bool hasLight = false;
    public bool hasLightv2 = false;
    public bool hasDoubleJump = false;
    Vector3 checkpointposition = Vector3.zero;
    public bool controlEnable=true;
    public void ResetPlayerData()
    {
        hasLight = false;
        hasLightv2 = false;
        hasDoubleJump = false;
        controlEnable = true;
}
    public bool HasAllRemembers()
    {
        return hasLight & hasLightv2 & hasDoubleJump;
    }
    public void SetCheckpointPosition(Vector3 newPos)
    {
        checkpointposition = newPos;
    }
    public Vector3 LastCheckpointPosition()
    {
        return checkpointposition;
    }
}
