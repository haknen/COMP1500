using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment4
{
    public enum EElementType
    {
        Fire,
        Water,
        Wind,
        Earth
    };

    public class Monster
    {
        public string Name { get; private set; }
        public EElementType ElementType { get; private set; }

        private int mHealth;
        private int mAttack;
        private int mDefense;
        public int Health
        {
            get
            {
                return mHealth;
            }
            set
            {
                mHealth = value < 0 ? 0 : value;
            }
        }
        public int AttackStat
        {
            get
            {
                return mAttack;
            }
            set
            {
                mAttack = value < 0 ? 0 : value;
            }
        }
        public int DefenseStat
        {
            get
            {
                return mDefense;
            }
            set
            {
                mDefense = value < 0 ? 0 : value;
            }
        }

        public Monster(string name, EElementType elementType, int health, int attack, int defence)
        {
            Name = name;
            ElementType = elementType;
            Health = health;
            AttackStat = attack;
            DefenseStat = defence;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public void Attack(Monster otherMonster)
        {
            int damage = AttackStat - otherMonster.DefenseStat;
            double finalDamage = damage;
            switch (ElementType)
            {
                case EElementType.Fire:
                    {
                        switch (otherMonster.ElementType)
                        {
                            case EElementType.Wind:
                                finalDamage *= 1.5;
                                break;
                            case EElementType.Water:
                            case EElementType.Earth:
                                finalDamage *= 0.5;
                                break;
                            case EElementType.Fire:
                            default:
                                break;
                        }
                    }
                    break;

                case EElementType.Water:
                    {
                        switch (otherMonster.ElementType)
                        {
                            case EElementType.Fire:
                                finalDamage *= 1.5;
                                break;
                            case EElementType.Wind:
                                finalDamage *= 0.5;
                                break;
                            case EElementType.Water:
                            case EElementType.Earth:
                            default:
                                break;
                        }
                    }
                    break;

                case EElementType.Wind:
                    {
                        switch (otherMonster.ElementType)
                        {
                            case EElementType.Water:
                            case EElementType.Earth:
                                finalDamage *= 1.5;
                                break;
                            case EElementType.Fire:
                                finalDamage *= 0.5;
                                break;
                            case EElementType.Wind:
                            default:
                                break;
                        }
                    }
                    break;

                case EElementType.Earth:
                    {
                        switch (otherMonster.ElementType)
                        {
                            case EElementType.Fire:
                                finalDamage *= 1.5;
                                break;
                            case EElementType.Wind:
                                finalDamage *= 0.5;
                                break;
                            case EElementType.Water:
                            case EElementType.Earth:
                            default:
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }

            if (finalDamage < 1)
            {
                otherMonster.TakeDamage(1);
            }
            else
            {
                otherMonster.TakeDamage((int)finalDamage);
            }
        }
    }

    public class Arena
    {
        public uint Capacity { get; private set; }
        public string ArenaName { get; private set; }
        public uint Turns { get; private set; }
        public uint MonsterCount { get; private set; }
        private List<Monster> MonsterArena = new List<Monster>();

        public Arena(string arenaName, uint capacity)
        {
            ArenaName = arenaName;
            Capacity = capacity;
        }

        public void LoadMonsters(string filePath)
        {
            char[] delimiters = { ',', '\n' };
            string monsters = File.ReadAllText(filePath);
            string[] data = monsters.Split(delimiters);
            int count = 0;
            for (int i = 0; i < data.Length; i++)
            {
                count++;
                if (count > Capacity)
                {
                    count--;
                    break;
                }
                string name = data[i++];
                EElementType type = (EElementType)Enum.Parse(typeof(EElementType), data[i++]);
                int health = Int32.Parse(data[i++]);
                int attack = Int32.Parse(data[i++]);
                int defense = Int32.Parse(data[i]);
                MonsterArena.Add(new Monster(name, type, health, attack, defense));
            }
            MonsterCount = (uint)count;
        }

        public void GoToNextTurn()
        {
            for (int i = 0; i < MonsterArena.Count; i++)
            {
                if (MonsterArena.Count <= 1)
                {
                    return;
                }
                else if (i == MonsterArena.Count - 1)
                {
                    MonsterArena[i].Attack(MonsterArena[0]);
                    if (MonsterArena[0].Health <= 0)
                    {
                        MonsterArena.RemoveAt(0);
                        MonsterCount--;
                    }
                    Turns++;
                }
                else
                {
                    MonsterArena[i].Attack(MonsterArena[i + 1]);
                    if (MonsterArena[i + 1].Health <= 0)
                    {
                        MonsterArena.RemoveAt(i + 1);
                        MonsterCount--;
                    }
                }
            }
        }

        public Monster GetHealthiestOrNull()
        {
            if (MonsterArena.Count < 1)
            {
                return null;
            }

            int index = 0;
            for (int i = 1; i < MonsterArena.Count; i++)
            {
                index = MonsterArena[i].Health > MonsterArena[index].Health ? i : index;
            }

            return MonsterArena[index];
        }
    }
}
