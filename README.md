# Simple Password Manager

This project is a simple C# console application that allows users to securely store and manage their passwords locally.

## Project Idea

The program first asks the user to create a **Master Key** which protects all stored passwords. Then, it reads encrypted passwords saved in a local file and allows the user to perform different operations such as listing, adding, retrieving, or deleting passwords.

Each password is encrypted before saving, and decrypted when displayed to the user.

## Supported Features

- Set and validate a Master Key for access control
- Add new passwords or update existing ones by website or app name
- Retrieve saved passwords by website or app name
- Delete saved passwords
- List all stored passwords

## Program Behavior

- On the first run, the user is prompted to create a Master Key.
- On subsequent runs, the user must enter the correct Master Key to access the stored passwords.
- Passwords are saved encrypted in a text file called `passwords.txt`.
- The program continuously shows a menu for password management until the user exits.

## Project Goal

This project is designed to teach fundamental C# programming concepts such as:

- Reading and writing files
- Using
