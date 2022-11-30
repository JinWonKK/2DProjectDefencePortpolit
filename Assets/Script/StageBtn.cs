using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum STAGE
{
    stage1,
    stage2,
    stage3,
    stage4,
    stage5,
    stage6,
}

public class StageBtn : MonoBehaviour
{
    [SerializeField]
    private STAGE stage;

    [SerializeField]
    private GameObject star1;
    [SerializeField]
    private GameObject star2;
    [SerializeField]
    private GameObject star3;
    [SerializeField]
    private GameObject lockObj;

    private Button clickBtn;

    private void Awake()
    {
        clickBtn = GetComponent<Button>();
        StageInit(stage);
        StarInit(stage);
    }

    private void StarSetActive(bool val)
    {
        star1.SetActive(val);
        star2.SetActive(val);
        star3.SetActive(val);
        clickBtn.interactable = val;
    }

    private void StageInit(STAGE stage)
    {
        StarSetActive(false);
        switch (stage)
        {
            case STAGE.stage1:
                {
                    StarSetActive(true);
                    lockObj.SetActive(false);
                    break;
                }
            case STAGE.stage2:
                {
                    if(GameManager.Inst.PlayerInfo.clearStage > 0)
                    {
                        StarSetActive(true);
                        lockObj.SetActive(false);
                    }
                    else
                    {
                        lockObj.SetActive(true);
                    }
                    break;
                }
            case STAGE.stage3:
                {
                    if (GameManager.Inst.PlayerInfo.clearStage > 1)
                    {
                        StarSetActive(true);
                        lockObj.SetActive(false);
                    }
                    else
                    {
                        lockObj.SetActive(true);
                    }
                    break;
                }
            case STAGE.stage4:
                {
                    if (GameManager.Inst.PlayerInfo.clearStage > 2)
                    {
                        StarSetActive(true);
                        lockObj.SetActive(false);
                    }
                    else
                    {
                        lockObj.SetActive(true);
                    }
                    break;
                }
            case STAGE.stage5:
                {
                    if (GameManager.Inst.PlayerInfo.clearStage > 3)
                    {
                        StarSetActive(true);
                        lockObj.SetActive(false);
                    }
                    else
                    {
                        lockObj.SetActive(true);
                    }
                    break;
                }
            case STAGE.stage6:
                {
                    if (GameManager.Inst.PlayerInfo.clearStage > 4)
                    {
                        StarSetActive(true);
                        lockObj.SetActive(false);
                    }
                    else
                    {
                        lockObj.SetActive(true);
                    }
                    break;
                }
        }
    }

    private void StarInit(STAGE stage)
    {
        switch(stage)
        {
            case STAGE.stage1:
                {
                    switch(GameManager.Inst.PlayerInfo.stage1Star)
                    {
                        case 0:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(false);
                                break;
                            }
                        case 1:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 2:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 3:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                    }
                    break;
                }
            case STAGE.stage2:
                {
                    switch (GameManager.Inst.PlayerInfo.stage2Star)
                    {
                        case 0:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(false);
                                break;
                            }
                        case 1:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 2:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 3:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                    }
                    break;
                }
            case STAGE.stage3:
                {
                    switch (GameManager.Inst.PlayerInfo.stage3Star)
                    {
                        case 0:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(false);
                                break;
                            }
                        case 1:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 2:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 3:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                    }
                    break;
                }
            case STAGE.stage4:
                {
                    switch (GameManager.Inst.PlayerInfo.stage4Star)
                    {
                        case 0:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(false);
                                break;
                            }
                        case 1:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 2:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 3:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                    }
                    break;
                }
            case STAGE.stage5:
                {
                    switch (GameManager.Inst.PlayerInfo.stage5Star)
                    {
                        case 0:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(false);
                                break;
                            }
                        case 1:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 2:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 3:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                    }
                    break;
                }
            case STAGE.stage6:
                {
                    switch (GameManager.Inst.PlayerInfo.stage6Star)
                    {
                        case 0:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(false);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(false);
                                break;
                            }
                        case 1:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 2:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                        case 3:
                            {
                                star1.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star2.transform.GetChild(0).transform.gameObject.SetActive(true);
                                star3.transform.GetChild(0).transform.gameObject.SetActive(true);
                                break;
                            }
                    }
                    break;
                }
        }
    }
}
