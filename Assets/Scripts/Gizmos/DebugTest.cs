using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest  : MonoBehaviour
{
    private float _timer;
    private int _level;
    [SerializeField] private int _allCountLevel;

    private void Start()
    {
        print("До паузы");

        Debug.Break();
        print("После паузы");
   }




    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space));
        // {
        //     Debug.DrawLine(Vector3.zero, new Vector3(5, 4, 0), Color.red, 2.5f);
        // }
        Debug.DrawRay(Vector3.zero, Vector3.up *3, Color.green);
        Debug.DrawRay(transform.position, Vector3.up *3, Color.yellow);
        Debug.DrawRay(Vector3.zero, transform.up *3, Color.red); 

        
    }



    // private void GetLevel(int level)
    // {
    //     if(level < _allCountLevel && level>0)
    //     {
    //         _level = level;
    //     }
    //     else 
    //     {
    //         Debug.LogError("Такого уровня нет");

    //     }

    // }
  














}
