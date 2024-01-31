using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public enum DialogueTypes{
    Geert, Ali_B, Japie, Joost, Karel, Nienke, Paul, Hugo, Janneke, Microfoonpersoon, Megafoonpersoon, Klaus, Niels, Johny, Pathway, Ari, Owen, Burgemeester, Stefanie, StefanieLinks,
}

public class DialogueTrigger : MonoBehaviour
{
    public DialogueTypes dialogueType;

    // Start is called before the first frame update
    public DialogueRunner dialogueRunner;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Player") == true){
            DialogueRunner dialogueRunner = collision.gameObject.GetComponentInChildren<DialogueRunner>();
                switch (dialogueType){
                case DialogueTypes.Geert:
                    dialogueRunner.StartDialogue("Geert");
                    break;
                case DialogueTypes.Ali_B:
                    dialogueRunner.StartDialogue("Ali_B");
                    break;
                case DialogueTypes.Karel:
                    dialogueRunner.StartDialogue("Karel");
                    break;
                case DialogueTypes.Japie:
                    dialogueRunner.StartDialogue("Japie");
                    break;
                case DialogueTypes.Joost:
                    dialogueRunner.StartDialogue("Joost");
                    break;
                case DialogueTypes.Nienke:
                    dialogueRunner.StartDialogue("Nienke");
                    break;
                case DialogueTypes.Paul:
                    dialogueRunner.StartDialogue("Paul");
                    break;
                case DialogueTypes.Hugo:
                    dialogueRunner.StartDialogue("Hugo");
                    break;
                case DialogueTypes.Janneke:
                    dialogueRunner.StartDialogue("Janneke");
                    break;
                case DialogueTypes.Microfoonpersoon:
                    dialogueRunner.StartDialogue("Microfoonpersoon");
                    break;
                case DialogueTypes.Megafoonpersoon:
                    dialogueRunner.StartDialogue("Megafoonpersoon");
                    break;
                case DialogueTypes.Johny:
                    dialogueRunner.StartDialogue("Johny");
                    break;
                case DialogueTypes.Niels:
                    dialogueRunner.StartDialogue("Niels");
                    break;
                case DialogueTypes.Klaus:
                    dialogueRunner.StartDialogue("Klaus");
                    break;
                case DialogueTypes.Pathway:
                    dialogueRunner.StartDialogue("Pathway");
                    break;
                case DialogueTypes.Owen:
                    dialogueRunner.StartDialogue("Owen");
                    break;
                case DialogueTypes.Ari:
                    dialogueRunner.StartDialogue("Ari");
                    break;
                case DialogueTypes.Burgemeester:
                    dialogueRunner.StartDialogue("Burgemeester");
                    break;
                case DialogueTypes.Stefanie:
                    dialogueRunner.StartDialogue("Stefanie");
                    break;
                case DialogueTypes.StefanieLinks:
                    dialogueRunner.StartDialogue("StefanieLinks");
                    break;
            }
        }
    }
}
