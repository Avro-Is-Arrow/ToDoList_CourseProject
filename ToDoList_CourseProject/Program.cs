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
    else
    {
        for(int i = 0; i < todoList.Count; i++)
        {
            Console.WriteLine($"{i+1}. {todoList[i]}");
        }
    }
    return itemsInTodoList;
}

void AddAnItemToTODOList(List<string> todoList)
{
    string userAddedDescription;
    Console.WriteLine("Enter the TODO description: ");
    userAddedDescription = Console.ReadLine();

    if (userAddedDescription.Trim() == "") // Checks if Description is empty
    {
        Console.WriteLine("\nThe description cannot be empty.\n");
        AddAnItemToTODOList(todoList);
    }

    else if(todoList.Contains(userAddedDescription)) // Checks if the Description already exists in the TODO List
    {
        Console.WriteLine("\nThe description must be unique.\n");
        AddAnItemToTODOList(todoList);
    }

    else // If all else is false, then add the item to the List
    {
        Console.WriteLine($"\nTODO successfully added: {userAddedDescription}");
        todoList.Add(userAddedDescription);
    }
}

void RemoveAnItemFromTODOList(List<string> todoList)
{
    string inputInt;
    bool wasSuccesful;
    int userInputIndex;

    Console.WriteLine("Select the index of the TODO you want to remove: \n");
    if (!ShowAllItemsInTODOList(todoList)) return;

    do
    {
        Console.Write("Which item would you like to remove? (Provide Index): ");
        inputInt = Console.ReadLine();

        wasSuccesful = int.TryParse(inputInt, out userInputIndex);

        if (!wasSuccesful)
        {
            Console.WriteLine("You did not input a valid number/character. Try again.\n");
        }

        if ( ((userInputIndex - 1) <= todoList.Count) && ((userInputIndex - 1) > -1)) 
        {
            Console.WriteLine($"Removed: {todoList[userInputIndex - 1]}");
            todoList.RemoveAt(userInputIndex - 1);
            
        }
        else
        {
            Console.WriteLine("Selected index cannot be empty\n");
            wasSuccesful = false;
        }

    } while (!wasSuccesful); // Prompts the user to input the Index of the item they want to remove from the list, starts at 1
    
}

