using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIhandler : MonoBehaviour
{
    private VisualElement m_Healthbar;
    public static UIhandler instance { get; private set; }
    public float displayTime = 4.0f;
    private VisualElement m_NonPlayerDialogue;
    private float m_TimerDisplay;
    private Button menuButton;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);

        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("DialogNPC");
        m_NonPlayerDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;

        menuButton = uiDocument.rootVisualElement.Q<Button>("Menu");
        menuButton.clicked += ReturnToMenu;

    }
    void Start()
    {

        //query HealthBar from visualElement
        
        

    }

    void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay < 0)
            {
                m_NonPlayerDialogue.style.display = DisplayStyle.None;
            }
        }
    }

    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    public void DisplayDialogue()
    {
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }

    void ReturnToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

}
