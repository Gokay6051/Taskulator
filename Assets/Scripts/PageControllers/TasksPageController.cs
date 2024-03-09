using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TasksPageController : MonoBehaviour
{
    public GameObject taskItemPrefab; //Prefab to list 
    public Transform contentContainer; //Content object that inside ScrollView
    public Button addTaskButton;
    public Button mainPageButton;

    void Start()
    {
        addTaskButton = GameObject.Find("AddTaskButton").GetComponent<Button>();
        addTaskButton.onClick.AddListener(OnButtonClick);

        mainPageButton = GameObject.Find("MainPageButton").GetComponent<Button>();
        mainPageButton.onClick.AddListener(OnMainButtonClick);

        RealmController.Instance.onLogIn.AddListener(TasksFunc);
        if (RealmController.Instance.IsRealmTaskReady())
        {
            TasksFunc();
        }
        
    }

    public void OnObjectButtonClick()
    {
        SceneManager.LoadScene("DisplayTaskPage");
    }

    private void OnMainButtonClick()
    {
        SceneManager.LoadScene("MainPage");
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene("AddTaskPage");
    }

                            
    public void TasksFunc()
    {                          
        List<TaskModel> tasks = RealmController.Instance.GetRealmTask().All<TaskModel>().ToList();
                    
        foreach (var task in tasks)
        {
            var taskItem = Instantiate(taskItemPrefab, contentContainer); //coppy the prefab
            TaskItemController taskItemController = taskItem.GetComponent<TaskItemController>();

            if(taskItemController != null) 
            {
                taskItemController.SetData(task);
                Debug.Log("33333333333");
            }      
        }
    }
}
