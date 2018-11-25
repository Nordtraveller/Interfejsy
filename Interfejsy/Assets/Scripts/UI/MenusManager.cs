using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour {

    [SerializeField] private Grid gameplayMenu;
    [SerializeField] private Grid equipmentMenu;
    [SerializeField] private Grid abillitiesMenu;
    [SerializeField] private Grid skillTree;

    static MenusManager instance_;
    public static MenusManager instance {
        get {
            if (instance_ == null) {
                GameObject go = new GameObject();
                instance_ = go.AddComponent<MenusManager>();
            }
            return instance_;
        }
    }

    public void Quit() {
        Application.Quit();
    }

    public void OpenMenu() {
        gameplayMenu.enabled = true;
    }

    public void QuitMenu() {
        gameplayMenu.enabled = false;
    }

    public void OpenSkillTree() {
        gameplayMenu.gameObject.SetActive(false);
        gameplayMenu.enabled = false;
        skillTree.gameObject.SetActive(true);
        skillTree.enabled = true;
    }

    public void QuitSkillTree() {
        skillTree.gameObject.SetActive(false);
        skillTree.enabled = false;
        gameplayMenu.gameObject.SetActive(true);
        gameplayMenu.enabled = true;
    }

    public void OpenEquipmentMenu() {
        gameplayMenu.gameObject.SetActive(false);
        gameplayMenu.enabled = false;
        equipmentMenu.gameObject.SetActive(true);
        equipmentMenu.enabled = true;
    }

    public void QuipEquipmentMenu() {
        equipmentMenu.gameObject.SetActive(false);
        equipmentMenu.enabled = false;
        gameplayMenu.gameObject.SetActive(true);
        gameplayMenu.enabled = true;
    }
    public void OpenAbillitiesMenu()
    {
        gameplayMenu.gameObject.SetActive(false);
        gameplayMenu.enabled = false;
        abillitiesMenu.gameObject.SetActive(true);
        abillitiesMenu.enabled = true;
    }

    public void QuipAbillitiesMenu()
    {
        abillitiesMenu.gameObject.SetActive(false);
        abillitiesMenu.enabled = false;
        gameplayMenu.gameObject.SetActive(true);
        gameplayMenu.enabled = true;
    }
}
