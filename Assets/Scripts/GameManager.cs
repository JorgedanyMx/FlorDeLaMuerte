using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject nivelParte1;
    public GameObject nivelParte2;
    private void Start()
    {
        playerData.ResetPlayerData();
        ShowFirstZone();
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
    public void ShowFirstZone()
    {
        if(nivelParte1!=null && nivelParte2 != null)
        {
            nivelParte1.SetActive(true);
            nivelParte2.SetActive(false);
        }
    }
    public void ShowSecondZone()
    {
        if (nivelParte1 != null && nivelParte2 != null)
        {
            nivelParte1.SetActive(false);
            nivelParte2.SetActive(true);
        }
    }
}
