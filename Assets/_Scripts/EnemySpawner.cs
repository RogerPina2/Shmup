using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager gm;
    public GameObject PurpleShip;
    public GameObject Hexagon;
    public GameObject Asteroid;
    public GameObject ShooterEnemy;
    public Transform Ship;

    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {   
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Launch;
        Launch();
    }


    void Launch()
    {       
        if (!gm.ingame)
        {
            Launch_PurpleShip(0, -4.5f, 22.0f);
            Launch_Hexagon(0, -4.5f, 22.0f);
            Launch_Asteroid(0, -4.5f, 22.0f);
        }
    }    

    private void Launch_PurpleShip(int quantidade, float x1, float x2)
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            for (int i=0; i<quantidade; i++)
            {
                x = Random.Range(x1, x2);
                y = Random.Range(-4.0f, 4.0f);
                Vector3 posicao = new Vector3(x,y);
                Instantiate(PurpleShip, posicao, Quaternion.identity, transform);    
            }
        }
    }

    private void Launch_Hexagon(int quantidade, float x1, float x2)
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            for (int i=0; i<quantidade; i++)
            {
                x = Random.Range(x1, x2);
                y = Random.Range(-4.0f, 4.0f);
                Vector3 posicao = new Vector3(x,y);
                Instantiate(Hexagon, posicao, Quaternion.identity, transform);
            }
        }
    }

    private void Launch_Asteroid(int quantidade, float x1, float x2)
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {   
            for (int i=0; i<quantidade; i++)
            {
                x = Random.Range(x1, x2);
                y = Random.Range(-4.0f, 4.0f);
                Vector3 posicao = new Vector3(x,y);
                Instantiate(Asteroid, posicao, Quaternion.identity, transform);
            }
        }
    }

    private void Launch_Shooter(int quantidade, float x1, float x2)
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {   
            for (int i=0; i<quantidade; i++)
            {
                x = Random.Range(x1, x2);
                y = Random.Range(-4.0f, 4.0f);
                Vector3 posicao = new Vector3(x,y);
                Instantiate(ShooterEnemy, posicao, Quaternion.identity, transform);
            }
        }
    }

    private void DestroyAll()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    bool f0 = true;
    bool f1 = false;
    bool f2 = false;
    bool f3 = false;

    void Update()
    {
        if (transform.childCount > 0 && gm.gameState == GameManager.GameState.MENU) DestroyAll();

        if (Ship.position.x > 0 && Ship.position.x < 20 && f0) {
            if (!gm.ingame)
            {
                Launch_Asteroid     (6, 15.0f, 35.0f);
                Launch_PurpleShip   (4, 15.0f, 35.0f);
                Launch_Shooter      (2, 15.0f, 35.0f);
                Launch_Hexagon      (1, 15.0f, 35.0f);    
            }

            f0 = false;
            f1 = true;
        }
        else if (Ship.position.x > 20 && Ship.position.x < 40 && f1) {
            if (!gm.ingame)
            {
                Launch_Asteroid     (12,35.0f, 55.0f);
                Launch_PurpleShip   (8, 35.0f, 55.0f);
                Launch_Shooter      (4, 35.0f, 35.0f);
                Launch_Hexagon      (2, 35.0f, 55.0f);
            }

            f1 = false;
            f2 = true;
        }
        else if (Ship.position.x > 40 && Ship.position.x < 60 && f2) {
            if (!gm.ingame)
            {
                Launch_Asteroid     (24, 55.0f, 75.0f);
                Launch_PurpleShip   (16, 55.0f, 75.0f);
                Launch_Shooter      (8,  55.0f, 75.0f);
                Launch_Hexagon      (4,  55.0f, 75.0f);
            }

            f2 = false;
            f3 = true;
        }
        
        if (f3) {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }


        // if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        // {
        //     gm.ChangeState(GameManager.GameState.ENDGAME);
        // }
    }
}
