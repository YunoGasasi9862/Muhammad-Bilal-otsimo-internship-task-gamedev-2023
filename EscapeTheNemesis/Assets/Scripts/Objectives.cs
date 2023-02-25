
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Objectives : MonoBehaviour
{
    public static int LEVEL1MOVES = 10;
    public static int LEVEL2MOVES = 14;
    public static int LEVEL3MOVES = 15;
    public static int LEVEL4MOVES = 16;

    [SerializeField] TextMeshProUGUI _levelObjective;

    private void Start()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Level1":
                _levelObjective.text = LEVEL1MOVES.ToString("0");
                PlayerControllerScript.objectivecurrentmoves = LEVEL1MOVES;
                break;
            case "Level2":
                _levelObjective.text = LEVEL2MOVES.ToString("0");
                PlayerControllerScript.objectivecurrentmoves = LEVEL2MOVES;

                break;
            case "Level3":
                _levelObjective.text = LEVEL3MOVES.ToString("0");
                PlayerControllerScript.objectivecurrentmoves = LEVEL3MOVES;

                break;
            case "Level4":

                _levelObjective.text = LEVEL4MOVES.ToString("0");
                PlayerControllerScript.objectivecurrentmoves = LEVEL4MOVES;

                break;
        }
    }
}
