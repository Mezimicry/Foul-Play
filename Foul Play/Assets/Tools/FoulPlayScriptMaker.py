# , {"Appear", "Name", "Location" , "", ""}
# , {"Branch", "PointName" , "", "", ""}
# , {"Branch Point", "PointName" , "", "", ""}
# , {"Change", "Name" , "SpriteNum" , "", ""}
# , {"Choice", "ChoiceText1", "ChoiceIndex1", "ChoiceText2", "ChoiceIndex2"}
# , {"Disappear", "Name" , "", "", ""}
# , {"End", "End Code" , "", "", ""}
# , {"Move", "Name" , "Location" , "Speed" , ""}
# , {"Say", "Name", "Text" , "", ""}
# , {"Sound", "SoundName" , "", "", ""}


def findCharacter():
    print("Choose a character")
    print("0. BG")
    print("1. Ebony")
    print("2. King Kavi")
    print("3. Fake Foul")
    print("4. Foul")
    print("5. Clayton")
    print("6. Basil")
    print("7. Hydra")
    print("8. Ögumo")
    print("9. Fake Foul's Guard")

    
    characterNum = int(input())

    if (characterNum == 0):
        return "BG"
    elif (characterNum == 1):
        return "Ebony"
    elif (characterNum == 2):
        return "King Kavi"
    elif (characterNum == 3):
        return "Fake Foul"
    elif (characterNum == 4):
        return "Foul"
    elif (characterNum == 5):
        return "Clayton"
    elif (characterNum == 6):
        return "Basil"
    elif (characterNum == 7):
        return "Hydra"
    elif (characterNum == 8):
        return "Ögumo"
    elif (characterNum == 9):
        return "Fake Foul's Guard"



continueMaking = True
character = ""

nameOfScript = input("Enter Script Name: ")
script = []

file = open("CreatedScript.txt", "w")




while (continueMaking):
    print("Choose which instruction you want")
    print("1. Affinity")
    print("2. Appear")
    print("3. Branch")
    print("4. Branch Point")
    print("5. Change")
    print("6. Choice")
    print("7. 2Choice")
    print("8. Disappear")
    print("9. End")
    print("10. Move")
    print("11. Say")
    print("12. Sound")
    print("101. Delete Prev Commands")
    print("999. End Program")
    wantedInstruction = int(input())

    newScriptLine = ""

    if (wantedInstruction == 999):
        print("Ending Program")
        continueMaking = False

    elif (wantedInstruction == 101):
        print("Removed Last Line")
        del script[-1]

    elif (wantedInstruction == 1):
        print("Affinity")
        character = findCharacter()
        affinityChange = input("How much should the affinity change: ")
        newScriptLine = "{\"Affinity\", \""+ character + "\" , \""+ affinityChange + "\", \"\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 2):
        print("Appear")
        character = findCharacter()
        location = input("Where should the character go: ")
        newScriptLine = "{\"Appear\", \""+ character + "\" , \""+ location + "\", \"\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 3):
        print("Branch")
        wantedIndex = input("Enter Branch Point to branch to: ")
        newScriptLine = "{\"Branch\", \""+ wantedIndex + "\" , \"\", \"\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 4):
        print("Branch Point")
        wantedIndex = input("Enter Branch Point Name: ")
        newScriptLine = "{\"Branch Point\", \""+ wantedIndex + "\" , \"\", \"\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 5):
        print("Change")
        character = findCharacter()
        spriteNum = input("Choose sprite number: ")
        newScriptLine = "{\"Change\", \""+ character + "\" , \""+ spriteNum + "\", \"\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 6):
        print("Choice")
        choiceText1 = input("Choose sweet choice text: ")
        wantedIndex = input("Choose branch point for sweet choice to branch to: ")
        choiceText2 = input("Choose sadistic choice text: ")
        wantedIndex2 = input("Choose branch point for sadistic choice to branch to: ")
        choiceText3 = input("Choose sassy choice text: ")
        wantedIndex3 = input("Choose branch point for sassy choice to branch to: ")
        choiceText4 = input("Choose strong choice text: ")
        wantedIndex4 = input("Choose branch point for strong choice to branch to: ")
        newScriptLine = "{\"Choice\", \"" + choiceText1 + "\" , \"" + wantedIndex + "\", \"" + choiceText2 + "\", \"" + wantedIndex2 + "\", \"" + choiceText3 + "\" , \"" + wantedIndex3 + "\", \"" + choiceText4 + "\", \"" + wantedIndex4 + "\"}"
        script.append(newScriptLine)
        
    elif (wantedInstruction == 7):
        print("Choice")
        choiceText1 = input("Choose first choice text: ")
        wantedIndex = input("Choose branch point for first choice to branch to: ")
        choiceText2 = input("Choose second choice text: ")
        wantedIndex2 = input("Choose branch point for second choice to branch to: ")
        newScriptLine = "{\"2Choice\", \"" + choiceText1 + "\" , \"" + wantedIndex + "\", \"" + choiceText2 + "\", \"" + wantedIndex2 + "\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 8):
        print("Disappear")
        character = findCharacter()
        newScriptLine = "{\"Disappear\", \"" + character + "\" , \"\", \"\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 9):
        exitCode = input("Choose exit code: ")
        newScriptLine = "{\"End\", \"" + exitCode + "\" , \"\", \"\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 10):
        print("Move")
        character = findCharacter()
        location = input("Choose location: ")
        speed = input("Choose speed: ")
        newScriptLine = "{\"Move\", \"" + character + "\" , \"" + location + "\", \"" + speed + "\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 11):
        print("Say")
        name = input("Choose name: ")
        dialogue = input("Write dialogue: ")
        newScriptLine = "{\"Say\", \"" + name + "\" , \"" + dialogue + "\", \"\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    elif (wantedInstruction == 12):
        print("Sound")
        sound = input("Choose sound: ")
        newScriptLine = "{\"Sound\", \"" + sound + "\" , \"\", \"\", \"\", \"\", \"\", \"\", \"\"}"
        script.append(newScriptLine)

    else:
        print("Error")






file.write(str("if (scriptName == \"" + nameOfScript + "\")"))
file.write(str("\n{"))
file.write(str("\nstring[,] script ="))
file.write("\n{\n            ")

for i in range(len(script)):
    file.write(script[i])
    if (i != (len(script) - 1 )):
        file.write(", \n            ")


file.write("\n            };")
file.write("\nreturn script;")
file.write("\n}")

file.close()

input()







