#pragma once
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <conio.h>
#include <io.h>
#include <Windows.h>

#define PlayerDLL_API __declspec(dllexport) 


class Player
{
public:
	Player(void);
	~Player(void);

	void PlayerDLL_API play();
	void PlayerDLL_API pause();
	void PlayerDLL_API next();
	void PlayerDLL_API prev();
private:
	char *mciData;
};

