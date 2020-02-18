﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunks : MonoBehaviour
{
    GameObject villageChunk;
    GameObject forestChunk;
    GameObject riverChunk;
    float currentZ= 0 ;
    string previousChunk;

    // Start is called before the first frame update
    void Start()
    {
        villageChunk = Resources.Load("VillageChunk") as GameObject;
        forestChunk = Resources.Load("ForestChunk") as GameObject;
        riverChunk = Resources.Load("RiverChunkPrefab") as GameObject;
        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, 3);
            Debug.Log("RANDOM: " + rand);
            if(rand == 0)
            {
                if(previousChunk == "forest")
                {
                    currentZ += 450f;
                }
                else if(previousChunk == "river")
                {
                    currentZ += 850;
                }
                else
                {
                    currentZ += 350f;
                }
                
                Instantiate(villageChunk, new Vector3(-18f, 1f, currentZ), Quaternion.Euler(0, 90, 0));
                previousChunk = "village";
            }
            else if(rand == 1)
            {

                if (previousChunk == "river")
                {
                    currentZ += 800;
                }
                else
                {
                    currentZ += 230;
                }

                
                Instantiate(forestChunk, new Vector3(-22f, 0f, currentZ), Quaternion.Euler(0, 90, 0));
                previousChunk = "forest";
            }else if (rand == 2)
            {

                if(previousChunk == "forest")
                {
                    currentZ += 250;
                }
                else if(previousChunk == "village")
                {
                    currentZ += 180;

                }
                else if(previousChunk == "river")
                {
                    currentZ += 650;
                }
                else
                {
                    currentZ = 110f;
                }
                
                Instantiate(riverChunk, new Vector3(17.57f, 3f, currentZ), Quaternion.Euler(0, -100.92f, 0));
                previousChunk = "river";
            }


        }

        //spawn village Add 360 every time to Z coord

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}