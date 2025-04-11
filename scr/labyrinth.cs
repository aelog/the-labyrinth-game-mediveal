// Template for a window:
// Console.WriteLine("=======================================================================================================");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");                
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("|                                                                                                     |");
// Console.WriteLine("=======================================================================================================");

using System;
using System.Threading;
using System.Collections;

namespace WalkGame{

    class Save{

        public static void Map(int[,] card){

            string out_code = "";
            long work_symbol = 0; 

                for (int l = 0; l != 9; l++){

                    for (int n = 0; n != 9; n++){

                        string btw_code = "";

                        work_symbol = card[l, n];

                        switch (work_symbol){

                            default:
                                btw_code += Convert.ToString(work_symbol);
                                break;

                            case 10:
                                btw_code += "A";
                                break;

                            case 11:
                                btw_code += "B";
                                break;

                            case 12:
                                btw_code += "C";
                                break;

                            case 13:
                                btw_code += "D";
                                break;
                        }
                        out_code += btw_code;
                    }
                }

                Console.WriteLine("\n");
                Console.WriteLine("There is a code of your map: ");
                Console.WriteLine(out_code);
                Console.ReadKey();
            }

        public static void DecryptMap(){ // This method decrypts user saved maps

            string[] nummas = new string[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

            Console.Clear();

            Console.WriteLine("Please write a code: ");
            int[,] out_map = new int[9, 9]; // Making an empty map
            string code = Console.ReadLine();

            if (code == "x"){

                Walker.Menu();
                return;
            }
            else if (code == "" || code.Length != 81) {
                Console.WriteLine("Code cannot be empty or be less/more than 81 symbols.");
                DecryptMap();
                return;
            }

            int z = 0;

            for (int y = 0; y < 9; y++) {
                for (int x = 0; x < 9; x++) {
                    string out_symbol = Convert.ToString(code[z]);
                    int out_num = 0;
                    
                    switch (out_symbol){

                        case "A":
                            out_num = 10;
                            break;

                        case "B":
                            out_num = 11;
                            break;

                        case "C":
                            out_num = 12;
                            break;

                        case "D":
                            out_num = 13;
                            break;

                        default:
                            if (Walker.Contains(nummas, out_symbol)){

                                out_num = Convert.ToInt32(out_symbol);
                            }
                            else{

                                out_num = 0;
                            }
                            break;
                    }
                    out_map[y, x] = out_num;
                    z++;
                }
            }

            Walker.map = out_map;
            Walker.Gameplay();
        }
    }    

    class Walker{

        public static int[,] map;

        public static int[] inventory = new int[] {0, 0, 0};

        public static bool working = true;
        public static bool wallsWalk = false;
        public static bool thingTaken = false;
        public static bool wrongSymbol = false;
        public static bool inventoryOpen = false;
        public static bool won = false;
        public static bool eatFood = false;
        public static bool enemyKilled = false;
        public static bool died = false;
        public static bool doorNotOpened = false;
        public static bool debug = false;
        public static bool isUserMap = false;
        
        public static int player_x = -1;
        public static int player_y = -1;
        public static int health = 10;
        public static int hungry = 10;
        public static int current_level = 1;
        public static string[] elems = new string[] {"   ", "███", "=D ", " ╡╞", " Ω ", "End", "└─┘", ">=P", "|+|", "^^^", " / ", "╓─█", "III", "???"};
        public static string[] things = new string[] {"... - nothing", " ╡╞ - sword", "╓─▌ - key", "III - bridge"};
        public static int[,] user_map = new int[9, 9];
        public static int[,] code_map = new int[9, 9];
        public static int new_x;
        public static int old_x;
        public static int new_y;
        public static int old_y;
        public static int steps = 0;
        public static string thing_type = "";
        public static int score = 0;

        public static bool Contains(string[] massive, string element){ // Check if element contains in massive

            bool isCont = false;

            foreach (var m_elem in massive){

                if (element == m_elem){

                    isCont = true;
                    break;
                }
            }

            return isCont;
        }

        public static void LevelSelect(){
            
            string [] ls_Buttons = {"l1", "l2", "l3"};
            string [] ls_Choosed_buttons = {"L1", "L2", "L3"};
            string [] ls_Work_buttons = {"l1", "l2", "l3"};

            int x = 0;
            while (working == true){

                Console.Clear();

                ls_Work_buttons[x] = ls_Choosed_buttons[x];
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|                                                                                                     |");
                Console.WriteLine("|                                    Welcome to Level Select!                                         |");
                Console.WriteLine("|                                                                                                     |");
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|          |         |         |         |         |         |         |         |         |          |");
                Console.WriteLine("|    " + ls_Work_buttons[0] + "    |    " + ls_Work_buttons[1] + "   |    " + ls_Work_buttons[2] + "   |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ??    |");
                Console.WriteLine("|          |         |         |         |         |         |         |         |         |          |");
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|          |         |         |         |         |         |         |         |         |          |");
                Console.WriteLine("|    ??    |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ??    |");
                Console.WriteLine("|          |         |         |         |         |         |         |         |         |          |");
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|          |         |         |         |         |         |         |         |         |          |");
                Console.WriteLine("|    ??    |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ??    |");
                Console.WriteLine("|          |         |         |         |         |         |         |         |         |          |");
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|          |         |         |         |         |         |         |         |         |          |");
                Console.WriteLine("|    ??    |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ?    |    ??    |");
                Console.WriteLine("=======================================================================================================");
                string choose = Convert.ToString(Console.ReadKey().KeyChar);
                ls_Work_buttons[x] = ls_Buttons[x];

                switch (choose){

                    case "a":
                        x--;
                        if (x < 0){

                            x = 2;
                        }
                        break;

                    case "d":
                        x++;
                        if (x > 2){

                            x = 0;
                        }
                        break;

                    case "e":
                        current_level = x + 1;
                        Levels(x, true);
                        Gameplay();
                        break;

                    case "x":
                        Menu();
                        break;
                }
            }
        }

        public static void MapMaker(){ // Map Creator method

            string[] nummas = new string[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

            Console.Clear();
            Console.WriteLine("Make a level by symbols: ");
            Console.WriteLine("       ABCDEFGHI");
            Console.WriteLine("       |||||||||");
            int stroka_num = 1; // Sorry for russian words I didn't know how to call this variable

            for (int l = 0; l != 9; l++){

                string symvol = ""; // Need for symbol check
                string user_wall = "";
                int out_symvol = 0;
                bool lessnine = false;

                Console.Write(stroka_num + " :>>> ");
                user_wall = Console.ReadLine();

                if (user_wall.Length < 9){

                    Console.WriteLine("Last string has got less than 9 symbols. In won't be used!");
                }
                else if (user_wall.Length > 9){

                    Console.WriteLine("WARNING: Last string has got more than 9 symbols. 10th, 11th, 12th, etc. symbols are not be included in the level.");
                }

                for (int n = 0; n != 9; n++){

                    if (user_wall.Length < 9){

                        lessnine = true;
                        continue;
                    }

                    symvol = Convert.ToString(user_wall[n]);

                    switch (symvol){

                        default:
                            if (Contains(nummas, symvol)){

                                out_symvol = Convert.ToInt32(symvol);
                            }
                            else{

                                out_symvol = 0;
                            }
                            break;

                        case "A":
                            out_symvol = 10;
                            break;

                        case "B":
                            out_symvol = 11;
                            break;

                        case "C":
                            out_symvol = 12;
                            break;

                        case "D":
                            out_symvol = 13;
                            break;
                    }

                    user_map[l, n] = out_symvol;
                }
                if (lessnine == false){
                    stroka_num += 1;
                }
                else{
                    l--;
                }
            }

            map = user_map;
            isUserMap = true;
            code_map = (int[,])user_map.Clone();
            Gameplay();
        }

        public static void Move(string new_move){ //This method checks moves of the player

            switch (new_move){

                case "w":
                    new_y = old_y - 1;
                    new_x = old_x;
                    if (new_y < 0){

                        new_y = 8;
                    }
                    break;

                case "s":
                    new_y = old_y + 1;
                    new_x = old_x;
                    if (new_y > 8){

                        new_y = 0;
                    }
                    break;
                
                case "a":
                    new_x = old_x - 1;
                    new_y = old_y;
                    if (new_x < 0){

                        new_x = 8;
                    }
                    break;

                case "d":
                    new_x = old_x + 1;
                    new_y = old_y;
                    if (new_x > 8){

                        new_x = 0;
                    }
                    break;
                
            }

            if (map[new_y, new_x] == 1){ // Check tries to walk in the wall

                wallsWalk = true;
            }
            else if(map[new_y, new_x] == 10){ // Check tries to walk in the doors without a key

                int k_tries = 0;

                for (int q = 0; q != 3; q++){

                    if (inventory[q] == 2){

                        inventory[q] = 0;
                        break;
                    }
                    else{

                        k_tries++;
                        if (k_tries == 2){

                            doorNotOpened = true;
                            new_y = old_y;
                            new_x = old_x;
                            break;
                        }
                    }
                }

                k_tries = 0;
            }
            else{ // These conditions are with satiety and health change, before - without

                if (steps == 4){ // Steps check

                    if (hungry == 0){

                        steps = 0;
                        health--;
                    }
                    else{

                        steps = 0;
                        hungry--;
                    }
                }
                else{

                    steps++;
                }

                if (health == 0){ // Health check

                    died = true;
                }

                int new_location = map[new_y, new_x];

                switch (new_location){

                    case 3: // Get sword

                        thingTaken = true;
                        thing_type = "sword";
                        for (int q = 0; q < 3; q++){

                            if (inventory[q] == 0){ // Inventory check

                                inventory[q] = 1;
                                break;
                            }
                        }
                        break;

                    case 5: // Finish check

                        won = true;
                        break;

                    case 6: // Bowl check

                        hungry++;
                        eatFood = true;
                        break;

                    case 7: // Enemy check

                        int tries = 0;

                        for (int q = 0; q != 3; q++){

                            if (inventory[q] == 1){ // Inventory check

                                enemyKilled = true;
                                inventory[q] = 0;
                                break;
                            }
                            else{

                                tries++;
                                if (tries == 3){

                                    health -= 3;
                                    tries = 0;
                                    break;
                                }
                            }
                        }

                        tries = 0;
                        break;
                        

                    case 8: // Health box check

                        health++;
                        break;

                    case 9: // Spikes check

                        int sp_tries = 0;

                        for (int q = 0; q != 3; q++){

                            if (inventory[q] == 3){ // Inventory check

                                inventory[q] = 0;
                                break;
                            }
                            else{

                                sp_tries++;
                                if (sp_tries == 3){

                                    health -= 3;
                                    break;
                                }
                            }
                        }

                        sp_tries = 0;
                        break;

                    case 11: // Get key

                        thingTaken = true;
                        thing_type = "key";
                        for (int q = 0; q < 3; q++){

                            if (inventory[q] == 0){ // Inventory check

                                inventory[q] = 2;
                                break;
                            }
                        }
                        break;

                    case 12: // Get bridge

                        thingTaken = true;
                        thing_type = "bridge";
                        for (int q = 0; q < 3; q++){

                            if (inventory[q] == 0){ // Inventory check

                                inventory[q] = 3;
                                break;
                            }
                        }
                        break;

                    case 13: // Get ???
                        Random rnd = new Random();
                        int rthing = rnd.Next(0, 4);
                        int out_r = 0;
                        thingTaken = true;
                        switch (rthing){

                            case 0:
                                thing_type = "nothing";
                                break;

                            case 1:
                                thing_type = "sword";
                                out_r = 1;
                                break;

                            case 2:
                                thing_type = "key";
                                out_r = 2;
                                break;

                            case 3:
                                thing_type = "bridge";
                                out_r = 3;
                                break;

                        }

                        for (int q = 0; q < 3; q++){

                            if (inventory[q] == 0){ // Inventory check

                                inventory[q] = out_r;
                                break;
                            }
                        }
                        break;
                    }
                
                map[old_y, old_x] = 0;
                map[new_y, new_x] = 2;
            }
        }

        public static void About(){ // "About A Game" menu

            Console.Clear();

            Console.WriteLine("=======================================================================================================");
            Console.WriteLine("|                                           About  the game                                           |");
            Console.WriteLine("|      Welcome to The Labytinth v. 0.1! There you can to know everything about this game!             |");
            Console.WriteLine("|  =D - This is you. You can walk by wasd and watch your inventory by i.                              |");
            Console.WriteLine("|  >=P - This is your enemy. You need to kill him by sword or you will die.                           |");
            Console.WriteLine("|  ╡╞ - This is a sword. By this thing you can kill your enemies but it will dissapeas after one use. |");
            Console.WriteLine("|  End - This is the end of the labyrinth. After you'll go there you will go to the next level.       |");
            Console.WriteLine("|  └─┘ - This is the bowl. If you will take it, you won't be hungry!                                  |");
            Console.WriteLine("|   Ω - This is a teleport. If you walk to it, you will be transfered to another place on the level.  |");
            Console.WriteLine("|  |+| - This is a medicine box. Take it, and you'll get +1 Health.                                   |");
            Console.WriteLine("|  ^^^ - These are spikes. You'll fall to them, if you don't have a bridge. And yeah, it is - III.     |");
            Console.WriteLine("|  ╓─▌, / - These are key and lock. Lock locks ways, key opens ways.                                  |");
            Console.WriteLine("=======================================================================================================");
            Console.WriteLine("|                                             Story Line                                              |");                
            Console.WriteLine("|     You are a typical knight in 13th century France. You tried to make revolution and overthrow the |");
            Console.WriteLine("|  king with your allies, but all of you were jailed into the big fortress labyrinth. Your main goal  |");
            Console.WriteLine("|  is go away from the labyrinth and win the boss - L...                                              |");
            Console.WriteLine("=======================================================================================================");
            Console.WriteLine("| Press Enter to back to menu or press d to watch copyrights and license                              |");
            Console.WriteLine("=======================================================================================================");
            System.ConsoleKeyInfo apress = Console.ReadKey();
            string press = Convert.ToString(apress.KeyChar);
            if (press == "d"){

                Console.Clear();

                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|                                                License                                              |");
                Console.WriteLine("|  Copyright: (C) AntELO(aelog), 2025                                                                 |");
                Console.WriteLine("|     Permission is hereby granted, free of charge, to any person obtaining a copy of this software & |");
                Console.WriteLine("|  associated documentation files, to deal in the Software without restriction, including without li- |");
                Console.WriteLine("|  mitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies");
                Console.WriteLine("|  of , and to permit persons to whom the Software is furnished to do so, subject to the following    |");
                Console.WriteLine("|  conditions:                                                                                        |");
                Console.WriteLine("|                                                                                                     |");
                Console.WriteLine("|     The above copyright notice and this permission notice shall be included in all copies or        |");
                Console.WriteLine("|  substantial portions of the Software.                                                              |");
                Console.WriteLine("|                                                                                                     |");
                Console.WriteLine("|     THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING   |");                
                Console.WriteLine("|  BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND         |"); 
                Console.WriteLine("|  NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,       |");
                Console.WriteLine("|  DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT |");
                Console.WriteLine("|  OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                |");
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("| Repos: https://github.com/aelog/the-labyrinth-game-mediveal             Press Enter to back to menu |");
                Console.WriteLine("=======================================================================================================");
                Console.ReadKey();
            }
            Menu();
        }

        public static void Levels(int now_level, bool need_slide){ // This method changes levels

            int new_level;
            string need_map;
            string new_level_s;

            // Maps:

            int[,] map1 = new int[,] {{1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 2, 1, 0, 0, 0, 0, 0, 1},
                                      {1, 0, 1, 0, 1, 1, 1, 6, 1},
                                      {1, 0, 1, 0, 1, 6, 1, 1, 1},
                                      {1, 0, 0, 0, 1, 0, 1, 1, 1},
                                      {1, 0, 1, 0, 0, 0, 0, 0, 1},
                                      {1, 0, 1, 1, 1, 1, 3, 1, 1},
                                      {1, 8, 1, 5, 0, 0, 0, 0, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1}};

            int[,] map2 = new int[,] {{1, 0, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 0, 1, 6, 0, 0, 0, 0, 1},
                                      {1, 0, 1, 1, 1, 0, 1, 0, 1},
                                      {1, 0, 0, 0, 0, 0, 1, 0, 1},
                                      {1, 1, 1, 1, 1, 0, 1, 5, 1},
                                      {1, 0, 0, 0, 1, 0, 1, 1, 1},
                                      {1, 0, 1, 0, 1, 0, 1, 8, 1},
                                      {1, 0, 1, 2, 1, 0, 6, 0, 1},
                                      {1, 0, 1, 1, 1, 1, 1, 1, 1}};

            int[,] map3 = new int[,] {{1, 1, 1, 0, 1, 1, 1, 0, 1},
                                      {1, 5, 0, 0, 0, 1, 3, 0, 1},
                                      {1, 1, 1, 0, 1, 1, 1, 1, 1},
                                      {1, 0, 1, 1, 1, 0, 0, 0, 1},
                                      {1, 0, 6, 0, 7, 0, 1, 2, 1},
                                      {1, 0, 1, 0, 1, 0, 1, 0, 1},
                                      {1, 0, 1, 0, 1, 0, 1, 0, 1},
                                      {1, 8, 1, 0, 1, 0, 1, 0, 1},
                                      {1, 1, 1, 0, 1, 1, 1, 0, 1}};

            new_level = now_level + 1;
            new_level_s = new_level.ToString();
            need_map = "map" + new_level_s;
            switch (need_map){

                case "map1":
                    map = map1;
                    break;

                case "map2":
                    map = map2;
                    break;

                case "map3":
                    map = map3;
                    break;
            }

            Console.Clear();

            string health_spaces = "                                                                                         ";
            string hungry_spaces = "                                                                                          ";
            if (health < 10){

                health_spaces += " ";
            }

            if (hungry < 10){

                hungry_spaces += " ";
            }

            string inventory_a = things[inventory[0]];
            for (int r = 1; r < (97 - things[inventory[0]].Length); r++){

                inventory_a += " ";
            }
            string inventory_b = things[inventory[1]];
            for (int t = 1; t < (97 - things[inventory[1]].Length); t++){

                inventory_b += " ";
            }
            string inventory_c = things[inventory[2]];
            for (int b = 1; b < (97 - things[inventory[2]].Length); b++){

                inventory_c += " ";
            }

            if (need_slide == true){ // Slide about a new level

                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|                                                                                                     |");
                Console.WriteLine("| ███         █████████   ███      ███   █████████   ███           ███   ███      ███                 |");
                Console.WriteLine("| ███         ███         ███      ███   ███         ███           ████  ███    ███ ███               |");
                Console.WriteLine("| ███         ███          ███    ███    ███         ███           █████ ███    ███ ███               |");
                Console.WriteLine("| ███         █████████     ███  ███     █████████   ███           █████████    ███ ███     " + new_level_s + "         |");
                Console.WriteLine("| ███         ███            ██████      ███         ███           ███ █████      ███                 |");
                Console.WriteLine("| ███         ███             ████       ███         ███           ███  ████                          |");
                Console.WriteLine("| █████████   █████████        ██        █████████   █████████     ███   ███   █████████              |");
                Console.WriteLine("|                                                                                                     |");
                Console.WriteLine("| Satiety: " + hungry + health_spaces + "|");                
                Console.WriteLine("| Health: " + health + hungry_spaces + "|");
                Console.WriteLine("| Inventory:                                                                                          |");
                Console.WriteLine("|   1." + inventory_a + "|");
                Console.WriteLine("|   2." + inventory_b + "|");
                Console.WriteLine("|   3." + inventory_c + "|");
                Console.WriteLine("|                                                                                                     |");
                Console.WriteLine("| Press any key to start level(x to back to menu)                                                     |");
                Console.WriteLine("|                                                                                                     |");
                Console.WriteLine("=======================================================================================================");
                string exit =Convert.ToString(Console.ReadKey().KeyChar);
                if (exit == "x"){

                    Menu();
                }
            }

            Console.Clear();
        }

        public static void Menu(){ // Menu method

            string[,] Buttons = new string [,] {{"Play", "Map Maker"},
                                                {"About a game", "Quit"}};
            string[,] Choosed_buttons = new string [,] {{"PLAY", "MAP MAKER"},
                                                        {"ABOUT A GAME", "QUIT"}};
            string[,] Work_buttons = new string [,] {{"Play", "Map Maker"},
                                                    {"About a game", "Quit"}};

            int menu_x = 0;
            int menu_y = 0;
            int easter = 0;

            while (working == true){

                Work_buttons[menu_y, menu_x] = Choosed_buttons[menu_y, menu_x];


                Console.Clear();

                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|                                            Welcome   to                                             |");
                Console.WriteLine("|                                                                                                     |");
                Console.WriteLine("| ███       █████████   ████████    ███   ███  ████████     ███   ███     ███   █████████   ███   ███ |");
                Console.WriteLine("| ███       ███   ███   ███    ███  ███   ███  ███    ███   ███   █████   ███      ███      ███   ███ |");
                Console.WriteLine("| ███       ███   ███   ███    ███   ███ ███   ███    ███   ███   ██████  ███      ███      ███   ███ |");
                Console.WriteLine("| ███       █████████   ████████       ███     ████████     ███   ███ ███ ███      ███      █████████ |");
                Console.WriteLine("| ███       ███   ███   ███    ███     ███     ███    ███   ███   ███  ██████      ███      ███   ███ |");
                Console.WriteLine("| ███       ███   ███   ███    ███     ███     ███    ███   ███   ███     ███      ███      ███   ███ |");
                Console.WriteLine("| █████████ ███   ███   ████████       ███     ███    ███   ███   ███     ███      ███      ███   ███ |");
                Console.WriteLine("|                                                v. 0.1                                               |");                
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|                                                 |||                                                 |");
                Console.WriteLine("|                      " + Work_buttons[0, 0] + "                       |||                    " + Work_buttons[0, 1] +"                    |");
                Console.WriteLine("|                                                 |||                                                 |");
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("|                                                 |||                                                 |");
                Console.WriteLine("|                  " + Work_buttons[1, 0] +"                   |||                       " + Work_buttons[1, 1] +"                      |");
                Console.WriteLine("|                                                 |||                                                 |");
                Console.WriteLine("=======================================================================================================");
                string choose = Console.ReadKey().KeyChar.ToString();

                switch (choose){

                    case "w":
                        Work_buttons[menu_y, menu_x] = Buttons[menu_y, menu_x];
                        menu_y--;
                        if (menu_y < 0){

                            menu_y = 1;
                        }
                        break;
                        
                    case "a":
                        Work_buttons[menu_y, menu_x] = Buttons[menu_y, menu_x];
                        menu_x--;
                        if (menu_x < 0){

                            menu_x = 1;
                        }
                        break;
                        
                    case "s":
                        Work_buttons[menu_y, menu_x] = Buttons[menu_y, menu_x];
                        menu_y++;
                        if (menu_y > 1){

                            menu_y = 0;
                        }
                        break;
                        
                    case "d":
                        Work_buttons[menu_y, menu_x] = Buttons[menu_y, menu_x];
                        menu_x++;
                        if (menu_x > 1){

                            menu_x = 0;
                        }
                        break;

                    case "k":
                        if (easter == 0){

                            easter++;
                        }
                        else if (easter == 3){

                            debug = true;
                            LevelSelect();
                        }
                        break;
                    
                    case "i":
                        if (easter == 1){

                            easter++;
                        }
                        break;
                    
                    case "c":
                        if (easter == 2){

                            easter++;
                        }
                        break;

                    case "e":
                        int count_menu_y = menu_y * 2;
                        int count_menu = menu_x + count_menu_y;
                        switch (count_menu){

                            case 0:
                                Gameplay();
                                break;

                            case 1:
                                Console.Clear();

                                Console.WriteLine("=======================================================================================================");
                                Console.WriteLine("|                                            Welcome   to                                             |");
                                Console.WriteLine("|                                                                                                     |");
                                Console.WriteLine("| ███       █████████   ████████    ███   ███  ████████     ███   ███     ███   █████████   ███   ███ |");
                                Console.WriteLine("| ███       ███   ███   ███    ███  ███   ███  ███    ███   ███   █████   ███      ███      ███   ███ |");
                                Console.WriteLine("| ███       ███   ███   ███    ███   ███ ███   ███    ███   ███   ██████  ███      ███      ███   ███ |");
                                Console.WriteLine("| ███       █████████   ████████       ███     ████████     ███   ███ ███ ███      ███      █████████ |");
                                Console.WriteLine("| ███       ███   ███   ███    ███     ███     ███    ███   ███   ███  ██████      ███      ███   ███ |");
                                Console.WriteLine("| ███       ███   ███   ███    ███     ███     ███    ███   ███   ███     ███      ███      ███   ███ |");
                                Console.WriteLine("| █████████ ███   ███   ████████       ███     ███    ███   ███   ███     ███      ███      ███   ███ |");
                                Console.WriteLine("|                                                v. 0.1                                               |");                
                                Console.WriteLine("=======================================================================================================");
                                Console.WriteLine("|                                                                                                     |");
                                Console.WriteLine("|                                              N. New Map                                             |");
                                Console.WriteLine("|                                                                                                     |");
                                Console.WriteLine("=======================================================================================================");
                                Console.WriteLine("|                                                                                                     |");
                                Console.WriteLine("|                                              L. Load Map                                            |");
                                Console.WriteLine("| Any key to back to menu                                                                             |");
                                Console.WriteLine("=======================================================================================================");
                                choose = Convert.ToString(Console.ReadKey().KeyChar);
                                switch (choose){

                                    case "n":
                                        MapMaker();
                                        break;
                                
                                    case "l":
                                        Save.DecryptMap();
                                        break;
                                }
                                break;

                            case 2:
                                About();
                                break;

                            case 3:
                                working = false;
                                Console.Clear();
                                break;
                        }
                        break;
                }
            }
        }

        public static int[] Printing(int[,] karta){ // This method prints a map

            string map_out = "";

            for (int y = 0; y < 9; y++){

                string wall = "";

                for (int x = 0; x < 9; x++){

                    int need_elem = karta[y, x];
                    if (need_elem == 2){

                        player_x = x;
                        player_y = y;
                    }
                    string elem_out = elems[need_elem];
                    wall += elem_out;
                }
                map_out += wall + "\n";
                wall = "";
            }

            string hun_out = hungry.ToString();
            string hel_out = health.ToString();
            Console.WriteLine("| Satiety: " + hun_out + " |");
            Console.WriteLine("| Health: " + hel_out + " |");

            Console.WriteLine(map_out);

            map_out = "";

            int[] player = new int[] {player_y, player_x};
            return player;                
        }

        public static void Gameplay(){ // Main Game method

            Console.Clear();

            hungry = 10;

            while (working == true){

                var location_player = Printing(map);

                Console.Write("Write a direction or 'i' to open inventory(x to open menu): ");
                System.ConsoleKeyInfo btw_press = Console.ReadKey();

                char btw_movement = btw_press.KeyChar;
                string movement = btw_movement.ToString();

                old_x = location_player[1];
                old_y = location_player[0];

                switch (movement){

                    case "a":
                        Move("a");
                        break;

                    case "d":
                        Move("d");
                        break;

                    case "w":
                        Move("w");
                        break;

                    case "s":
                        Move("s");
                        break;
    
                    case "i":
                        inventoryOpen = true;
                        break;

                    case "x":
                        Menu();
                        break;

                    default:
                        wrongSymbol = true;
                        break;
                }

                Console.Clear();

                if (wallsWalk == true){

                    Console.WriteLine("You can't walk in walls!");
                    wallsWalk = false;
                }

                if (thingTaken == true){

                    Console.WriteLine("You got a " + thing_type + "!");
                    thingTaken = false;
                }
        
                if (wrongSymbol == true){
        
                    Console.WriteLine("Need a direction (wasd) or 'i' to open inventory!");
                    wrongSymbol = false;
                }

                if (inventoryOpen == true){
                    
                    int count_var = 1;
                    foreach (var thing in inventory){
                        
                        Console.WriteLine(count_var + "." + things[thing]);
                        count_var++;
                    }
                    inventoryOpen = false;
                }

                if (eatFood == true){

                    Console.WriteLine("You have eaten food!");
                    eatFood = false;
                }

                if (enemyKilled == true){

                    Console.WriteLine("You killed an enemy!");
                    enemyKilled = false;
                }

                if (doorNotOpened == true){

                    Console.WriteLine("You have not a key!");
                    doorNotOpened = false;
                }

                if (died == true){

                    score = health + hungry + current_level;
                    string score_space = "                                                                                  ";
                    if (score < 10){

                        score_space += " ";
                    }

                    Console.Clear();
                    Console.WriteLine("=======================================================================================================");
                    Console.WriteLine("|  ███      ███   █████████   ███   ███      ███         █████████   █████████   █████████  █████████ |");
                    Console.WriteLine("|   ███    ███    ███   ███   ███   ███      ███         ███   ███   ███            ███      ███████  |");
                    Console.WriteLine("|    ███  ███     ███   ███   ███   ███      ███         ███   ███   ███            ███       █████   |");
                    Console.WriteLine("|     ██████      ███   ███   ███   ███      ███         ███   ███   █████████      ███        ███    |");
                    Console.WriteLine("|      ████       ███   ███   ███   ███      ███         ███   ███         ███      ███         █     |");
                    Console.WriteLine("|       ██        ███   ███   ███   ███      ███         ███   ███         ███      ███               |");
                    Console.WriteLine("|       ██        █████████    ███████       █████████   █████████   █████████      ███        ███    |");
                    Console.WriteLine("|                                                                                                     |");
                    Console.WriteLine("|                                             █████████████                                           |");
                    Console.WriteLine("|                                            ██   █████   ██                                          |");                
                    Console.WriteLine("|                                            ██   █████   ██                                          |");
                    Console.WriteLine("|                                            ██████ █ ██████                                          |");
                    Console.WriteLine("|                                              ███████████                                            |");
                    Console.WriteLine("|                                              █ █ █ █ █ █                                            |");
                    Console.WriteLine("|                                              ███████████                                            |");
                    Console.WriteLine("|  Your score is: " + score.ToString() + score_space + "|");
                    Console.WriteLine("|  Press any key to back to menu                                                                      |");
                    Console.WriteLine("|                                                                                                     |");
                    Console.WriteLine("=======================================================================================================");
                    Console.ReadKey();
                    Thread.Sleep(3000);
                    Levels(0, false);
                    current_level = 1;
                    inventory = new int[] {0, 0, 0};
                    Menu();
                    died = false;
                }

                if (won == true){

                    Console.WriteLine("You completed " + current_level.ToString() + " level!");
                    Thread.Sleep(1000);
                    if (isUserMap){

                        Console.Write("Would you like to save your level? (y/n): ");
                        string question = Convert.ToString(Console.ReadKey().KeyChar);
                        if (question == "y"){

                            Save.Map(code_map);
                        }
                        
                        Levels(0, false);
                        inventory = new int[] {0, 0, 0};
                        isUserMap = false;
                        won = false;
                        Menu();
                    }
                    else if (current_level == 3){

                        score = health + hungry + current_level;
                        string score_space = "                                                                                  ";
                        if (score < 10){

                            score_space += " ";
                        }

                        Console.Clear();

                        Console.WriteLine("=======================================================================================================");
                        Console.WriteLine("|  ███      ███   █████████   ███   ███      ███     ███     ███   █████████   ███   ███  █████████   |");
                        Console.WriteLine("|   ███    ███    ███   ███   ███   ███      ███     ███     ███   ███   ███   ████  ███   ███████    |");
                        Console.WriteLine("|    ███  ███     ███   ███   ███   ███       ███   █████   ███    ███   ███   █████ ███    █████     |");
                        Console.WriteLine("|     ██████      ███   ███   ███   ███        ███ ███ ███ ███     ███   ███   █████████     ███      |");
                        Console.WriteLine("|      ████       ███   ███   ███   ███         █████   █████      ███   ███   ███ █████      █       |");
                        Console.WriteLine("|       ██        ███   ███   ███   ███          ███     ███       ███   ███   ███  ████              |");
                        Console.WriteLine("|       ██        █████████    ███████            █       █        █████████   ███   ███     ███      |");
                        Console.WriteLine("|                                                                                                     |");
                        Console.WriteLine("|                                            ██████████████                                           |");
                        Console.WriteLine("|                                            ██████████████                                           |");                
                        Console.WriteLine("|                                             ████████████                                            |");
                        Console.WriteLine("|                                               ████████                                              |");
                        Console.WriteLine("|                                                  ██                                                 |");
                        Console.WriteLine("|                                               ████████                                              |");
                        Console.WriteLine("|  Your score is: " + score.ToString() + score_space + "|");
                        Console.WriteLine("|                                                                                                     |");
                        Console.WriteLine("|  Press any key to back to menu                                                                      |");
                        Console.WriteLine("|                                                                                                     |");
                        Console.WriteLine("=======================================================================================================");
                        Console.ReadKey();
                        Levels(0, false);
                        current_level = 1;
                        inventory = new int[] {0, 0, 0};
                        won = false;
                        Menu();
                    }
                    else{
                        
                        won = false;
                        Levels(current_level, true);
                        current_level++;
                    }
                }
            }
        }

        static void Main(){ // Execute method

            Levels(0, false);
            Menu();
        }
    }
}