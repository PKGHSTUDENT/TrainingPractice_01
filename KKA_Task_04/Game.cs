namespace KKA_Task_04
{
    internal class Game
    {
        public Random random = new Random();

        public Hero hero = new Hero("Random");
        public Boss boss = new Boss("Random");
        public Spell[] spells = new Spell[6];

        public string lastSpell = null;

        public bool heroTurn = true;

        public void Run()
        {
            GenerateSpells();
            int choice;

            do
            {
                Console.Write("Main menu. Choose your action:\n" +
                              "0. Exit.\n" +
                              "1. Start game.\n" +
                              "2. Customize boss or my hero.\n" +
                              "3. Description.\n" +
                              "4. Output generated character data.\n" +
                              "5. Regenerate characters.\n" +
                              "-> ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        CustomizeCharacters();
                        break;
                    case 3:
                        PrintDescription();
                        break;
                    case 4:
                        CharacterСharacteristic();
                        break;
                    case 5:
                        RegenerateCharacters();
                        break;
                    default:
                        Console.WriteLine("Incorect choose");
                        break;
                }
            }
            while (choice != 0) ;
        }

        public void RegenerateCharacters()
        {
            hero = new Hero("Random");
            boss = new Boss("Boss");
        }

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("The battle begins! May the strongest and random win!");

            CharacterСharacteristic();
            PrintSpells();

            Console.WriteLine("Read data about spells and your characters and press any key to continue.");
            Console.ReadLine();

            Battle();
        }

        public void Battle()
        {
            Console.Clear();

            // if true, then the first move is up to the player
            // otherwise the boss goes first
            if (!RandomFirstMove())
            {
                Console.WriteLine("The boss goes first.");
                BossHit();
            }

            while (hero.Hp > 0 && boss.Hp > 0)
            {
                PrintCharactersHp();
                if (heroTurn)
                    while (heroTurn)
                        HeroHit();
                else
                    BossHit();
            }

            if (hero.Hp <= 0)
                Console.WriteLine("You lost and it's very sad. But do not despair. Life goes on and so does your journey!");
            else
                Console.WriteLine("You have defeated the boss! Congratulations!");

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        public void BossHit()
        {
            int randomChoice = random.Next(0, 5);
            Spell selectedSpell = spells[randomChoice];
            Console.WriteLine($"The boss chooses a spell: {selectedSpell.NameSpell}");

            int damage = 0;
            int regen = 0;
            CalculateDamage(boss, hero, selectedSpell, ref damage, ref regen);

            if (damage != 0)
            {
                Hit(damage, hero);
                HitInfo(boss, hero, damage);
            }
            if (regen != 0)
            {
                RegenHP(regen, boss);
            }
            heroTurn = true;
        }

        public void HeroHit()
        {
            Console.WriteLine("Choose a spell: ");
            PrintSpellNames();

            Console.Write("->");

            int choisenSpell = Convert.ToInt32(Console.ReadLine()) - 1;
            if (choisenSpell < 0 || choisenSpell > spells.Length)
            {
                Console.WriteLine("There is no such spell.");
                return;
            }

            Spell selectedSpell = spells[choisenSpell];

            if (selectedSpell.Condition != "None" &&
                lastSpell == selectedSpell.Condition ||
                selectedSpell.Condition == "None")
            {
                int damage = 0;
                int regen = 0;
                CalculateDamage(hero, boss, selectedSpell, ref damage, ref regen);

                if (damage != 0)
                {
                    Hit(damage, boss);
                    HitInfo(hero, boss, damage);
                }
                if (regen != 0)
                {
                    RegenHP(regen, hero);
                }
            }
            else
            {
                PrintConditionViolation(selectedSpell.NameSpell, selectedSpell.Condition);
                return;
            }

            lastSpell = selectedSpell.NameSpell;

            heroTurn = false;
        }
        
        public void CalculateDamage(Character attack, Character defense, Spell attackSpell, ref int damage, ref int regen)
        {
            if (attackSpell.IsAttackingSpell)
            {
                damage = (attackSpell.Damage + boss.ImpactForce);
            }

            if (attackSpell.IsAttackingSpell && attackSpell.IsMagicSpell && defense.MagicProtection != 0)
            {
                damage += (hero.MagicProtection / 100);
            }
            else if (attackSpell.IsAttackingSpell && !attackSpell.IsMagicSpell && defense.PhysicalProtection != 0)
            {
                damage += (hero.PhysicalProtection / 100);
            }
        }

        public void Hit(int damage, Character character)
        {
            character.Hp -= damage;
        }

        public void RegenHP(int damage, Character character)
        {
            character.Hp += damage;
        }

        public void CustomizeCharacters()
        {
            Console.WriteLine("Select the character you want to customize:\n0. Back to home\n" +
                              "1. Hero.\n2. Boss.\n-> ");
            int choiceCharacter = Convert.ToInt32(Console.ReadLine());
            switch (choiceCharacter)
            {
                case 0:
                    return;
                case 1:
                    ChangeCharacter(hero, "hero");
                    break;
                case 2:
                    ChangeCharacter(boss, "boss");
                    break;
                default:
                    Console.WriteLine("Incorect choose!");
                    break;
            }
        }

        public void ChangeCharacter(Character character, string characterType)
        {
            Console.Write($"Enter name your {characterType}: ");
            string name = Console.ReadLine();
            if (name != null)
                character.Name = name;
            else
                character.Name = hero.GetRandomName();

            Console.Write($"Enter number of health points your {characterType}: ");
            int template = Convert.ToInt32(Console.ReadLine());
            if (CheckCorrectValue(template, 50, 9999))
                character.Hp = template;

            Console.Write($"Enter base damage your {characterType}: ");
            template = Convert.ToInt32(Console.ReadLine());
            if (CheckCorrectValue(template, 0, 50))
                character.ImpactForce = template;

            Console.Write($"Enter magic protection your {characterType}: ");
            template = Convert.ToInt32(Console.ReadLine());
            if (CheckCorrectValue(template, 0, 30))
                character.MagicProtection = template;

            Console.Write($"Enter psysical protection your {characterType}: ");
            template = Convert.ToInt32(Console.ReadLine());
            if (CheckCorrectValue(template, 0, 30))
                character.PhysicalProtection = template;
        }

        public void CharacterСharacteristic()
        {
            Console.WriteLine($"Hero name: {hero.Name}\n" +
                $"Hero hp: {hero.Hp}\n"+
                $"Hero power: {hero.ImpactForce}\n" +
                $"Hero magic protection: {hero.MagicProtection}\n" +
                $"Hero physical protection: {hero.PhysicalProtection}\n");

            Console.WriteLine($"Boss name: {boss.Name}\n" +
                $"Boss hp: {boss.Hp}\n" + "" +
                $"Boss power: {boss.ImpactForce}\n" +
                $"Boss magic protection: {boss.MagicProtection}\n" +
                $"Boss physical protection: {boss.PhysicalProtection}\n");
        }

        public bool CheckCorrectValue(int template, int min, int max)
        {
            if (template < min || template > max)
            {
                Console.WriteLine("Incorrect value.");
                return false;
            }
            return true;
        }

        public void PrintDescription()
        {
            string description = "Dobrodelete Heros game.\r\n\r\n" +
                "In this game, you and your character have to fight a powerful boss with the help of magic and logic.\r\n\r\n" +
                "Good luck young heroes!\r\n";
            Console.WriteLine(description);
        }

        public void GenerateSpells()
        {
            spells[0] = new Spell("Surge of Chaos",
                "The spell causes the heavens to unfurl, causing an earthquake and meteor showers, and deals 350 damage.",
                true, true, false, 200);

            spells[1] = new Spell("Repose Bolt",
                "You summon the god Bolt, which gives you the opportunity to rest and recover 150 hp.",
                true, false, true, 150);

            spells[2] = new Spell("Calm of Pride",
                "(only after Surge of Chaos)\n" +
                "The spell that is called after the chaos plunges the enemy into a stupor and inflicts moral damage of 150 " + 
                "points on him, which greatly affects his well-being. Also restores 150 health.",
                true, true, true, 300, "Surge of Chaos");

            spells[3] = new Spell("Absorption of the Sun",
                "(only after Calm of Pride)\n" +
                "The spell breaks the movement of your hero's planet, allowing you to use the sun as a weapon. Use it wisely and deal 500 damage",
                true, true, false, 500, "Calm of Pride");

            spells[4] = new Spell("Staff Strike",
                "Regular staff strike. Nothing interesting. 200 damage",
                false, true, false, 200);

            spells[5] = new Spell("Summon Wolves",
                "Your character's connection to nature has its benefits. You can summon a friendly pack of wolves that will gnaw at the enemy for 200 damage.",
                false, true, false, 200);
        }

        public void PrintSpells()
        {
            foreach (Spell spell in spells)
            {
                Console.WriteLine(
                    $"\nSpell name: {spell.NameSpell}\n" +
                    $"Description: {spell.DescriptionSpell}\n" +
                    $"Damage/Healing: {spell.Damage}\n");
            }
        }

        public void PrintSpellNames()
        {
            int i = 1;
            foreach (Spell spell in spells)
            {
                Console.WriteLine($"{i}. {spell.NameSpell}\n");
                ++i;
            }
        }

        public void PrintCharactersHp()
        {
            Console.WriteLine($"{boss.Name} hp: {boss.Hp}\n" +
                $"{hero.Name} hp: {hero.Hp}\n");
        }

        public void HitInfo(Character attack, Character defense, int damage)
        {
            Console.WriteLine($"{attack.Name} dealt {damage} damage {defense.Name}!\n");
        }

        public void RegenInfo(Character character, int regen)
        {
            Console.WriteLine($"{character.Name} restored {regen} health points\n");
        }

        public void PrintConditionViolation(string spellName, string conditionSpell)
        {
            Console.WriteLine($"Sorry, but before using {spellName} you must use {conditionSpell}:((\n");
        }

        public bool RandomFirstMove()
        {
            return (random.Next(0, 1) == 0) ? true : false;
        }
    }
}
