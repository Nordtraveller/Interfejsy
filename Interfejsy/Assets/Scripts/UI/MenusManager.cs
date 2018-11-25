using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour {

    [SerializeField] private Grid gameplayMenu;
    [SerializeField] private Grid skillTree;
    [SerializeField] private Grid equipmentMenu;

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
        gameplayMenu.enabled = false;
        skillTree.enabled = true;
    }

    public void QuitSkillTree() {
        skillTree.enabled = false;
        gameplayMenu.enabled = true;
    }

    public void OpenEquipmentMenu() {
        gameplayMenu.enabled = false;
        equipmentMenu.enabled = true;
    }

    public void QuipEquipmentMenu() {
        equipmentMenu.enabled = false;
        gameplayMenu.enabled = true;
    }
}
