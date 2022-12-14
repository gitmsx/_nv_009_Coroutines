using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class ReadMaps : MonoBehaviour
{

    [SerializeField] TextAsset MapsAll;

    [SerializeField] GameObject Wall;
    [SerializeField] GameObject Box;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Target;
    [SerializeField] GameObject Someth;
    [SerializeField][Range(1, 6)] int Scale_tmp = 1;
    // GameObject Button;
    // [SerializeField] int Scale_tmp = 1;
    int Level;
    int Level2;
    int Level3;


    



    [SerializeField][Range(0, 6)] int Level2_limit = 6;
    [SerializeField][Range(0, 10)] int Level3_limit = 10;





    void Start()
    {


        for (Level2 = 0; Level2 <= Level2_limit; Level2++)
            for (Level3 = 0; Level3 <= Level3_limit; Level3++)
            {

                Level = Level2 * Level3;
              

                if (Level < 61)
                LevelMake(Level );
                
        }
    }


    void LevelMake(int Level_cur)
     
    {

        List<string> parsed = ReadData(Level_cur);

        CreateLevel(parsed);
    }






    void CreateLevel(List<string> strings)
    {

        string[] strArr = strings.ToArray();

        // foreach (var str in strings)


        for (int i = 6; i < strings.Count - 2; i++)
        {
            char[] characters = strArr[i].ToCharArray();
            for (int j = 0; j < characters.Length; j++)
            {
                RespBox(characters[j], j, i);
            }
        }
    }





    void RespBox(char charN, int intx, int intZ)
    {

        GameObject[] Tipes = new GameObject[5];

        Tipes[0] = Wall;
        Tipes[1] = Box;
        Tipes[2] = Player;
        Tipes[3] = Target;
//        Tipes[4] = Someth;



        int elem = 1;

        switch (charN)
        {
            case 'X':
                elem = 0;
                break;
            case '.':
                elem = 3;
                break;
            case '@':
                elem = 2;
                break;
            case '&':
                elem = 4;
                break;
            case ' ':
                elem = -2;
                break;
            case '*':
                elem = 1;
                break;
            default:
                elem = -1;
                break;
        }



        if (elem == 4)
        {

            Vector3 NewPos = new Vector3((3 + intx) * Scale_tmp + Level2 * 100, 0.001f + 12 * Level, (3 + intZ) * Scale_tmp);
            Instantiate(Tipes[3], NewPos, Quaternion.identity);
            Instantiate(Tipes[1], NewPos, Quaternion.identity);

        }


        else    if (elem >= 0)
        {

            Vector3 NewPos = new Vector3((3 + intx) * Scale_tmp + Level2 * 100, 0.001f + 12 * Level, (3 + intZ) * Scale_tmp);

            Instantiate(Tipes[elem], NewPos, Quaternion.identity);

        }
        else if(elem!=-2) Debug.Log(charN);





    }



    List<string> ReadData(int Level)
    {



        string path = "Assets\\Resources\\maps60.txt";
        path = "Assets/Resources/maps60.txt";
        List<string> parsed = new List<string>();
        string StartParse = "Maze: " + Level.ToString();
        string EndParse = "Maze: " + (Level + 1).ToString();
        bool WriteOn = false;


        try
        {
            using StreamReader sr = new StreamReader(path);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                if (EndParse == line)
                    break;
                if (StartParse == line)
                    WriteOn = true;
                if (WriteOn)
                    parsed.Add(line);



            }
            sr.Close();
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        return parsed;
    }



}



//Level element	Character	ASCII Code
//Wall	#	0x23
//Player	@	0x40
//Player on goal square	+	0x2b
//Box	$	0x24
//Box on goal square	*	0x2a
//Goal square	.	0x2e
//Floor	(Space)	0x20