﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void LoadFirstLeveL(){
        SceneManager.LoadScene(1);
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0);
    }
}
