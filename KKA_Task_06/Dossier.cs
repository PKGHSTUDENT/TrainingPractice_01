using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace KKA_Task_06
{
    internal class Dossier
    {
        public int countDossier;
        public string[] fullnames;
        public string[] professions;
        public string[,] dossier;

        public void OpenDossier()
        {
            GenerateDossier();
            Console.WriteLine(fullnames.Length);
            Console.WriteLine(dossier.Length);
            Navigate();
        }

        public void Navigate()
        {
            int chooce = 1;
            while (chooce != 0)
            {
                Console.Write("Welcome to the dossier archive. Select the desired item.\n" +
                "0. Exit.\n" +
                "1. Show all dossiers.\n" +
                "2. Add dossier.\n" +
                "3. Delete dossier by index.\n" +
                "4. Find dossier by last name.\n" +
                "5. Other options.\n-> ");

                chooce = Convert.ToInt32(Console.ReadLine());

                switch (chooce)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        PrintDossier();
                        break;
                    case 2:
                        AddDossier();
                        break;
                    case 3:
                        DeleteDossierById();
                        break;
                    case 4:
                        FindDossierByLastName();
                        break;
                    case 5:
                        Console.WriteLine("Other options:\n" +
                            "0. Back to main menu.\n" +
                            "1. Print fullnames.\n" +
                            "2. Print profession.");
                        chooce = Convert.ToInt32(Console.ReadLine());
                        switch (chooce)
                        {
                            case 0:
                                break;
                            case 1:
                                PrintArray(fullnames);
                                break;
                            case 2:
                                PrintArray(professions);
                                break;
                            default:
                                Console.WriteLine("Incorrect value");
                                break;
                        }
                        break;
                }
            }
        }

        public void AddDossier()
        {
            Console.Clear();
            Console.Write("Fill in the dossier.\n" +
                "Enter fullname: ");
            string fullname = Console.ReadLine();
            if (fullname == null)
            {
                Console.WriteLine("Last name not entered. Return to the main menu.");
                return;
            }
            
            Console.Write("Enter profession: ");
            string profession = Console.ReadLine();

            if (profession != null)
            {
                dossier[countDossier, 0] = fullname;
                dossier[countDossier, 1] = profession;
            }
            else
            {
                Console.WriteLine("Profession not entered. Return to the main menu.");
                return;
            }

            ++countDossier;
        }

        public void DeleteDossierById()
        {
            Console.Write("Enter the id of the dossier you want to delete: ");
            int id = Convert.ToInt16(Console.ReadLine());
            if (!(id < 0 || id > countDossier))
            {
                string[,] newDossier = new string[100, 2];
                for (int i = 0; i < id; i++)
                {
                    newDossier[i, 0] = dossier[i, 0];
                    newDossier[i, 1] = dossier[i, 1];
                }

                for (int i = id; i < countDossier; i++)
                {
                    newDossier[i, 0] = dossier[i + 1, 0];
                    newDossier[i, 1] = dossier[i + 1, 1];
                }

                dossier = newDossier;
            }
            else
            {
                Console.WriteLine("There is no such id to delete.");
                return;
            }

            --countDossier;
        }

        public void FindDossierByLastName()
        {
            Console.Write("Enter the first name, last name or patronymic and the program will display all matches.\n-> ");
            string regex = Console.ReadLine();
            if (regex != null)
            {
                Console.WriteLine("Result:\n");
                Console.WriteLine("+----+-----------------------------------+-------------------------+\n" +
                                  "| id |               Fullname            |         Occupation      |\n" +
                                  "+----+-----------------------------------+-------------------------+");
                for (int i = 0; i < countDossier; i++)
                {
                    if (dossier[i, 0].Contains(regex))
                    {
                        Console.WriteLine("|{0, 4}|{1, 35}|{2, 25}|", i, dossier[i, 0], dossier[i, 1]);
                        Console.WriteLine("+----+-----------------------------------+-------------------------+");
                    }
                }
            }
            else
            {
                Console.WriteLine("You left the input field empty. Return to the main menu.");
            }
        }

        public void GenerateDossier()
        {
            fullnames = new string[] { "Kudryavtseva Kamila Vladislavovna", "Ivanov Anton Alexandrovich", "Aksenov Timur Ilyich",
                                           "Volkov Fedor Daniilovich", "Kuzina Yaroslava Maksimovna", "Romanov Platon Daniilovich",
                                           "Shmeleva Diana Denisovna", "Afanasiev Matvey Semyonovich", "Alekhin Maxim Romanovich",
                                           "Rumyantseva Amira Denisovna", "Orlov Yaroslav Ruslanovich", "Sotnikova Amelia Timurovna",
                                           "Ivanov Nikita Vadimovich", "Tolkacheva Eva Alekseevna", "Eliseev Platon Pavlovich"};

            professions = new string[] { "Management consultant", "Obstetrician", "Missionary", "Jewellery maker", "Councillor",
                                            "Circus worker", "Model", "Craftsperson", "Costume designer", "Garden designer",
                                            "Delivery driver", "Hairdresser", "Dietician", "Composer", "Building labourer"};

            Random rand = new Random();
            int dossierLength = fullnames.Length;
            countDossier = dossierLength;
            dossier = new string[100, 2];
            for (int i = 0; i < dossierLength; i++)
            {
                dossier[i, 0] = fullnames[i];
                dossier[i, 1] = professions[rand.Next(0, professions.Length)];
            }
        }

        public void PrintArray(string[] array)
        {
            foreach (string s in array) { Console.WriteLine(s); }
        }

        public void PrintDossier()
        {
            Console.WriteLine("+----+-----------------------------------+-------------------------+\n" +
                              "| id |               Fullname            |         Occupation      |\n" +
                              "+----+-----------------------------------+-------------------------+");
            for (int i = 0; i < countDossier; i++)
            {
                Console.WriteLine("|{0, 4}|{1, 35}|{2, 25}|", i, dossier[i, 0], dossier[i, 1]);
                Console.WriteLine("+----+-----------------------------------+-------------------------+");
            }
        }
    }
}
