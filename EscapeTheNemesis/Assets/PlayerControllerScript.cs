using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerControllerScript : MonoBehaviour
{
    private int _x, _y;
    private GridGenerator _gridGenerator;
    [SerializeField] GameObject grid;
    private int xAxis=0, yAxis=0;
    private Animator _anim;
    [SerializeField] GameObject nextLevel;
    public static bool _progress=false;
    private bool canWalk = true;
    public int moves = 0;
    private TextMeshProUGUI _moveScore;
    public static int objectivecurrentmoves;
   
 
    private void Start()
    {
        _gridGenerator = GameObject.FindGameObjectWithTag("GridVariant").GetComponent<GridGenerator>();
        _x = _gridGenerator.x;
        _y = _gridGenerator.y;
        xAxis = 0;
        yAxis = 0;
       _anim= GetComponent<Animator>();
        _moveScore=GameObject.FindWithTag("MoveNum").GetComponent<TextMeshProUGUI>();


        
    }
    void Update()
    {

        Movement();
        _moveScore.text= moves.ToString("0");

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

    public void Movement()
    {
        if(canWalk)
        {
            if(moves > objectivecurrentmoves)
            {
                _anim.SetBool("Die", true);

            }

            if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);


            if (yAxis < _y - 1 && (GridGenerator.Grid[xAxis, yAxis + 1] == 1 || GridGenerator.Grid[xAxis, yAxis + 1] == 2 || GridGenerator.Grid[xAxis, yAxis + 1] == -1))
            {

                yAxis++;

                    moves++;
                transform.Translate(1.2f, 0, 0);


                if (GridGenerator.Grid[xAxis, yAxis] == 2)
                {
                   GameObject _temp= Instantiate(nextLevel, transform.position, Quaternion.identity);
                        canWalk = false;
                         Destroy(_temp, 3f);
                        Invoke("Progression", 2f);


                    }






                }



        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            if (yAxis > 0 && (GridGenerator.Grid[xAxis, yAxis - 1] == 1 || GridGenerator.Grid[xAxis, yAxis - 1] == 2 || GridGenerator.Grid[xAxis, yAxis-1]==-1))
            {

                yAxis--;
                    moves++;

                    transform.Translate(1.2f, 0, 0);


            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (xAxis > 0 && (GridGenerator.Grid[xAxis - 1, yAxis] == 1 || GridGenerator.Grid[xAxis - 1, yAxis] == 2 || GridGenerator.Grid[xAxis-1, yAxis] == -1))
            {
                xAxis--;
                    moves++;

                    transform.Translate(0, 1.2f, 0);


            }

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (xAxis < _x - 1 && (GridGenerator.Grid[xAxis + 1, yAxis] == 1 || GridGenerator.Grid[xAxis + 1, yAxis] == 2 || GridGenerator.Grid[xAxis + 1, yAxis] == -1))
            {
                xAxis++;
                    moves++;

                    transform.Translate(0, -1.2f, 0);
                if (GridGenerator.Grid[xAxis, yAxis] == 2)
                {
                    GameObject _temp= Instantiate(nextLevel, transform.position, Quaternion.identity);
                        canWalk = false;

                        Destroy(_temp, 3f);
                        Invoke("Progression", 2f);


                }

            }



             }

        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _anim.SetBool("Die", true);

            
        }

       
        
    }

    public void Progression()
    {
        _progress = true;

    }




}
