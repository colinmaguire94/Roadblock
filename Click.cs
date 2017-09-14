using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    //Script to control the movement of piece with either mouse click or fingers.

    float startingPosition = 0;
    GameObject go;
    PieceScript piece;

    // Use this for initialization
    void Start () {
        go = new GameObject();
        piece = new PieceScript();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.touchCount == 0)
        {
            inputMouse();
        }
        else
        {
            inputTouch();
        }
	}

    //Function to calculate mobile inputs.
    void inputTouch()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                go = hit.collider.gameObject;
                piece = go.GetComponent<PieceScript>();
                if (piece != null)
                {
                    if (piece.isVertical)
                    {
                        startingPosition = Input.GetTouch(0).position.y;
                    }
                    else
                    {
                        startingPosition = Input.GetTouch(0).position.x;
                    }
                }
            }
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (piece.isVertical)
            {
                Vector3 position = go.transform.position;
                float change = -0.00045f * (startingPosition - Input.GetTouch(0).position.y);
                position[2] += change;
                go.transform.position = position;
                startingPosition = Input.GetTouch(0).position.y;
            }
            else
            {
                Vector3 position = go.transform.position;
                float change = -0.00045f * (startingPosition - Input.GetTouch(0).position.x);
                position[0] += change;
                go.transform.position = position;
                startingPosition = Input.GetTouch(0).position.x;
            }
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            startingPosition = 0;
        }
    }

    //Function to calculate computer inputs.
    void inputMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                go = hit.collider.gameObject;
                piece = go.GetComponent<PieceScript>();
                if (piece != null)
                {
                    if (piece.isVertical)
                    {
                        startingPosition = Input.mousePosition.y;
                    }
                    else
                    {
                        startingPosition = Input.mousePosition.x;
                    }
                }

                Debug.Log(go.name);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (piece.isVertical)
            {
                Vector3 position = go.transform.position;
                float change = -0.00045f * (startingPosition - Input.mousePosition.y);
                position[2] += change;
                go.transform.position = position;
                startingPosition = Input.mousePosition.y;
                //go.GetComponent<Rigidbody>().AddForce(position);
            }
            else
            {
                Vector3 position = go.transform.position;
                float change = -0.00045f * (startingPosition - Input.mousePosition.x);
                position[0] += change;
                go.transform.position = position;
                startingPosition = Input.mousePosition.x;
                //float change = -0.00145f * (startingPosition - Input.mousePosition.x);
                //position[0] += change;
                //go.transform.position = position;
                //startingPosition = Input.mousePosition.x;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startingPosition = 0;
        }
    }
}
