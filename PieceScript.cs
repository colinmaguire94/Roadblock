using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    //Script put on each piece, allows me to know if the piece is the player, and if it's vertical.

    public bool isVertical;
    public bool isPlayer;
    [HideInInspector]
    private Vector3 positon;

    // Use this for initialization
    void Start()
    {
        positon = this.gameObject.transform.position;
    }
}
