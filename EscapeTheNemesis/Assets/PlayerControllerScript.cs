using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private int _playerX, _playerY;
    private int _x, _y;
    [SerializeField] GridGenerator _gridGenerator;
    [SerializeField] GameObject grid;
    private int xAxis=0, yAxis=0;
    private Animator _anim;
   
 
    private void Start()
    {
        _x = _gridGenerator.x;
        _y = _gridGenerator.y;
       _anim= GetComponent<Animator>();
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);


                    if (yAxis < _y-1 && GridGenerator.Grid[xAxis,yAxis+1]==1 )
                    {
                          yAxis++;
                      
                        transform.Translate(1.2f, 0, 0);
                         Debug.Log(GridGenerator.Grid[xAxis, yAxis]);
                        
                    }

         

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation=new Quaternion(0,180,0,0);
            if (yAxis > 0 && GridGenerator.Grid[xAxis, yAxis-1] == 1)
            {
                yAxis--;
                transform.Translate(1.2f, 0, 0);
                Debug.Log(GridGenerator.Grid[xAxis, yAxis]);


            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (xAxis > 0 && GridGenerator.Grid[xAxis-1, yAxis] == 1)
            {
                xAxis--;
                transform.Translate(0,1.2f, 0);
                Debug.Log(GridGenerator.Grid[xAxis, yAxis]);


            }
           
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (xAxis < _x-1 && GridGenerator.Grid[xAxis+1, yAxis] == 1)
            {
                xAxis++;
                transform.Translate(0, -1.2f, 0);

                Debug.Log(GridGenerator.Grid[xAxis, yAxis]);

            }
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetBool("Attack", true);
        }

        if(Input.GetMouseButtonUp(0))
        {
            _anim.SetBool("Attack", false);

        }

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .7f)
        {


            
            Destroy(gameObject);
          
           


        }

       
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _anim.SetBool("Die", true);

            
        }
    }
}
