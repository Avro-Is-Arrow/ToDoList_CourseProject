//Greeting and Fields
List<string> todoList = new List<string>();


string userInputString;
bool userWantsToExit =  false;

Console.WriteLine("Hello!");

do
{
    Console.WriteLine("\nWhat do you want to do?");
    Console.WriteLine("[S]ee all TODOs\r\n[A]dd a TODO\r\n[R]emove a TODO\r\n[E]xit\r\n");

    userInputString = Console.ReadLine();
    Console.WriteLine(); // Blank Space

    switch (userInputString.ToUpper())
    {
        case "S": // Shows all Items in TODO
            ShowAllItemsInTODOList(todoList);
            break;

        case "A": // Adds Item to TODO
            AddAnItemToTODOList(todoList);
            break;

        case "R": // Removes Item from TODO
            RemoveAnItemFromTODOList(todoList);
            break;

        case "E": // Exits the program
            Console.WriteLine("\nExiting.");
            userWantsToExit = true;
            break;

        default:
            Console.WriteLine("\nInvalid Input... Try again.");
            break;
    }

} while (!userWantsToExit);

bool ShowAllItemsInTODOList(List<string> todoList) // Simply will show ALL items within the List
{
    bool itemsInTodoList = true;

    if (todoList.Count == 0)
    {
        Console.WriteLine("\nNo TODOs have been added yet.");
        itemsInTodoList = false;
        return itemsInTodoList;
    }

    for(int i = 0; i < todoList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todoList[i]}");
    }
    
    return itemsInTodoList;
}

void AddAnItemToTODOList(List<string> todoList)
{
    string userAddedDescription;
    bool checkPassed = false;
    do
    {
        Console.WriteLine("What would you like to add to the TODO List: ");
        userAddedDescription = Console.ReadLine();
        checkPassed = ChecksUserDescription(userAddedDescription);

    } while (!checkPassed);

     Console.WriteLine($"\nTODO successfully added: {userAddedDescription}");
     todoList.Add(userAddedDescription);
}

void RemoveAnItemFromTODOList(List<string> todoList)
{
    if (!ShowAllItemsInTODOList(todoList)) return;

    
    AbleToRemoveItemFromListLogic(out int userInputIndex, todoList);


    Console.WriteLine($"\nRemoved: {todoList[userInputIndex - 1]}");
    todoList.RemoveAt(userInputIndex - 1);
}
bool ChecksUserDescription(string desc)
{
   if (desc.Trim() == "") // Checks if Description is empty
   {
        Console.WriteLine("\nThe description cannot be empty.\n");
        return false;
   }

   else if (todoList.Contains(desc)) // Checks if the Description already exists in the TODO List
   {
        Console.WriteLine("\nThe description must be unique.\n");
        return false;
   }

    return true;
        
}

void AbleToRemoveItemFromListLogic(out int inputAsInt, List<string> todoList)
{
    bool isSuccessful = false;

    do
    {
        Console.WriteLine("Enter the index of the TODO you want to remove: ");
        string userInputString = Console.ReadLine();
        isSuccessful = int.TryParse(userInputString, out inputAsInt);


        if (!isSuccessful)
        {
            Console.WriteLine("\nYou did not input a valid number/character. Try again.\n");
           continue;

        }
        else if (((inputAsInt - 1) <= 0) || ((inputAsInt) > todoList.Count))
        {
            Console.WriteLine("\nSelected index is out of range\n");
            isSuccessful = false;
        }

    } while (!isSuccessful); // Prompts the user to input the Index of the item they want to remove from the list, starts at 1

}
