using UnityEngine;
using Zenject;

public class GuiHandler  : MonoBehaviour{

        [SerializeField]
        GUIStyle _timeStyle;

    [Inject] private DrowLineComponent.Factory _factoryLine;
    [Inject] private TrainController.Factory _factoryTrain;
        
        void OnGUI() {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            {
//                switch (_gameController.State)
//                {
//                    case GameStates.WaitingToStart:
//                    {
//                        StartGui();
//                        break;
//                    }
//                    case GameStates.Playing:
//                    {
//                        PlayingGui();
//                        break;
//                    }
//                    case GameStates.GameOver:
//                    {
//                        PlayingGui();
//                        GameOverGui();
//                        break;
//                    }
//                    default:
//                    {
//                        Assert.That(false);
//                        break;
//                    }
//                
//                }

                PlayingGui();

            }
            GUILayout.EndArea();
        }
        
        void PlayingGui()
        {
            GUILayout.BeginVertical();
            {
                GUILayout.Space(30);
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Space(30);
                    GUILayout.Label("Time: ", _timeStyle);
                    GUILayout.FlexibleSpace();
                    
                    if (GUILayout.Button("Create Line")) {
                        _factoryLine.Create();
                    }
                    if (GUILayout.Button("Create Train")) {
                        _factoryTrain.Create();
                    }
//                    if (GUILayout.Button("Station"))
//                    {
//                        Debug.Log("Clicked the image");
//                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
    }