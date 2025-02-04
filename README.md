# Chat Application (Client-Server Model)

## Overview
This is a real-time console-based **Chat Application** using the **Client-Server Model**. It allows multiple clients to connect to a server and communicate with each other. The application is built using **C#** and **.NET Framework 4.7.2/4.8**.

## Features
- Multi-client support (clients can join and leave dynamically).
- Real-time messaging using **TCP/IP sockets**.
- Clients receive messages from other connected users.
- Threading for handling multiple connections efficiently.
- Server logs client connections and messages.

## Technologies Used
- **Language:** C#
- **Framework:** .NET Framework 4.7.2/4.8
- **Networking:** TCP/IP (System.Net.Sockets)
- **Threading:** Multi-threading to handle multiple clients

## Project Structure
```
ChatApplication/
│── ChatServer/
│   ├── ChatServer.cs
│   ├── Program.cs
│
│── ChatClient/
│   ├── ChatClient.cs
│   ├── Program.cs
│
│── README.md
```

## Installation and Setup
### Prerequisites
- **Microsoft Visual Studio** (with .NET Framework 4.7.2/4.8 support)
- **.NET Framework 4.7.2/4.8 installed**

### Steps to Run the Server
1. Open **Visual Studio**.
2. **Set `ChatServer` as the startup project**.
3. Click **Start (Ctrl + F5)** to run the server.
4. The server will start listening on **port 5000**.

### Steps to Run Clients
1. Open **Visual Studio**.
2. **Set `ChatClient` as the startup project**.
3. Click **Start (Ctrl + F5)** to run the client.
4. Enter a **username** and start sending messages.
5. Open another instance of the **ChatClient** to simulate multiple users.

## Usage
- The **server** runs and listens for client connections.
- **Clients** connect to the server and exchange messages.
- Messages are **broadcast** to all connected clients.
- The **server logs** all received messages.

## Enhancements (Future Improvements)
- Implement **message encryption (AES encryption)**.
- Add **Graphical User Interface (GUI)** using WinForms/WPF.
- Support **private messaging** between clients.
- Improve client **disconnection handling**.

## License
This project is open-source and available under the **MIT License**.

## Author
Developed by **[Muhammad Huraira]**.

