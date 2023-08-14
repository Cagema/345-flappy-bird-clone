using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            transform.Translate(GameManager.Single.Speed * Time.deltaTime * Vector3.left);

            if (transform.position.x < -GameManager.Single.RightUpperCorner.x - 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
