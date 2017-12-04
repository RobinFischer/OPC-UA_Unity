using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpcUa_Client_Hda;
using System;

public class OpcUaInputFieldManager : MonoBehaviour
{

    public InputField endpointField;
    public InputField userField;
    public InputField passField;
    public InputField Subscription1Field;
    public InputField Subscription2Field;
    public InputField Subscription3Field;
    public InputField subsTimeField;
    OpcUaClient Client;

    public Text status;
    public Image Subscription1_status;
    public Image Subscription2_status;
    public Image Subscription3_status;

    private int delayCnt;

    private string EndpointURL;
    private string Username;
    private string Password;
    private string SubscriptionId1;
    private string SubscriptionId2;
    private string SubscriptionId3;
    private int PublishInterval;

    private string variable1_name;
    private int variable1_index;

    public Text TutorialOutput;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Holo: starting client");
        //login procedure values
        EndpointURL = "opc.tcp://st50roboter:51210/UA/SampleServer";
        Username = "Name";
        Password = "Password";

        //Variable subscription values
        SubscriptionId1 = "ns=4;i=1285";
        variable1_name = "variable1";

        PublishInterval = 500;

        showValues();


        Client = new OpcUaClient();
        if (Client.setEndpoint(EndpointURL))
        {
            if (Client.connect(Username, Password))
            {
                //subscribing to given variable
                variable1_index = Client.addItemToSubscribe(variable1_name, SubscriptionId1);
                if (Client.addSubscription(PublishInterval))
                    Subscription1_status.color = Color.green;
                else
                    Subscription1_status.color = Color.red;

                Debug.Log("Holo: Connected in the start");
            }
            else
            {
                Debug.Log("Holo: Failed to Connect");
            }
        }
        else
        {
            Debug.Log("Holo: setpoint not reachable");
        }
    }

    // Update is called once per frame
    void Update()
    {
        delayCnt++;
        if (delayCnt == 10)
        {
            //get Variable
            if (OpcUaClient.m_list_subscribed[variable1_index].m_status)
            {
                TutorialOutput.text = OpcUaClient.m_list_subscribed[variable1_index].m_value;
            }
            delayCnt = 0;
        }
    }

    public void onReset()
    {
        Debug.Log("HOLO: input field onReset");
        //HoloPersistance.reset_default();
        showValues();
    }

    public void onConnect()
    {
        Debug.Log("HOLO: input field onConnect");
        Client.disconnect();
        if (Client.setEndpoint(endpointField.text.ToString()))
        {
            Debug.Log("HOLO: setpoint ok");
            //HoloPersistance.
            EndpointURL = endpointField.text.ToString();
            //HoloPersistance.save();

            //if(Client.connect(userField.text.ToString(),passField.text.ToString(),Subscription1Field.text.ToString(),Subscription2Field.text.ToString(),Subscription3Field.text.ToString(), 500))//System.Int32.Parse(subsTimeField.text.ToString())))
            //{
            //    Debug.Log("HOLO: connect ok");
            //    //HoloPersistance.
            //    Username = userField.text.ToString();
            //    Password = passField.text.ToString();
            //    SubscriptionId1 = Subscription1Field.text.ToString();
            //    SubscriptionId2 = Subscription2Field.text.ToString();
            //    SubscriptionId3 = Subscription3Field.text.ToString();
            //    PublishInterval = System.Int32.Parse(subsTimeField.text.ToString());
            //    //HoloPersistance.save();
            //    status.text = "Conection Succeded";
            //}
            if (false) ;
            else
            {
                Debug.Log("HOLO: connect Wrong!!!!");
                showValues();
                status.text = "Conection Failed";
            }
        }
        else
        {
            Debug.Log("HOLO: Endpoint not reachable!!!!");
            status.text = "Endpoint not reachable!";
        }
        //Client.setEndpoint("opc.tcp://192.168.10.251:55101");
        //Client.connect("Admin", "Labor0.75", "ns=7;s=St10-Leitstand.Station10.ReworkData.ReworkCode", "ns=7;s=St10-Leitstand.Station10.ReworkData.ReworkDone", "ns=7;s=St10-Leitstand.Station10.Work_IO.ST70_S_inpos", 500);

        //myholoobj.connect(Holopersistance.end.......,....,,)
    }

    public void onDisconnect()
    {
        Debug.Log("HOLO: input field onDisconnect");
        Client.disconnect();
        status.text = "";
        //myholoobj.disconnect(Holopersistance.end.......,....,,)
    }

    public void showValues()
    {
        endpointField.text = EndpointURL;// "endpointURL";//HoloPersistance.endpointURL;
        userField.text = Username;
        passField.text = Password;
        Subscription1Field.text = SubscriptionId1;
        Subscription2Field.text = SubscriptionId2;
        Subscription3Field.text = SubscriptionId3;
        subsTimeField.text = PublishInterval.ToString();
        status.text = "";
    }

    public void resetErrorCode()
    {
        Debug.Log("Holo: Reset TRIGGERED!!!");
        //if (HoloClient.Subscription2_status && HoloClient.Subscription1_status)
        //{
        //    Debug.Log("Holo: Reset SUCCESS!!!");

        //    Client.write(SubscriptionId2,"True"); //holopes.
        //    Client.write(SubscriptionId1, "0");
        //}

    }

    public void resetStart()
    {
        Debug.Log("Holo: ResetStart TRIGGERED!!!");
        //if (HoloClient.Subscription2_status && HoloClient.Subscription1_status && HoloClient.Subscription3_status)
        //{
        //    Debug.Log("Holo: Reset SUCCESS!!!");

        //    Client.write(SubscriptionId3, "False");

        //}

    }

}
