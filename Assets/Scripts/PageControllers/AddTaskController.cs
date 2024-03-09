using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddTaskController : MonoBehaviour
{
    public InputField TaskTitle;
    public InputField TaskMain;
    public Button AddTask;
    public Button Back;
    UserModel userModel = UserDataManager.Instance.userModel;

    void Start()
    {
        AddTask = GameObject.Find("AddButton").GetComponent<Button>();
        AddTask.onClick.AddListener(OnAddTaskButtonClick);

        Back = GameObject.Find("BackButton").GetComponent<Button>();
        Back.onClick.AddListener(OnBackButtonClick);
    }

    private void OnAddTaskButtonClick()
    {
        if(TaskTitle == null)
        {
            TaskTitle = GameObject.Find("TaskTitleEditText").GetComponent<InputField>();
        }

        if(TaskMain == null)
        {
            TaskMain = GameObject.Find("TaskMainEditText").GetComponent<InputField>();
        }

        if(RealmController.Instance.IsRealmTaskReady())
        {
            if(userModel != null) //userModel = null
            {
                Debug.Log("userModel != null");
                RealmController.Instance.AddTaskModel(TaskMain.text, TaskTitle.text, userModel.UserId);
            }
            
        }
        SceneManager.LoadScene("TasksPage");
    }

    private void OnBackButtonClick()
    {
        SceneManager.LoadScene("TasksPage");
    }

}
