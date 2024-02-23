using Mediapipe.Unity.Holistic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MariaGesture : MonoBehaviour
{
    static int poseLandmark_number = 32;
    // static int handLandmark_number = 20; //The orginal hand number 
    static int handLandmark_number = 1;

    // Declare landmark vectors 
    public Vector3[] pose = new Vector3[poseLandmark_number];
    public Vector3[] righthandpos = new Vector3[handLandmark_number];
    public GameObject[] PoseLandmarks, RightHandLandmarks; // Remove LeftHandLandmarks
    public static MariaGesture gen; // singleton
    public static Gesture gen2; // singleton
    public GameObject tkWhole;
    public float xpos;
    public int win = 0;
    public GameObject pawOne,pawTwo,pawThree,pawFour,pawFive,pawSix,
        winBarrier, startBarrier, homeScreen, winScreen, loseScreen, 
        titleScreen, water1, water2, water3, water4, water5, water6, 
        water7, water8, water9, water10; 

    public bool drawLandmarks = true;
    public bool trigger = false;
    private float distance;
    int totalNumberofLandmark;
    private void Awake()
    {
        if (MariaGesture.gen == null)
        {
            MariaGesture.gen = this;
        }
        tkWhole = GameObject.Find("Kitty");

        totalNumberofLandmark = poseLandmark_number + handLandmark_number; // Remove handLandmark_number again
        PoseLandmarks = new GameObject[poseLandmark_number];
        RightHandLandmarks = new GameObject[handLandmark_number]; // Remove LeftHandLandmarks
    }
    // Start is called before the first frame update
    void Start()
    {  
        pawOne = GameObject.Find("Paw");
        pawTwo = GameObject.Find("Paw1");
        pawThree = GameObject.Find("Paw2");
        pawFour = GameObject.Find("Paw3");
        pawFive = GameObject.Find("Paw4");
        pawSix = GameObject.Find("Paw5");
        water1 = GameObject.Find("Water1");
        water2 = GameObject.Find("Water2");
        water3 = GameObject.Find("Water3");
        water4 = GameObject.Find("Water4");
        water5 = GameObject.Find("Water5");
        water6 = GameObject.Find("Water6");
        water7 = GameObject.Find("Water7");
        water8 = GameObject.Find("Water8");
        water9 = GameObject.Find("Water9");
        water10 = GameObject.Find("Water10");

        winBarrier = GameObject.Find("WinBarrier");
        startBarrier = GameObject.Find("StartBarrier");
        homeScreen = GameObject.Find("HomeScreen");
        winScreen = GameObject.Find("WinScreen");
        loseScreen = GameObject.Find("LoseScreen");
        titleScreen = GameObject.Find("TitleScreen");

        pawOne.SetActive(false);
        pawTwo.SetActive(false);
        pawThree.SetActive(false);
        pawFour.SetActive(false);
        pawFive.SetActive(false);
        pawSix.SetActive(false);
        winBarrier.SetActive(false);
        startBarrier.SetActive(true);
        homeScreen.SetActive(false);
        winScreen.SetActive(false);        
        loseScreen.SetActive(false);
        titleScreen.SetActive(true);
        water1.SetActive(false);
        water2.SetActive(false);
        water3.SetActive(false);
        water4.SetActive(false);
        water5.SetActive(false);
        water6.SetActive(false);
        water7.SetActive(false);
        water8.SetActive(false);
        water9.SetActive(false);
        water10.SetActive(false);

        Collider starting = transform.Find("Sphere").GetComponent<Collider>();
        Collider cat = transform.Find("Kitty").GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!trigger) // Check if the game is not ended yet
        {
            CheckCollision();
        }

        Vector3 tkposition = new Vector3(0, 0, 0);
        for (int i = 0; i < 20; i++)
        { 
            tkposition = tkposition - righthandpos[i];
        }

        tkposition = tkposition / 20;
        xpos = tkposition.x;
        Debug.Log(xpos);
        tkposition.x = (tkposition.x*6)-3;
        tkposition.y = (tkposition.y*2);
        if (tkposition.x <= -10) {
            tkposition.x = tkposition.x + 8;
        }
        tkWhole.transform.position = tkposition;
        tkWhole.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
    }

    void CheckCollision()
    {
        Collider planeCollider = transform.Find("Kitty").GetComponent<Collider>();
        Collider cylinderCollider = transform.Find("Paw").GetComponent<Collider>();
        Collider cylinderCollider1 = transform.Find("Paw1").GetComponent<Collider>();
        Collider cylinderCollider2 = transform.Find("Paw2").GetComponent<Collider>();
        Collider cylinderCollider3 = transform.Find("Paw3").GetComponent<Collider>();
        Collider cylinderCollider4 = transform.Find("Paw4").GetComponent<Collider>();
        Collider cylinderCollider5 = transform.Find("Paw5").GetComponent<Collider>();
        Collider water1 = transform.Find("Water1").GetComponent<Collider>();
        Collider water2 = transform.Find("Water2").GetComponent<Collider>();
        Collider water3 = transform.Find("Water3").GetComponent<Collider>();
        Collider water4 = transform.Find("Water4").GetComponent<Collider>();
        Collider water5 = transform.Find("Water5").GetComponent<Collider>();
        Collider water6 = transform.Find("Water6").GetComponent<Collider>();
        Collider water7 = transform.Find("Water7").GetComponent<Collider>();
        Collider water8 = transform.Find("Water8").GetComponent<Collider>();
        Collider water9 = transform.Find("Water9").GetComponent<Collider>();
        Collider water10 = transform.Find("Water10").GetComponent<Collider>();
        Collider winBarrier = transform.Find("WinBarrier").GetComponent<Collider>();
        Collider startBarrier = transform.Find("StartBarrier").GetComponent<Collider>();


        if (cylinderCollider.bounds.Intersects(planeCollider.bounds))
        {
            EndGame();
        } 
        else if (cylinderCollider1.bounds.Intersects(planeCollider.bounds))
        {
            EndGame();
        }
        else if (cylinderCollider2.bounds.Intersects(planeCollider.bounds))
        {
            EndGame();
        }
        else if (cylinderCollider3.bounds.Intersects(planeCollider.bounds))
        {
            EndGame();
        }
        else if (cylinderCollider4.bounds.Intersects(planeCollider.bounds))
        {
            EndGame();
        }
        else if (cylinderCollider5.bounds.Intersects(planeCollider.bounds))
        {
            EndGame();
        }
            else if (winBarrier.bounds.Intersects(planeCollider.bounds))
        {
            WinGame();           
        }       
            else if (startBarrier.bounds.Intersects(planeCollider.bounds))
        {
            StartGame();           
        } 
            else if (homeScreen.activeSelf == true && xpos > -0.04f)
        {
            WinGame();
        } 
            else if (water1.bounds.Intersects(planeCollider.bounds)) 
        {
            EndGame();
        } 
            else if (water2.bounds.Intersects(planeCollider.bounds)) 
        {
            EndGame();
        } 
            else if (water3.bounds.Intersects(planeCollider.bounds))
        {
            EndGame();
        } 
            else if (water4.bounds.Intersects(planeCollider.bounds)) 
        {
            EndGame();
        } 
            else if (water5.bounds.Intersects(planeCollider.bounds)) 
        {
            EndGame();
        } 
            else if (water6.bounds.Intersects(planeCollider.bounds)) 
        {
            EndGame();
        } 
            else if (water7.bounds.Intersects(planeCollider.bounds)) 
        {
            EndGame();
        } 
            else if (water8.bounds.Intersects(planeCollider.bounds)) 
        {
            EndGame();
        } 
            else if (water9.bounds.Intersects(planeCollider.bounds)) 
        {
            EndGame();
        } 
            else if (water10.bounds.Intersects(planeCollider.bounds)) 
        {
            EndGame();
        }
       
    }
    
     void StartGame()
    {
        if (win == 0) {
        pawOne.SetActive(true);
        pawTwo.SetActive(true);
        pawThree.SetActive(true);
        pawFour.SetActive(true);
        pawFive.SetActive(true);
        pawSix.SetActive(true);
        winBarrier.SetActive(true);
        startBarrier.SetActive(false);
        homeScreen.SetActive(true);
        winScreen.SetActive(false);        
        loseScreen.SetActive(false);
        titleScreen.SetActive(false);
        water1.SetActive(false);
        water2.SetActive(false);
        water3.SetActive(false);
        water4.SetActive(false);
        water5.SetActive(false);
        water6.SetActive(false);
        water7.SetActive(false);
        water8.SetActive(false);
        water9.SetActive(false);
        water10.SetActive(false);
        } else if (win == 1){
            LevelTwo();
        } else {
            win = 0;
        }

    }

    void LevelTwo() {
        pawOne.SetActive(false);
        pawTwo.SetActive(false);
        pawThree.SetActive(false);
        pawFour.SetActive(false);
        pawFive.SetActive(false);
        pawSix.SetActive(false);
        winBarrier.SetActive(true);
        startBarrier.SetActive(false);
        homeScreen.SetActive(true);
        winScreen.SetActive(false);        
        loseScreen.SetActive(false);
        titleScreen.SetActive(false);
        water1.SetActive(true);
        water2.SetActive(true);
        water3.SetActive(true);
        water4.SetActive(true);
        water5.SetActive(true);
        water6.SetActive(true);
        water7.SetActive(true);
        water8.SetActive(true);
        water9.SetActive(true);
        water10.SetActive(true);

    }
    
     void EndGame()
    {
        pawOne.SetActive(false);
        pawTwo.SetActive(false);
        pawThree.SetActive(false);
        pawFour.SetActive(false);
        pawFive.SetActive(false);
        pawSix.SetActive(false);
        winBarrier.SetActive(false);
        startBarrier.SetActive(true);
        homeScreen.SetActive(false);
        winScreen.SetActive(false);        
        loseScreen.SetActive(true);
        titleScreen.SetActive(false);
        water1.SetActive(false);
        water2.SetActive(false);
        water3.SetActive(false);
        water4.SetActive(false);
        water5.SetActive(false);
        water6.SetActive(false);
        water7.SetActive(false);
        water8.SetActive(false);
        water9.SetActive(false);
        water10.SetActive(false);
    }

    void WinGame()
    {
        win += 1;
        pawOne.SetActive(false);
        pawTwo.SetActive(false);
        pawThree.SetActive(false);
        pawFour.SetActive(false);
        pawFive.SetActive(false);
        pawSix.SetActive(false);
        winBarrier.SetActive(false);
        startBarrier.SetActive(true);
        homeScreen.SetActive(false);
        winScreen.SetActive(true);       
        loseScreen.SetActive(false);
        titleScreen.SetActive(false);
        water1.SetActive(false);
        water2.SetActive(false);
        water3.SetActive(false);
        water4.SetActive(false);
        water5.SetActive(false);
        water6.SetActive(false);
        water7.SetActive(false);
        water8.SetActive(false);
        water9.SetActive(false);
        water10.SetActive(false);
    }
}
