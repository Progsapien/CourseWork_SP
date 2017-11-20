#include "Player.h"

Player::Player(void)
{
	mciData = new char[100];
	current_command = new char[100];
	playlist = new vector<string*>();
	current_position = -1;
}

Player::~Player(void)
{

}

void Player::next() {

	if(current_position < playlist->size()-1) {
		current_position++;
	} else {
		current_position = 0;
	}

	stop();

	sprintf(current_command, "open %s alias mp3file", playlist->at(current_position));
	mciSendStringA(current_command, NULL, 0, NULL);
	mciSendStringA("play mp3file", NULL, 0, NULL);
}

void Player::prev() {
	if(current_position > 0) {
		current_position--;
	} else {
		current_position = playlist->size()-1;
	}

	stop();

	sprintf(current_command, "open %s alias mp3file", playlist->at(current_position));
	mciSendStringA(current_command, NULL, 0, NULL);
	mciSendStringA("play mp3file", NULL, 0, NULL);
}

void Player::stop() {
	mciSendStringA("stop mp3file", NULL, 0, NULL);
	mciSendStringA("close mp3file", NULL, 0, NULL);
}

void Player::play(int position) {

	stop();
	current_position = position;
	sprintf(current_command, "open %s alias mp3file", playlist->at(position));
	mciSendStringA(current_command, NULL, 0, NULL);
	mciSendStringA("play mp3file", NULL, 0, NULL);

}

void Player::loadFile(string *path) {
	playlist->push_back(path);
	current_position = 0;
}


string* Player::currentFile() {
	return playlist->at(current_position);
}