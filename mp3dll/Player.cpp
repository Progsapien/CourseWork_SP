#include "Player.h"

Player::Player(void)
{
	mciData = new char[100];
}

Player::~Player(void)
{

}

void Player::next() {
	mciSendStringA("open D:/1.mp3 alias mp3file", NULL, 0, NULL);
	mciSendStringA("play mp3file", NULL, 0, NULL);
}

void Player::prev() {

}

void Player::pause() {

}

void Player::play() {

}