using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    GameManager gm;
    public GameObject Ship;

    // Start is called before the first frame update
    void Start()
    {   
        gm = GameManager.GetInstance();
    }

    public void Launch()
    {
        if (gm.gameState == GameManager.GameState.GAME && !gm.ingame)
        {
            Vector3 posicao = new Vector3(-10, 0, 0);
            Instantiate(Ship, posicao, Quaternion.identity, transform);
            gm.ingame = true;
        }
    }

    private void DestroyAll()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    void Update()
    {
        if (transform.childCount > 0 && gm.gameState == GameManager.GameState.MENU) DestroyAll();

        // if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        // {
        //     gm.ChangeState(GameManager.GameState.ENDGAME);
        // }
    }
}
