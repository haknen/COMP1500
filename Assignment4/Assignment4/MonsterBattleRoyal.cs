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
            private set
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
            private set
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
            private set
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
        private List<Monster> mMonsterArena = new List<Monster>();

        public Arena(string arenaName, uint capacity)
        {
            ArenaName = arenaName;
            Capacity = capacity;
        }

        public void LoadMonsters(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            string monsters = File.ReadAllText(filePath);
            if (String.IsNullOrWhiteSpace(monsters))
            {
                return;
            }

            char[] delimiters = { ',', '\n' };
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
                mMonsterArena.Add(new Monster(name, type, health, attack, defense));
            }
            MonsterCount = (uint)count;
        }

        public void GoToNextTurn()
        {
            for (int i = 0; i < mMonsterArena.Count; i++)
            {
                if (mMonsterArena.Count <= 1)
                {
                    Turns++;
                    return;
                }
                else if (i == mMonsterArena.Count - 1)
                {
                    mMonsterArena[i].Attack(mMonsterArena[0]);
                    if (mMonsterArena[0].Health <= 0)
                    {
                        mMonsterArena.RemoveAt(0);
                        MonsterCount--;
                    }
                    Turns++;
                }
                else
                {
                    mMonsterArena[i].Attack(mMonsterArena[i + 1]);
                    if (mMonsterArena[i + 1].Health <= 0)
                    {
                        mMonsterArena.RemoveAt(i + 1);
                        MonsterCount--;
                    }
                }
            }
        }

        public Monster GetHealthiestOrNull()
        {
            if (mMonsterArena.Count < 1)
            {
                return null;
            }

            int index = 0;
            for (int i = 1; i < mMonsterArena.Count; i++)
            {
                index = mMonsterArena[i].Health > mMonsterArena[index].Health ? i : index;
            }

            return mMonsterArena[index];
        }
    }
}
