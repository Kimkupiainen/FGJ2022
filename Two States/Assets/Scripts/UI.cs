using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public bool isPause = false;

    Canvas myCanvas;
    [Serializable]
    public class UI_Panel
    {
        //Panel Object
        [SerializeField]
        Transform thisPanel;

        //Starting point where the panel will return once deactivated --- Pondering if setting the gameobject inactive helps performance.
        [SerializeField]
        Vector2 startPos;

        [SerializeField]
        bool ispausePanel = false;

        [SerializeField]
        PanelButton[] myButtons;
        public PanelButton[] getButtons()
        {
            return myButtons;
        }

        
        public bool getPause()
        {
            return ispausePanel;
        }

        
        public Transform getPanel()
        {
            return thisPanel;
        }

        
        public Vector2 getStartPos()
        {
            return startPos;
        }

        public void setStartPos()
        {
            if (thisPanel)
            {
                startPos = thisPanel.position;
            }
        }


    }

    [Serializable]
    public class PanelButton
    {
        UI gameUI;
        [SerializeField]
        bool resume, pause, quit, back, scene;
        [SerializeField]
        int sceneNum;

        [SerializeField]
        Transform targetPanel;


        [SerializeField]
        Button myBtn;

        public Button getButton()
        {
            return myBtn;
        }

        public void Init(UI ui)
        {
            gameUI = ui;
            if (getButton())
            {
                TMP_Text ButtonText = null;
                ButtonText = myBtn.transform.GetChild(0).GetComponent<TMP_Text>();
                getButton().onClick.AddListener(delegate { Click(); });
                if (targetPanel)
                {
                    pause = false;
                    resume = false;
                    quit = false;
                    scene = false;
                    if (getButton())
                    {
                        if (back)
                        {
                            ButtonText.text = "BACK";
                        }
                        else
                        {
                            ButtonText.text = targetPanel.name;
                        }
                    }
                }
            }
        }

        void Click()
        {
            Debug.Log("BEEP");
            if(pause || resume)
            {
                gameUI.Pause();
            }else if(quit)
            {
                Application.Quit();
            }else if(scene)
            {
                SceneManager.LoadScene(sceneNum);
            }
            if(targetPanel)
            {
                gameUI.changePanel(targetPanel, false);
            }

        }
    }


           

    void Pause()
    {
        if (!isPause)
        {
            Debug.Log("PAUSE");
            changePanel(null, true);
            Time.timeScale = 0;
            isPause = true;
        }
        else
        {
            Debug.Log("RESUME");
            changePanel(null, false);
            Time.timeScale = 1;
            isPause = false;
        }
    }

    //Panel methods
    void changePanel(Transform newPanel, bool Pause)
    {
        // Use a NULL newPanel parameter if you wish to simply clear the screen from panels.

        UI_Panel foundPanel = null;
        bool duplicatePanel = false;

        if (currentPanel != null)
        {
            if (currentPanel.getPanel())
            {
                currentPanel.getPanel().transform.position = currentPanel.getStartPos();
                
            }
        }
        currentPanel = null;

        //Pause parameter is the only one that matters.
        foreach (UI_Panel pan in Panels)
        {
            if (Pause)
            {
                //Find a panel with isPauseMenu bool = true
                if (pan.getPause() == Pause)
                {
                    if (foundPanel == null)
                    {
                        foundPanel = pan;

                    }
                    else
                    {
                        duplicatePanel = true;
                        Debug.LogError("Multiple Pausepanels detected. Only 1 PausePanel is allowed on the List<UI_Panel>.");
                        break;
                    }
                }
            }
            else
            {
                //Find matching transform from panels
                if (pan.getPanel() == newPanel)
                {
                    if (foundPanel == null)
                    {
                        foundPanel = pan;

                    }
                    else
                    {
                        duplicatePanel = true;
                        Debug.LogError("Duplicate panel found");
                        break;
                    }
                }

            }

        }
        if (foundPanel != null && !duplicatePanel)
        {
            foundPanel.getPanel().position = transform.position;
            currentPanel = foundPanel;
            currentPanel.getPanel().transform.position = transform.position;
        }
    }

    [SerializeField]
    List<UI_Panel> Panels;


    [SerializeField]
    UI_Panel currentPanel = null;


    // Start is called before the first frame update
    void Start()
    {
        myCanvas = transform.GetComponent<Canvas>();
        if (myCanvas)
        {
            if (Panels.Count > 0)
            {
                foreach (UI_Panel pan in Panels)
                {
                    pan.setStartPos();
                    if (pan.getButtons().Length > 0)
                    {
                        foreach (PanelButton btn in pan.getButtons())
                        {
                            btn.Init(this);
                        }
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
}