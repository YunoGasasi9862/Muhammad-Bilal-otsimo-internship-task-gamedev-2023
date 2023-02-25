using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GridGenerator : MonoBehaviour
{

    public int x, y;

    [SerializeField] float distanceBetweenEachTileX, distanceBetweenEachTileY;
    [SerializeField] float startingPointX, startingPointY;
    [SerializeField] GameObject Tile;
    [SerializeField] GameObject FireBlock;
    [SerializeField] GameObject Enemy;
    [SerializeField] int FireCount, EnemyCount;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Exit;
    [SerializeField] GameObject powerUp;
    private Vector2 _pos;
   
    public static int[,] Grid;

    //when the scene loads, the grid should be generated, hence using start
    void Start()
    {

        Grid = new int[x, y];
        Grid[0, 0] = 1;
        for(int i=0; i<x; i++)
        {
            for(int j=0; j<y; j++)
            {
                Grid[i,j] = 1;
            }
        }
        StartCoroutine(SpawnTiles());
        
    }
 

    IEnumerator SpawnTiles()
    {

        //instantiating random FireBlock and Enemy

        PropsGenerator(FireCount, FireBlock, 0);
        PropsGenerator(EnemyCount, Enemy,.3f, -1);

        //powerup

        PropsGenerator(1, powerUp);

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                        

                _pos = new Vector3(startingPointX + distanceBetweenEachTileX * j, startingPointY + (distanceBetweenEachTileY * -i),0); //will keep adding

                GameObject _tile = Instantiate(Tile, _pos, Quaternion.identity); //for same row
                _tile.transform.parent = transform;

                //instantiating Player
                if (i == 0 && j == 0)
                {
                  GameObject _player=  Instantiate(Player, new Vector3(startingPointX + distanceBetweenEachTileX * j, startingPointY + (distanceBetweenEachTileY * -i),-1), Quaternion.identity);
                    _player.transform.parent = transform;

                }

                //isntantiating portal


                if(i==x-1 && j==y-1)
                {
                    Grid[i, j] = 2;
                    GameObject _portal =   Instantiate(Exit, new Vector3(startingPointX + distanceBetweenEachTileX * j, startingPointY + (distanceBetweenEachTileY * -i), -1), Exit.transform.rotation);
                    _portal.transform.parent = transform;

                }

          

            }
        }

        yield return null;

    }

    public void PropsGenerator(int PropMaxCount, GameObject propObject) //overwritten method
    {
        int _count = 0;
        int randomX = 0, randomY = 0;
        while (_count < PropMaxCount)
        {

            randomX = Random.Range(1, y - 1); //ignoring first and last spots
            randomY = Random.Range(1, x - 1);
            while (Grid[randomY, randomX] == 0 || Grid[randomY, randomX] == -1)
            {

                randomX = Random.Range(1, y - 1);
                randomY = Random.Range(1, x - 1);
            }
            Vector3 propLoca = new Vector3(startingPointX + distanceBetweenEachTileX * randomX, startingPointY + distanceBetweenEachTileY * -randomY, 0);
            GameObject _prop = Instantiate(propObject, propLoca, propObject.transform.rotation);
            _prop.transform.parent = transform;
            _prop.transform.parent = transform;
            _count++;
            
        }
    }

    public void PropsGenerator(int PropMaxCount, GameObject propObject, int GridSign)
    {
        int _count = 0;
        int randomX=0, randomY=0;
        while (_count < PropMaxCount)
        {

            randomX = Random.Range(1, y - 1); //ignoring first and last spots
            randomY = Random.Range(1, x - 1);
            while (Grid[randomY, randomX] == 0 || Grid[randomY, randomX]==-1)
            {

                randomX = Random.Range(1, y - 1);
                randomY = Random.Range(1, x - 1);
            }
            Vector3 propLoca = new Vector3(startingPointX + distanceBetweenEachTileX * randomX, startingPointY + ( distanceBetweenEachTileY) * -randomY, 0);
            GameObject _prop = Instantiate(propObject, propLoca, propObject.transform.rotation);
            _prop.transform.parent = transform;
            _count++;
            Grid[randomY, randomX] = GridSign;
        }
    }

    public void PropsGenerator(int PropMaxCount, GameObject propObject, float distance, int GridSign)
    {
        int _count = 0;
        int randomX = 0, randomY = 0;
        while (_count < PropMaxCount)
        {

            randomX = Random.Range(1, y - 1); //ignoring first and last spots
            randomY = Random.Range(1, x - 1);
            while (Grid[randomY, randomX] == 0 || Grid[randomY, randomX] == -1)
            {

                randomX = Random.Range(1, y - 1);
                randomY = Random.Range(1, x - 1);


            }
            Vector3 propLoca = new Vector3(startingPointX + (distanceBetweenEachTileX * randomX), startingPointY + (distanceBetweenEachTileY + distance) * (-randomY)+distanceBetweenEachTileY, 0);
            GameObject _prop = Instantiate(propObject, propLoca, propObject.transform.rotation);
            _prop.transform.parent = transform;
            _count++;
            Grid[randomY, randomX] = GridSign;
        }
    }
}
