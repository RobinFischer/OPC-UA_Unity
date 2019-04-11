using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpcClientHda;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Client myClient = new Client();
        myClient.Start();
    }

}
