using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UINetwork : MonoBehaviour {
    GameObject mpPanel;
   
    Text infoText;
    NetworkManager network;
    int status = 0;
    Button btnHost;
    Button btnJoin;
    Button btnCancel;
    Button mainMenu;

    // Use this for initialization
    void Start()
    {
        mpPanel = GameObject.Find("multiPlayerPanel");
        mpPanel.SetActive(true);
        btnHost = GameObject.Find("hostButton").GetComponent<Button>();
        btnJoin = GameObject.Find("joinButton").GetComponent<Button>();
        btnCancel = GameObject.Find("cancelButton").GetComponent<Button>();
        mainMenu = GameObject.Find("mainMenuButton").GetComponent<Button>(); 

        btnHost.onClick.AddListener(StartHost);
        btnJoin.onClick.AddListener(StartJoin);
        btnCancel.onClick.AddListener(cancelGame);
        btnCancel.interactable = false;
        mainMenu.onClick.AddListener(KeMenuUtama);

        infoText = GameObject.Find("infoText").GetComponent<Text>();
       
        network = GameObject.Find("networkManager").GetComponent<NetworkManager>();
        infoText.text = "IP Address : " + Network.player.ipAddress+ " Port : " + network.networkPort;
      
    }

    private void cancelGame()
    {
        if(NetworkServer.active)
        {
            network.StopHost();
        }

        if(NetworkClient.active)
        {
            network.StopClient();
        }
        
        infoText.text = "IP Address : " + Network.player.ipAddress +" Port : " + network.networkPort;
    }

    private void StartJoin()
    {
        if(!NetworkClient.active)
        {
            network.StartClient();
            network.client.RegisterHandler(MsgType.Disconnect, ConnectionError);
        }
        if(NetworkClient.active)
        {
            infoText.text = "Connecting To Host...";
        }
    }

    private void StartHost()
    {
        if(!NetworkServer.active)
        {
            network.StartHost();
            
        }
        if(NetworkServer.active)
        {
            infoText.text = "Waiting Other Player To Join";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(NetworkServer.active || NetworkClient.active)
        {
            btnHost.interactable = false;
            btnJoin.interactable = false;
            btnCancel.interactable = true;
        }
        else
        {
            btnHost.interactable = true;
            btnJoin.interactable = true;
            btnCancel.interactable = false;
        }
       
        if (NetworkServer.connections.Count == 2 && status == 0)
        {
            status = 1;
            MulaiPermainan();
        }
        if (ClientScene.ready && !NetworkServer.active && status == 0)
        {
            status = 1;
            MulaiPermainan();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KembaliKeMain();
        }
    }

    private void ConnectionError(NetworkMessage netMsg)
    {
        KembaliKeMain();
    }

    public void MulaiPermainan()
    {
        mpPanel.SetActive(false);
    }

    public void KembaliKeMain()
    {
        network.StopHost();
        SceneManager.LoadScene("Gameplay");
    }

    public void KeMenuUtama()
    {
        if(NetworkServer.active)
        {
            network.StopHost();
        }
        if(NetworkClient.active)
        {
            network.StopClient();
        }

        SceneManager.LoadScene("Main");
    }

}
