using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour {

    [SerializeField] private Grid gameplayMenu;
    [SerializeField] private Grid equipmentMenu;
    [SerializeField] public Grid abillitiesMenu;
    [SerializeField] private Grid skillTree;
    [SerializeField] private Grid quitMenu;

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

    void Start()
    {
        QuitAllMenus();
    }

    public void QuitAllMenus()
    {
        QuitMenu();
        skillTree.gameObject.SetActive(false);
        skillTree.enabled = false;
        equipmentMenu.gameObject.SetActive(false);
        equipmentMenu.enabled = false;
        abillitiesMenu.gameObject.SetActive(false);
        abillitiesMenu.enabled = false;
        quitMenu.gameObject.SetActive(false);
        quitMenu.enabled = false;
    }

    public void Quit() {
        Debug.LogError("Game Quitted");
        Application.Quit();
    }

    public void OpenMenu() {
        gameplayMenu.gameObject.SetActive(true);
        gameplayMenu.enabled = true;
    }

    public void QuitMenu() {
        gameplayMenu.gameObject.SetActive(false);
        gameplayMenu.enabled = false;
    }

    public void OpenSkillTree() {
        QuitMenu();
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
        QuitMenu();
        equipmentMenu.gameObject.SetActive(true);
        equipmentMenu.enabled = true;
    }

    public void QuitEquipmentMenu() {
        equipmentMenu.gameObject.SetActive(false);
        equipmentMenu.enabled = false;
        gameplayMenu.gameObject.SetActive(true);
        gameplayMenu.enabled = true;
    }
    public void OpenAbillitiesMenu()
    {
        QuitMenu();
        abillitiesMenu.gameObject.SetActive(true);
        abillitiesMenu.enabled = true;
    }

    public void QuitAbillitiesMenu()
    {
        abillitiesMenu.gameObject.SetActive(false);
        abillitiesMenu.enabled = false;
        gameplayMenu.gameObject.SetActive(true);
        gameplayMenu.enabled = true;
    }

    public void OpenQuitMenu()
    {
        QuitMenu();
        quitMenu.gameObject.SetActive(true);
        quitMenu.enabled = true;
    }

    public void QuitQuitMenu()
    {
        quitMenu.gameObject.SetActive(false);
        quitMenu.enabled = false;
        gameplayMenu.gameObject.SetActive(true);
        gameplayMenu.enabled = true;
    }
}
