using System;
using UnityEngine;
using UnityEngine.UI;

public class TaskItemController : MonoBehaviour
{
    public Text userIdButtonText;
    public Text taskTitleButtonText;
    public Button showButton;

    public void Start()
    {
        showButton = GameObject.Find("ShowButton")?.GetComponent<Button>();
        showButton.onClick.AddListener(OnShowButtonClick);
    }

    private void OnShowButtonClick()
    {
        //islemler
    }

    public void SetData(TaskModel task)
    {
        if(userIdButtonText == null)
        {
            userIdButtonText = GameObject.Find("UserIdButtonText")?.GetComponent<Text>();
        }

        if(taskTitleButtonText == null)
        {
            taskTitleButtonText = GameObject.Find("TaskTitleButtonText")?.GetComponent<Text>();
        }

        if(task != null)
        {
            userIdButtonText.text = task.UserId;
            taskTitleButtonText.text = task.TaskTitle;
        }
    }
}
