using UnityEngine;
using System.Collections;

public class CharacterSheet {

	public string name;
	public int level;
	public int xp;
	public float health;
	public float stamina;
	public float energy;
	public int lives;

	public CharacterSheet()
	{
		name = "Default";
		level = 1;
		xp = 0;
		health = 10;
		stamina = 10;
		energy = 10;
		lives = 3;
	}

	public CharacterSheet(string _name, int _level, int _xp, float _health, float _stam, float _energy, int _lives)
	{
		name = _name;
		level = _level;
		xp = _xp;
		health = _health;
		stamina = _stam;
		energy = _energy;
		lives = _lives;
	}
}

