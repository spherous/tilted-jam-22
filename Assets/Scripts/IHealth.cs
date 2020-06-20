﻿public interface IHealth
{
    int MaxHealth {get; set;}
    int CurrentHealth {get; set;}

    void LoseHealth(int amount);
    void GainHealth(int amount);
    void FullHeal();
}