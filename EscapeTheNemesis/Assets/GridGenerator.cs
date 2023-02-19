using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    [SerializeField] static int x, y;
    [SerializeField] float distanceBetweenEachTileX, distanceBetweenEachTileY;
    [SerializeField] float startingPointX, startingPointY;
    [SerializeField] GameObject Tile;
    [SerializeField] GameObject FireBlock;
    [SerializeField] GameObject Enemy;
    [SerializeField] int FireCount, EnemyCount;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Exit;
    private Vector2 _pos;
    private int _firecount=0, _enemycount=0;
    private int _randomFireX, _randomFireY;
    private int _randomEnemyX, _randomEnemyY;
    private Vector3 _fireLoca, _enemyLoca;

    //when the scene loads, the grid should be generated, hence using start
    void Start()
    {
      
        StartCoroutine(SpawnTiles());
        
    }

    IEnumerator SpawnTiles()
    {


        //instantiating random FireBlock and Enemy

        while (_firecount < FireCount)
        {

            _randomFireX = Random.Range(1, y - 1); //ignoring first and last spots
            _randomFireY = Random.Range(1, x - 1);
            _fireLoca = new Vector3(startingPointX + distanceBetweenEachTileX * _randomFireX, startingPointY + distanceBetweenEachTileY * -_randomFireY, 0);
            Instantiate(FireBlock, _fireLoca, FireBlock.transform.rotation);
            _firecount++;
        }

        while (_enemycount < EnemyCount)
        {

            _randomEnemyX = Random.Range(1, y - 1); //ignoring first and last spots
            _randomEnemyY = Random.Range(1, x - 1);
            _enemyLoca = new Vector3(startingPointX + distanceBetweenEachTileX * _randomEnemyX, startingPointY + (distanceBetweenEachTileY + .3f) * -_randomEnemyY, -1);
            Instantiate(Enemy, _enemyLoca, FireBlock.transform.rotation);
            _enemycount++;
        }


        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
              
               

                _pos = new Vector2(startingPointX + distanceBetweenEachTileX * j, startingPointY + (distanceBetweenEachTileY * -i)); //will keep adding



                GameObject _tile = Instantiate(Tile, _pos, Quaternion.identity); //for same row
                _tile.transform.parent = transform;



                //instantiating Player
                if (i == 0 && j == 0)
                {
                    Instantiate(Player, _pos, Quaternion.identity);
                }



                //isntantiating portal


                if(i==x-1 && j==y-1)
                {
                    Instantiate(Exit, _pos, Exit.transform.rotation);

                }




            }
        }

        yield return null;

    }
}
