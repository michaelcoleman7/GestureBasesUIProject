﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunks : MonoBehaviour
{
    GameObject villageChunk;
    GameObject forestChunk;
    GameObject riverChunk;
    GameObject riverChunkNoBoat;
    float currentZ= 0 ;
    string previousChunk;
    ArrayList chunks;

    // Start is called before the first frame update
    void Start()
    {
        chunks = new ArrayList();
        //Hardcode order you want to test chunks
        int[] ChunkPatterns = { 0, 2, 1, 0};


        villageChunk = Resources.Load("VillageChunk") as GameObject;
        forestChunk = Resources.Load("ForestChunk") as GameObject;
        riverChunk = Resources.Load("RiverChunkPrefab") as GameObject;
        riverChunkNoBoat = Resources.Load("RiverChunkPrefabNoBoat") as GameObject;
        //int rand = 0;
        for (int i = 0; i < ChunkPatterns.Length; i++)
        {
            int rand = ChunkPatterns[i];
            Debug.Log("RANDOM: " + rand);
            //VILLAGE
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
                chunks.Add(0);
                previousChunk = "village";
            }
            //FOREST
            else if(rand == 1)
            {

                if (previousChunk == "river")
                {
                    currentZ += 680;
                }
                else
                {
                    currentZ += 230;
                }

                chunks.Add(1);
                Instantiate(forestChunk, new Vector3(-22f, 0f, currentZ), Quaternion.Euler(0, 90, 0));
                previousChunk = "forest";
            }
            //RIVER
            else if (rand == 2)
            {

                if(previousChunk == "forest")
                {
                    currentZ += 250;
                    Instantiate(riverChunk, new Vector3(17.57f, 3f, currentZ), Quaternion.Euler(0, -100.92f, 0));
                }
                else if(previousChunk == "village")
                {
                    currentZ += 180;
                    Instantiate(riverChunk, new Vector3(17.57f, 3f, currentZ), Quaternion.Euler(0, -100.92f, 0));

                }
                else if(previousChunk == "river")
                {
                    currentZ += 650;
                    Instantiate(riverChunkNoBoat, new Vector3(17.57f, 3f, currentZ), Quaternion.Euler(0, -100.92f, 0));
                }
                else
                {
                    currentZ = 110f;
                    Instantiate(riverChunk, new Vector3(17.57f, 3f, currentZ), Quaternion.Euler(0, -100.92f, 0));
                }

                chunks.Add(2);
                previousChunk = "river";
            }

            //rand = Random.Range(0, 3);
            
            if(rand == 2 && previousChunk == "river")
            {
                rand = 1;
            }

            

        }

        //spawn village Add 360 every time to Z coord

        Debug.Log("Chunks Generated");
        gameObject.AddComponent<ObstacleGenerator>();

    }

    public ArrayList GetChunkOrder()
    {
        return chunks;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
