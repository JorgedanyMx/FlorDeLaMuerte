using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        playerData.ResetPlayerData();
    }
    public PlayerData playerData;


    public void LevelUpLight()
    {
        if (playerData.hasLight) return;
        playerData.hasLight = true;
        Debug.Log("LightActived");
    }
    public void LevelUpDoubleJump()
    {
        if(playerData.hasDoubleJump) return;
        playerData.hasDoubleJump = true;
        Debug.Log("DoubleJumpActived");
    }
    public void LevelUpLightLevel2()
    {
        if(playerData.hasLightv2) return;
        playerData.hasLightv2 = true;
        Debug.Log("BigLight Actived");
    }
}
