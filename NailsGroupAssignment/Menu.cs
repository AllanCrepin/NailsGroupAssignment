using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsGroupAssignment
{
    public class Menu
    {
        private List<string> MenuOptions { get; set; } = new List<string>();

        private string Prompt = "";

        public int ChooseNumberDays()
        {
            Prompt = "How many days do you want the simulation to run?";

            MenuOptions = new List<string>
            {
                "10 Days", "20 Days", "30 Days", "40 Days", "50 Days", "60 Days"
            };

            int menuSelection = GetMenuSelection();
            return (menuSelection + 1) * 10; // We add +1 to the selected index, and multiply by 10 to get the correct amount of days
            // that the user wants simulated: between 10 and 60.
        }

        public int GetMenuSelection()
        {
            int selectedOption = 0;
            bool optionSelected = false;

            while (!optionSelected)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine(Prompt);
                DisplayMenuOptions(selectedOption);
                optionSelected = HandleUserInput(ref selectedOption);
            }

            return selectedOption;
        }
        private void DisplayMenuOptions(int highlightedIndex)
        {
            for (int i = 0; i < MenuOptions.Count; i++)
            {
                if (i == highlightedIndex) { Console.ForegroundColor = ConsoleColor.Green; }
                else { Console.ForegroundColor = ConsoleColor.Gray; }
                Console.WriteLine(MenuOptions[i]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private bool HandleUserInput(ref int selectedIndex)
        {
            var keyPressed = Console.ReadKey();

            switch (keyPressed.Key)
            {
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % MenuOptions.Count;
                    break;
                case ConsoleKey.UpArrow:
                    if (selectedIndex == 0) { selectedIndex = MenuOptions.Count - 1; }
                    else { selectedIndex--; }
                    break;
                case ConsoleKey.Enter:
                    return true;
            }
            return false;
        }
    }
}
