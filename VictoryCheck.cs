using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCheck : MonoBehaviour {

    //Script to check if the player has reached the exit, and if so a congraulations UI shows up.
    public GameObject congratsUI;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PieceScript>().isPlayer)
        {
            congratsUI.SetActive(true);
            FindObjectOfType<LevelLayout>().victoryLevel();
        }
    }
}
